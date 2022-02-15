using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Toyota.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class getAdminFilesController : ControllerBase
    {
        [HttpGet("{path}")]
        public async Task<ActionResult<string[]>> GetDirs(string? path)
        {
            path = path.Replace('~', '\\');
            string rootDirr = Helpers.Media.WebRootStoragePath;
            string[] dirs = Directory.GetDirectories(rootDirr + path);

            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Replace(Helpers.Media.WebRootStoragePath, "");
            }

            return dirs;
        }

        
    }
}
