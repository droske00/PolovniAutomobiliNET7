using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PolovniAutomobili.Core;
using PolovniAutomobili.Data;
using static PolovniAutomobili.Core.Enums;

namespace PolovniAutomobili.Pages.Automobili
{
    public class EditModel : PageModel
    {
        private readonly IAutomobilData _automobiliData;

        private IHtmlHelper _htmlHelper { get; }

        public IEnumerable<SelectListItem> Goriva { get; set; }

        [BindProperty]
        public Automobil Car { get; set; }

        public EditModel(IAutomobilData automobiliData, IHtmlHelper htmlHelper)
        {
            _automobiliData = automobiliData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? carId)
        {
            Car = new Automobil();
            if (carId.HasValue) 
            {
                Car = _automobiliData.GetById(carId.Value);
            }

            Goriva = _htmlHelper.GetEnumSelectList<GorivoVrsta>();
            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Car.Id > 0)
                {
                    Car = _automobiliData.Update(Car);
                }
                else
                {
                    Car = _automobiliData.Add(Car);
                }
                Car = _automobiliData.Update(Car);
                // _automobiliData.Commit();
                TempData["Message"] = "Izmene su uspesno sacuvane";
                return RedirectToPage("./Detail", new { carId = Car.Id });
            }         

            Goriva = _htmlHelper.GetEnumSelectList<GorivoVrsta>();
            if (Car == null) 
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


    }
}
