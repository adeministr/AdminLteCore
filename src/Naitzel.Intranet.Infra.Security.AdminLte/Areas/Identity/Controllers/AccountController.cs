using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Validation;
using Naitzel.Intranet.Infra.Security.AdminLte.ViewModel;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Controllers
{
    [Authorize]
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service) => _service = service;

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(CancellationToken token, string returnUrl = null)
        {
            await _service.SignOutAsync(token);
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CancellationToken token, LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {

                var result = await _service.SignInAsync(model.Email, model.Password, model.RememberMe, token);

                if (result.IsValid) return RedirectToLocal(returnUrl);

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(
            [FromServices] IUserService userService, //
            [FromServices] SignInManager<User> signInManager, //
            [FromServices] IMapper mapper,
            RegisterViewModel model,
            string returnUrl = null
        )
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(model);
                var result = await userService.AddAsync(user);

                if (result.IsValid)
                {
                    await _service.SignInAsync(user.UserName, user.Password);
                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();

        [NonAction]
        protected virtual void AddErrors(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName ?? string.Empty, error.ErrorMessage);
            }
        }

        [NonAction]
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}