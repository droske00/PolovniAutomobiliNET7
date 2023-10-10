using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.Automobili
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration; //Kada zelimo da pristupimo nekom konfiguracionom fajlu, ukljucujemo interfejs IConfiguration.

        private readonly IAutomobilData _automobilData;

        public string Message { get; set; }

        public IEnumerable<Automobil> Cars { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IAutomobilData automobilData) 
        {
            _configuration = configuration;
            _automobilData = automobilData;         
        }

        public void OnGet() //Model Binding, name atribut iz inputa prosledjujemo kao ulazni parametar
        {
            Message = _configuration["Message"]; 
            Cars = _automobilData.GetCarsByName(SearchTerm);
        }
    }
}
