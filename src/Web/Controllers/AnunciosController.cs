using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioService _service;
        private readonly IImagemService _imagemService;

        public AnunciosController(IAnuncioService service, IImagemService imagemService)
        {
            _service = service;
            _imagemService = imagemService;
        }

        // GET: Anuncios
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_service.GetAll().Where(i => i.Ativo == true)));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = _service.GetById((int)id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(Mapper.Map<Anuncio, AnuncioViewModel>(anuncio));
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnuncioViewModel anuncio, List<IFormFile> imagens)
        {
            if(ModelState.IsValid)
            {
                var anc = _service.Add(Mapper.Map<AnuncioViewModel, Anuncio>(anuncio));
                _imagemService.Add(imagens, anc.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var anuncio = _service.GetById((int)id);

            if(anuncio == null)
            {
                return NotFound();
            }
            return View(Mapper.Map<Anuncio, AnuncioViewModel>(anuncio));
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnuncioViewModel anuncio)
        {
            if(id != anuncio.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _service.Update(Mapper.Map<AnuncioViewModel, Anuncio>(anuncio));
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException)
                {
                    return View(anuncio);
                }
            }
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var anuncio = _service.GetById((int)id);
            if(anuncio == null)
            {
                return NotFound();
            }
            return View(Mapper.Map<Anuncio, AnuncioViewModel>(anuncio));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult EditImage(int? id, int? anuncioId)
        {
            if(id == null)
            {
                return NotFound();
            }
            if (id == -1)
            {
                var v = anuncioId;
                return View(new ImagemViewModel { Id = (int)id, AnuncioId = (int)anuncioId });
            }
            var imagem = _imagemService.GetById((int)id);
            if(imagem == null)
            {
                return NotFound();
            }
            return View(Mapper.Map<Imagem, ImagemViewModel>(imagem));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImage(int id, ImagemViewModel imagem ,IFormFile imagemForm)
        {
            if (id == -1)
            {
                List<IFormFile> list = new List<IFormFile> { imagemForm };
                _imagemService.Add(list, imagem.AnuncioId);
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _imagemService.Update(imagemForm, Mapper.Map<ImagemViewModel, Imagem>(imagem));
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(imagem);
                }
            }
            return View(imagem);
        }

        public ActionResult DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var imagem = _imagemService.GetById((int)id);
            if (imagem == null)
            {
                return NotFound();
            }
            return View(Mapper.Map<Imagem, ImagemViewModel>(imagem));
        }

        [HttpPost, ActionName("DeleteImage")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteImageConfirmed(int id)
        {
            var imagem = _imagemService.GetById(id);
            _imagemService.Remove(imagem);
            return RedirectToAction(nameof(Index));
        }
    }
}