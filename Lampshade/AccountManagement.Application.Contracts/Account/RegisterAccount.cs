using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(50, ErrorMessage = ValidationMessages.InvalidEmailLength, MinimumLength = 8)]
        //[RegularExpression("^[a-zA-Z0-9_.]+@[a-z]+\\.[a-z]{2,3}$", ErrorMessage = ValidationMessages.InvalidEmailType)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(16, ErrorMessage = ValidationMessages.InvalidUsernameLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.]", ErrorMessage = ValidationMessages.InvalidUsernameType)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(255, ErrorMessage = ValidationMessages.InvalidPasswordLength, MinimumLength = 5)]
        //[RegularExpression("[a-zA-Z0-9_.@]", ErrorMessage = ValidationMessages.InvalidPasswordType)]
        public string Password { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [StringLength(20, ErrorMessage = ValidationMessages.InvalidMobileLength, MinimumLength = 11)]
        //[RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = ValidationMessages.InvalidMobileType)]
        public string Mobile { get; set; }

        public long RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public int EmailConfirmCode { get; set; }
    }
}
