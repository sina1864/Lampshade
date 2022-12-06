using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class Login
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(16, ErrorMessage = ValidationMessages.InvalidUsernameLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.]", ErrorMessage = ValidationMessages.InvalidUsernameType)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(255, ErrorMessage = ValidationMessages.InvalidPasswordLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.@]", ErrorMessage = ValidationMessages.InvalidPasswordType)]
        public string Password { get; set; }
    }
}
