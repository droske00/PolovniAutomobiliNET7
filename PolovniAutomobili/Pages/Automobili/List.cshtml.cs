using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.Automobili
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IAutomobilData _automobilData;

        public string Message { get; set; }

        public IEnumerable<Automobil> Cars { get; set; }

        public ListModel(IConfiguration configuration, IAutomobilData automobilData) 
        {
            _configuration = configuration;
            _automobilData = automobilData;         
        }

        public void OnGet()
        {
            Message = _configuration["Message"];
            Cars = _automobilData.GetAll();
        }
    }
}
