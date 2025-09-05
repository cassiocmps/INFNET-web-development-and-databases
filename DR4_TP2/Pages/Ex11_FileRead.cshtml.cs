using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace DR4_TP2.Pages
{
    public class Ex11_FileReadModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public Ex11_FileReadModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public List<FileInfo> Files { get; set; } = new();
        public string SelectedFileName { get; set; } = string.Empty;
        public string FileContent { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public class FileInfo
        {
            public string Name { get; set; } = string.Empty;
            public double SizeKB { get; set; }
            public DateTime LastModified { get; set; }
        }

        public async Task OnGetAsync(string? fileName = null)
        {
            try
            {
                var filesPath = Path.Combine(_environment.WebRootPath, "files");
                
                Directory.CreateDirectory(filesPath);
                
                var txtFiles = Directory.GetFiles(filesPath, "*.txt");
                
                Files = txtFiles.Select(filePath =>
                {
                    var info = new System.IO.FileInfo(filePath);
                    return new FileInfo
                    {
                        Name = info.Name,
                        SizeKB = Math.Round(info.Length / 1024.0, 2),
                        LastModified = info.LastWriteTime
                    };
                }).OrderByDescending(f => f.LastModified).ToList();
                
                if (!string.IsNullOrEmpty(fileName))
                {
                    var requestedFilePath = Path.Combine(filesPath, fileName);
                    
                    if (System.IO.File.Exists(requestedFilePath) && Path.GetExtension(fileName).ToLower() == ".txt")
                    {
                        SelectedFileName = fileName;
                        FileContent = await System.IO.File.ReadAllTextAsync(requestedFilePath);
                    }
                    else
                    {
                        ErrorMessage = $"File '{fileName}' not found or is not a text file.";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error reading files: {ex.Message}";
            }
        }

        public async Task<IActionResult> OnGetDownloadAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            var filesPath = Path.Combine(_environment.WebRootPath, "files");
            var filePath = Path.Combine(filesPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}