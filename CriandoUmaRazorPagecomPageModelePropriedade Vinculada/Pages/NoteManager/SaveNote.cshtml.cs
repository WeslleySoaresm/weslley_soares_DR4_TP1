using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string? FileName { get; private set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileName = $"note-{timestamp}.txt";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", FileName);
            await System.IO.File.WriteAllTextAsync(path, Input.Content);

            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conteúdo da nota é obrigatório.")]
            public string Content { get; set; }
        }
    }
}
