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
            var teste = _ficanteService.Read();

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
            var model = TypeAdapter.Adapt<Ficante, FicanteViewModel>(_ficanteService.Find(x => x.idFicante == id).First());
            model.Telefones = TypeAdapter.Adapt<IList<Telefone>, IList<TelefoneViewModel>>(_telefoneService.Find(x => x.idFicante == id));

            TempData["Telefones"] = model.Telefones;

            return View(model);
        }

        // POST: Ficante/Edit/5
        [HttpPost]
        public ActionResult Edit(FicanteViewModel model_)
        {
            var telefonesMemoria = TempData["Telefones"] as List<TelefoneViewModel>;

            try
            {
                var ficante = TypeAdapter.Adapt<FicanteViewModel, Ficante>(model_);

                foreach (var item in ficante.Telefones.Where(x => x.idFicante != 0))
                {
                    _telefoneService.Update(item);
                }

                foreach (var item in ficante.Telefones.Where(x => x.idFicante == 0))
                {
                    item.idFicante = model_.idFicante;
                    _telefoneService.Create(item);
                }

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
                var ficante = _ficanteService.Find(x => x.idFicante == id).FirstOrDefault();

                foreach (var item in _telefoneService.Find(x => x.idFicante == id))
                {
                    _telefoneService.Remove(item);
                }

                _ficanteService.Remove(ficante);
                
                
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
