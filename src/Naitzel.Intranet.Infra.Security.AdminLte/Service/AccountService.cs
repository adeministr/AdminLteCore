using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation.Validators;

using Microsoft.AspNetCore.Identity;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Service
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;

        private readonly IUserService _userService;

        public AccountService(SignInManager<User> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<ValidationResult> SignInAsync(string userName, string password, bool isPersistent = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var validator = new Regex(new EmailValidator().Expression, RegexOptions.IgnoreCase);

            // Verifica se é um e-mail
            if (!String.IsNullOrEmpty(userName) && validator.IsMatch(userName))
            {
                // Consutla usuário para converter
                var user = await _userService.FindByEmailAsync(userName);

                if (user == null)
                    return new ValidationResult("UserName or Password invalid.");

                userName = user.UserName;
            }

            // Verifica usuário e senha
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure : true);

            if (result.Succeeded)
                return new ValidationResult();

            if (result.IsLockedOut)
                return new ValidationResult("Account user is locked.");

            return new ValidationResult("UserName or Password invalid.");
        }

        public Task SignOutAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _signInManager.SignOutAsync();

        public Task<ValidationResult> RegisterAsync(User entity, CancellationToken cancellationToken = default(CancellationToken)) =>
            _userService.AddAsync(entity);

        public Task<ValidationResult> UnregisterAsync(User entity, CancellationToken cancellationToken = default(CancellationToken)) =>
            _userService.DeleteAsync(entity);
    }
}