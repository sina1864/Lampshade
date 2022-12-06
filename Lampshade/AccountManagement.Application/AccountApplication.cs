using System;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountManagement.Domain.RoleAgg;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Security.Policy;
using _0_Framework.Application.Email;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public AccountApplication(IAccountRepository accountRepository, IEmailService emailService, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public AccountViewModel GetAccountBy(long id)
        {
            var account = _accountRepository.Get(id);
            return new AccountViewModel()
            {
                Email = account.Email,
                Mobile = account.Mobile
            };
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var emailConfirmCode = new Random().Next(1000, 9999);
            var account = new Account(command.Email, command.Username, password, command.Mobile, command.RoleId,
                picturePath, emailConfirmCode);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Email, command.Username, command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var permissions = _roleRepository.Get(account.RoleId)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Email
                , account.Username, account.Mobile, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public OperationResult ForgotPassword(ForgotPassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetUserAccountBy(command.Email);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var token = Guid.NewGuid().ToString();
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={command.Email}&token={validToken}";
            _emailService.SendEmail("Token", $"{url}", command.Email);
            //Console.WriteLine(url);

            account.SetToken(token);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult ResetPassword(ResetPasswordViewModel model)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetUserAccountBy(model.Email);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (model.NewPassword != model.ConfirmPassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            if(normalToken != account.ResetPasswordToken)
                return operation.Failed(ApplicationMessages.TokenNotMatch);

            var password = _passwordHasher.Hash(model.NewPassword);
            account.ChangePassword(password);
            account.RemoveToken();
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult EmailConfirmation(RegisterAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetUserAccountBy(command.Email);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.EmailConfirmCode != account.EmailConfirmCode)
                return operation.Failed(ApplicationMessages.TokenNotMatch);

            account.EmailConfirmed();
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}