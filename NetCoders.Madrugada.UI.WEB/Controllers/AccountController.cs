using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Service.Interface;
using NetCoders.Madrugada.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetCoders.Madrugada.UI.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public AccountController(IUsuarioService usuarioService_)
        {
            _usuarioService = usuarioService_;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            var model = new UsuarioViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            //var usuario = _usuarioService.Find(x => x.Nome == model.Nome && x.Senha == model.Senha).First();

            var usuario = new Usuario()
            {
                Nome = "Felipe",
                Role = "Admin",
                Senha = "12345"
            };

            //verifica se a Role existe, caso não existir, preciso cria-la, se não, não tem como usar né!!
            if (!Roles.RoleExists(usuario.Role))
            {
                //Criando a Role.. Ela vai criar lá no IIS!!
                Roles.CreateRole(usuario.Role);
            }

            //verifica se o usuário já possui regras...
            if (Roles.GetRolesForUser(usuario.Nome).Length > 0)
            {
                //remove o usuário dessa regra...
                Roles.RemoveUserFromRoles(usuario.Nome, Roles.GetRolesForUser(usuario.Nome));
            }

            //adiciono o usuário a regra que foi criada lá no IIS
            Roles.AddUserToRole(usuario.Nome, usuario.Role);


            FormsAuthentication.SetAuthCookie(usuario.Nome, true);
            //return RedirectToAction("Listar", "Pessoas", new { Area = "" });

            return View();
        }
    }
}