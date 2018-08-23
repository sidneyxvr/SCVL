using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioService _service;

        public AnunciosController(IAnuncioService service)
        {
            _service = service;
        }

        // GET: Anuncios
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_service.GetAll().Where(i => i.Ativo == true)));
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel anuncio)
        {
            try
            {
                // TODO: Add insert logic here
                _service.Add(Mapper.Map<AnuncioViewModel, Anuncio>(anuncio));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnuncioViewModel anuncio)
        {
            try
            {
                // TODO: Add update logic here
                _service.Update(Mapper.Map<AnuncioViewModel, Anuncio>(anuncio));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Anuncio, AnuncioViewModel>(_service.GetById(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}