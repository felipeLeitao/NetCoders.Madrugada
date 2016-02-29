using NetCoders.Madrugada.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastMapper;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.UI.WEB.ViewModel;
using NetCoders.Madrugada.Service.Interface;

namespace NetCoders.Madrugada.UI.WEB.Controllers
{
    public class FicanteController : Controller
    {
        private readonly IFicanteService _ficanteService;
        private readonly ITelefoneService _telefoneService;

        public FicanteController(IFicanteService ficanteService_, ITelefoneService telefoneService_)
        {
            _ficanteService = ficanteService_;
            _telefoneService = telefoneService_;
        }

        // GET: Ficante
        public ActionResult Index()
        {
            var model = TypeAdapter.Adapt<IList<Ficante>, IList<FicanteViewModel>>(_ficanteService.Read());
            return View(model);
        }

        // GET: Ficante/Create
        public ActionResult Cadastrar()
        {
            var model = new FicanteViewModel();
            return View(model);
        }

        // POST: Ficante/Create
        [HttpPost]
        public ActionResult Cadastrar(FicanteViewModel model_)
        {
            try
            {
                var ficante = TypeAdapter.Adapt<FicanteViewModel, Ficante>(model_);

                ficante.Telefones = TypeAdapter.Adapt<ICollection<TelefoneViewModel>, ICollection<Telefone>>(model_.TelefonesViewModel);

                _ficanteService.Create(ficante);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model_);
            }
        }

        // GET: Ficante/Edit/5
        public ActionResult Edit(int id)
        {
            var ficante = _ficanteService.Find(x => x.Codigo == id).First();

            var model = TypeAdapter.Adapt<Ficante, FicanteViewModel>(ficante);

            model.TelefonesViewModel = TypeAdapter.Adapt<ICollection<Telefone>, IList<TelefoneViewModel>>(ficante.Telefones);

            TempData["Telefones"] = model.TelefonesViewModel;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FicanteViewModel model_)
        {
            //Isso daqui vai me ajudar a ver quais telefones foram excluidos. Eu poderia pensar em por uma flag em TelefoneViewModel e virar ela
            //quando for pra excluir, mas to com preguiça...

            var telefonesMemoria = TempData["Telefones"] as List<TelefoneViewModel>;

            try
            {
                var ficante = TypeAdapter.Adapt<FicanteViewModel, Ficante>(model_);

                ficante.Telefones = TypeAdapter.Adapt<ICollection<TelefoneViewModel>, ICollection<Telefone>>(model_.TelefonesViewModel);

                _ficanteService.Update(ficante);

                return RedirectToAction("Index");
            }

            catch
            {
                TempData["Telefones"] = telefonesMemoria;
                return View(model_);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _ficanteService.Remove(_ficanteService.Find(x => x.Codigo == id).FirstOrDefault()); 
            }
            catch (Exception)
            {
                TempData["ERRO"] = "Falha ao excluir";
            }

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public PartialViewResult AdicionaTelefone()
        {
            return PartialView("EditorTemplates/TelefoneViewModel");
        }
    }
}
