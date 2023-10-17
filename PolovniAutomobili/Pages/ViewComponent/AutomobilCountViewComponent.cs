using Microsoft.AspNetCore.Mvc;
using PolovniAutomobili.Data;

namespace PolovniAutomobili.Pages.ViewComponents
{
    public class AutomobilCountViewComponent : ViewComponent
    {
        private readonly IAutomobilData _automobilData;

        public AutomobilCountViewComponent(IAutomobilData automobilData)
        {
            _automobilData = automobilData;
        }

        public IViewComponentResult Invoke() 
        {
            var count = _automobilData.GetCountOfCars;
            return View(count);
        }
    }
}
