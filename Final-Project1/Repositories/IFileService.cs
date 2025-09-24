using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karl.BL.Repositories
{
    public interface IFileService
    {
       
        Task<string?> UploadSingleAsync(IFormFile file, string webRootPath, string folderName);

        

        Task<List<string>> UploadMultipleAsync(IEnumerable<IFormFile> files, string webRootPath, string folderName);

        
        Task DeleteAsync(string relativePath, string WebRootPath);
    }
}
