using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public ResetPasswordModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostResetPassword(ResetPasswordViewModel model)
        {
            var result = _accountApplication.ResetPassword(model);
            if (!result.IsSuccedded)
                return RedirectToPage("/Index");

            return RedirectToPage("/Account");
        }
    }
}
