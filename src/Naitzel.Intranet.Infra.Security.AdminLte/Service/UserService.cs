using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Naitzel.Intranet.Domain.AdminLte.Common;
using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Extension;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        private readonly IValidation<User> _validation;

        public UserService(UserManager<User> userManager, IValidation<User> validation)
        {
            _userManager = userManager;
            _validation = validation;
        }

        public async Task<ValidationResult> AddAsync(User entity, CancellationToken token = default(CancellationToken))
        {
            var iValidation = _validation.ValidateOnCreate(entity);
            if (iValidation != null && !iValidation.IsValid)
                return iValidation;

            var result = await _userManager.CreateAsync(entity, entity.Password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(entity, new Claim(CustomClaimTypes.GivenName, entity.FirstName));
                await _userManager.AddClaimAsync(entity, new Claim(CustomClaimTypes.Surname, entity.LastName));
                await _userManager.AddClaimAsync(entity, new Claim(CustomClaimTypes.AvatarURL, entity.AvatarURL ?? "/images/user.png"));
            }

            return Resolve(result);
        }

        public Task<IEnumerable<User>> AllAsync(CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return _userManager.Users.ToListAsync().AsEnumerableAsync();
        }

        public async Task<ValidationResult> DeleteAsync(User entity, CancellationToken token = default(CancellationToken))
        {
            return Resolve(await _userManager.DeleteAsync(entity));
        }

        public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate, CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return _userManager.Users.Where(predicate).ToListAsync().AsEnumerableAsync();
        }

        public Task<User> FindByEmailAsync(string param, CancellationToken token = default(CancellationToken))
        {
            return _userManager.FindByEmailAsync(param);
        }

        public Task<User> FindByIdAsync(int param, CancellationToken token = default(CancellationToken))
        {
            return _userManager.FindByIdAsync(param.ToString());
        }

        public Task<User> FindByLoginAsync(string param, CancellationToken token = default(CancellationToken))
        {
            return _userManager.FindByEmailAsync(param);
        }

        public Task<User> FindByNameAsync(string param, CancellationToken token = default(CancellationToken))
        {
            return _userManager.FindByNameAsync(param);
        }

        public Task<User> GetAsync(int param, CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return _userManager.FindByIdAsync(param.ToString());
        }

        public async Task<ValidationResult> UpdateAsync(User entity, CancellationToken token = default(CancellationToken))
        {
            var iValidation = _validation.ValidateOnUpdate(entity);
            if (iValidation != null && !iValidation.IsValid)
                return iValidation;

            return Resolve(await _userManager.UpdateAsync(entity));
        }

        private ValidationResult Resolve(IdentityResult response)
        {
            return (
                response.Succeeded ?
                new ValidationResult() :
                new ValidationResult(
                    response.Errors
                    .Select(i => new ValidationFailure(i.Description))
                    .ToList()
                )
            );
        }
    }
}