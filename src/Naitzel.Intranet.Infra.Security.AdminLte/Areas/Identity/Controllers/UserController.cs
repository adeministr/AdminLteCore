using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Validation;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;
using Naitzel.Intranet.Infra.Security.AdminLte.ViewModel;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Areas.Identity.Controllers
{
    [Authorize]
    [Area("Identity")]
    [Route("[area]/[controller]/[action]")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IUserService service, CancellationToken cancellationToken)
        {
            AddBreadcrumb("Usuários", Url.Action(nameof(Index)));
            return View(await service.AllAsync(cancellationToken));
        }

        public IActionResult Create()
        {
            AddBreadcrumb("Lista", Url.Action(nameof(Index)));
            AddBreadcrumb("Cadastrar", Url.Action(nameof(Create)));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] IUserService service, //
            [FromServices] IMapper mapper, //
            [FromForm] UserCreateViewModel model)
        {
            AddBreadcrumb("Lista", Url.Action(nameof(Index)));
            AddBreadcrumb("Cadastrar", Url.Action(nameof(Create)));

            if (ModelState.IsValid)
            {
                var user = mapper.Map<User>(model);
                var result = await service.AddAsync(user);

                if (result.IsValid)
                {
                    return RedirectToAction("Index");
                }

                AddErrors(result);
            }

            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] IUserService service, //
            [FromServices] IMapper mapper, //
            int id)
        {
            var user = await service.FindByIdAsync(id);

            if (user == null) return RedirectToAction("Index");

            var model = mapper.Map<UserUpdateViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(
            [FromServices] IUserService service, //
            [FromServices] IMapper mapper, //
            [FromForm] UserUpdateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await service.FindByIdAsync(model.Id);
                if (user == null) return RedirectToAction("Index");

                var update = mapper.Map(model, user);
                var result = await service.UpdateAsync(update);

                if (result.IsValid)
                {
                    return RedirectToAction("Index");
                }

                AddErrors(result);
            }
            return View();
        }

        public IActionResult Disable([FromQuery] int id)
        {
            return RedirectToAction("Index");
        }

        [NonAction]
        protected virtual void AddErrors(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName ?? string.Empty, error.ErrorMessage);
            }
        }

        [NonAction]
        protected virtual void AddBreadcrumb(string displayName, string urlPath)
        {
            List<MessageViewModel> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<MessageViewModel>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<MessageViewModel>;
            }

            messages.Add(new MessageViewModel { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }
    }
}