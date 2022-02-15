using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Toyota.Data;
using Toyota.Data.Entities;
using Toyota.Helpers;

namespace Toyota.Helper.Database.Dump
{
    public class Create
    {
        public string DumpColors(ApplicationDbContext db)
        {
            List<Color> tblColors = db.Colors.ToList();
            List<Model> allDB = new List<Model>();
            //allDB = db.Modifications.Include(Mod => Mod.Model).Include

            string fileName = Guid.NewGuid() + ".xml";
            string fileServerPath;

            //fileServerPath = Helpers.Media.CreateDirectory("dumps");
            fileServerPath = Media.WebRootStoragePath + "dumps/";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Color>));

            
            using (FileStream fs = new FileStream(fileServerPath + fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tblColors);

                Console.WriteLine("Объект сериализован");
            }

            string msg = "<a href='https://localhost:60436/storage/dumps/" +
fileName + "' target='_top'> Download </a>";

            Helper.Notification.Email.SendEmailAsync("fozzynice@gmail.com", "BackUp Colors", "We have backuped colors => " + msg);

            return fileName;
        }
    }
}
