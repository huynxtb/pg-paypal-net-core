using CodeMegaPayPal.Models;

namespace CodeMegaPayPal.Services;
public interface IPayPalService
{
    Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
}