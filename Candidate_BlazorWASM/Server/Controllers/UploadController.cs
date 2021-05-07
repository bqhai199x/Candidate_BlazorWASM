using Candidate_BlazorWASM.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task Post(UploadedFile file)
        {
            var folderName = Path.Combine("StaticFiles", "CV");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var path = $"{pathToSave}\\{file.FileName}";
            var fs = System.IO.File.Create(path);
            await fs.WriteAsync(file.FileContent, 0, file.FileContent.Length);
            fs.Close();
        }
    }
}
