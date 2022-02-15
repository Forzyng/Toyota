using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Toyota.Controllers.Admin
{
    public class AdminBackupController : Controller
    {
        public IActionResult Index()
        {
           
                string path = "dumps/";
                string rootDirr = Helpers.Media.WebRootStoragePath;
                string[] files = Directory.GetFiles(rootDirr + path);

                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Replace(rootDirr + path, "");
                }
            ViewBag.Files = files;


            return View();
        }
    }
}
