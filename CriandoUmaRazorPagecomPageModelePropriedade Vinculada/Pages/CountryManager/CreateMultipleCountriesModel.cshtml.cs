using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages.CountryManager
{
    public class CreateMultipleCountriesModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Countries { get; set; } = new();

        public List<Country> SubmittedCountries { get; private set; } = new();

        public void OnGet()
        {
            // Garante 5 entradas para preencher
            for (int i = Countries.Count; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            foreach (var input in Countries)
            {
                SubmittedCountries.Add(new Country
                {
                    CountryName = input.CountryName,
                    CountryCode = input.CountryCode
                });
            }

            // Garante manter as 5 entradas após o post
            for (int i = Countries.Count; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Nome do país é obrigatório.")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "Código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
            public string CountryCode { get; set; }
        }

        public class Country
        {
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
        }
    }
}
