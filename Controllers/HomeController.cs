using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodeMegaPayPal.Models;
using CodeMegaPayPal.Services;

namespace CodeMegaPayPal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPayPalService _payPalService;

        public HomeController(IPayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = await _payPalService.CreatePaymentUrl(model, HttpContext);
            
            return Redirect(url);
        }
        
        public IActionResult PaymentCallback()
        {
            var response = _payPalService.PaymentExecute(Request.Query);
            
            return Json(response);
        }
    }
}