using System.ComponentModel.DataAnnotations;

namespace _01_LampshadeQuery.Contracts.Account
{
    public class AccountQueryModel
    {
        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        //[StringLength(16, ErrorMessage = ValidationMessages.InvalidUsernameLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.]", ErrorMessage = ValidationMessages.InvalidUsernameType)]
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }


        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        //[StringLength(255, ErrorMessage = ValidationMessages.InvalidPasswordLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.@]", ErrorMessage = ValidationMessages.InvalidPasswordType)]
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "رمز عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        //[StringLength(50, ErrorMessage = ValidationMessages.InvalidEmailLength, MinimumLength = 8)]
        //[RegularExpression("^[a-zA-Z0-9_.]+@[a-z]+\\.[a-z]{2,3}$", ErrorMessage = ValidationMessages.InvalidEmailType)]
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        public string Email { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        //[StringLength(20, ErrorMessage = ValidationMessages.InvalidMobileLength, MinimumLength = 11)]
        //[RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = ValidationMessages.InvalidMobileType)]
        [Required(ErrorMessage = "موبایل را وارد کنید")]
        public string Mobile { get; set; }
    }
}
