using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } = new()
        {
            "Rio",
            "São Paulo",
            "Brasília"
        };
    }
}
