using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class EmailConfirmationModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public EmailConfirmationModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostEmailConfirmation(RegisterAccount command)
        {
            var result = _accountApplication.EmailConfirmation(command);
            if (!result.IsSuccedded)
                return RedirectToPage("/Index");

            return RedirectToPage("/Account");
        }
    }
}
