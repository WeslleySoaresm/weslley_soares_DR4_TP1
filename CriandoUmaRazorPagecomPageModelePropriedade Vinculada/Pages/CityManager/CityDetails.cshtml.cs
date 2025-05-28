using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriandoUmaRazorPagecomPageModelePropriedade_Vinculada.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string? CityName { get; set; }

        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
