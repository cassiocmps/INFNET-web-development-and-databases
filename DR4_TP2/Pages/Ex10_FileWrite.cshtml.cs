using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages
{
    public class Ex10_FileWriteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public Ex10_FileWriteModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string SavedFileName { get; set; } = string.Empty;
        public string SavedTimestamp { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public class InputModel
        {
            [Required(ErrorMessage = "Note content is required.")]
            [MinLength(10, ErrorMessage = "Note content must be at least 10 characters long.")]
            public string Content { get; set; } = string.Empty;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                var fileName = $"note-{timestamp}.txt";
                
                var filesPath = Path.Combine(_environment.WebRootPath, "files");
                
                Directory.CreateDirectory(filesPath);
                
                var filePath = Path.Combine(filesPath, fileName);
                
                await System.IO.File.WriteAllTextAsync(filePath, Input.Content);
                
                SavedFileName = fileName;
                SavedTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                
                Input = new InputModel();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error saving file: {ex.Message}";
            }

            return Page();
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