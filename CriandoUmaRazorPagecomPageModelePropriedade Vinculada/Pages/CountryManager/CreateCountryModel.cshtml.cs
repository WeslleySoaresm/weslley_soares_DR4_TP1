using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Nome do país é obrigatório.")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "Código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; }
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Validação customizada
            if (!string.IsNullOrEmpty(Input.CountryName) &&
                !string.IsNullOrEmpty(Input.CountryCode))
            {
                if (char.ToUpper(Input.CountryName[0]) != char.ToUpper(Input.CountryCode[0]))
                {
                    ModelState.AddModelError("Input.CountryCode",
                        "O código do país deve começar com a mesma letra do nome do país.");
                    return Page();
                }
            }

            // Aqui você pode salvar ou redirecionar
            return RedirectToPage("Success");
        }
    }
}
