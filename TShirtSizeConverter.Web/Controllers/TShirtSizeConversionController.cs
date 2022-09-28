using Microsoft.AspNetCore.Mvc;
using TShirtSizeConverter.Lib;
using TShirtSizeConverter.Web.Models;

namespace TShirtSizeConverter.Web.Controllers
{
    public class TShirtSizeConversionController : Controller
    {
        private readonly IConversionService _conversionService;

        public TShirtSizeConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService ??
                throw new ArgumentNullException(nameof(conversionService));
        }

        // GET: TShirtSizeController/Create
        public ActionResult Create()
        {
            return View(new TShirtSizeConversion());
        }

        // POST: TShirtSizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var model = new TShirtSizeConversion();
            await TryUpdateModelAsync(model);
            if (model == null) return NotFound();
            model.Output = _conversionService.Convert(model!.Input?.ToString() ?? "");
            return View("Details", model);
        }
    }
}
