using _01_LampshadeQuery.Contracts.Account;
using AccountManagement.Application.Contracts.Account;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ServiceHost.Pages
{
    [ValidateReCaptcha]
    public class AccountModel : PageModel
    {
        //public AccountQueryModel AccountQueryModel;

        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "رمز عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "موبایل را وارد کنید")]
        public string Mobile { get; set; }

        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");
            LoginMessage = result.Message;
            return RedirectToPage("/Account");
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if (result.IsSuccedded)
                return Redirect("/EmailConfirmation" + "?email=" + command.Email);
            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
    }
}
