using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }
        public string ResetPasswordToken { get; private set; }
        public int EmailConfirmCode { get; private set; }
        public bool IsEmailConfirmed { get; private set; }

        public Account(string email, string username, string password, string mobile,
            long roleId, string profilePhoto, int emailConfirmCode)
        {
            Email = email;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 2;
            
            ProfilePhoto = profilePhoto;
            ResetPasswordToken = null;
            EmailConfirmCode = emailConfirmCode;
        }

        public void Edit(string email, string username, string mobile,
            long roleId, string profilePhoto)
        {
            Email = email;
            Username = username;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void SetToken(string resetPasswordToken)
        {
            ResetPasswordToken = resetPasswordToken;
        }

        public void RemoveToken()
        {
            ResetPasswordToken = null;
        }

        public void EmailConfirmed()
        {
            IsEmailConfirmed = true;
            EmailConfirmCode = 0;
        }
    }
}
