using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages.NoteManager
{
    public class ReadNotesModel : PageModel
    {
        public List<string> FileNames { get; set; } = new();
        public string? SelectedContent { get; set; }

        public void OnGet(string? file)
        {
            var filesDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");
            FileNames = Directory.GetFiles(filesDir, "*.txt")
                                 .Select(Path.GetFileName)
                                 .ToList();

            if (!string.IsNullOrEmpty(file))
            {
                var filePath = Path.Combine(filesDir, file);
                if (System.IO.File.Exists(filePath))
                {
                    SelectedContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }
    }
}
