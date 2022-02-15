using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Toyota.Data;

namespace Toyota.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDumpsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetDumpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<string[]>> GetRes(string name)
        {

            string[] arr = { name, "Error" };

            if (name == "Backup_Models")
            {
                 arr = new string[]{ "Models", "Success" };
                 return arr;
            }
            if (name == "Backup_Colors")
            {
                var b = new Helper.Database.Dump.Create();
                b.DumpColors(_context);
                arr = new string[] { "Colors", "Success" };
                return arr;
            }
            if (name == "Backup_Modifications")
            {
                arr = new string[] { "Modifications", "Success" };
                return arr;
            }
            if (name == "Backup_Modification_Colors")
            {
                arr = new string[] { "Modification Colors", "Success" };
                return arr;
            }

           
            return arr;
        }

        [HttpGet]
        public async Task<ActionResult<string[]>> GetFiles()
        {

            string path = "dumps/";
            string rootDirr = Helpers.Media.WebRootStoragePath;
            string[] files = Directory.GetFiles(rootDirr + path);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace(rootDirr + path, "");
            }

            return files;
        }

    }
}
