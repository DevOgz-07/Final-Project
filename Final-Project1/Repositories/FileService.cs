using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karl.BL.Repositories
{
    public class FileService :IFileService
    {
        public async Task<string?> UploadSingleAsync(IFormFile file, string webRootPath, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            var uploadPath = Path.Combine(webRootPath, "img", folderName);
           
         
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            var fileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
           

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(stream);

            return $"/img/{folderName}/{fileName}";
        }



        public async Task<List<string>> UploadMultipleAsync(IEnumerable<IFormFile> files, string webRootPath, string folderName)
        {
            var paths = new List<string>();
            foreach (var file in files)
            {
                var path = await UploadSingleAsync(file, webRootPath, folderName);
                if (path != null) paths.Add(path);
            }
            return paths;
        }

      
        public Task DeleteAsync(string relativePath,string webRoothPath)
        {
            
            if (string.IsNullOrWhiteSpace(relativePath)) return Task.CompletedTask;
          

           
            var rel = relativePath.TrimStart('~', '/', '\\')
                         .Replace("/", Path.DirectorySeparatorChar.ToString());

            
            var fullPath = Path.Combine(webRoothPath, rel);

            
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            return Task.CompletedTask;
        }
    }
}
