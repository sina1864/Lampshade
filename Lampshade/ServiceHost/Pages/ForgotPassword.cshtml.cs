using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public ForgotPasswordModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostForgotPassword(ForgotPassword command)
        {
            var result = _accountApplication.ForgotPassword(command);
            if (!result.IsSuccedded)
                return RedirectToPage("/Index");

            return RedirectToPage("/Account");
        }
    }
}
