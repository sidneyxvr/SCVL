using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class LivrosController : Controller
    {
        private readonly IAnuncioService _service;

        public LivrosController(IAnuncioService service)
        {
            _service = service;
        }

        // GET: Livros
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_service.GetAll().Where(a => a.Ativo == true)));
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
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
    }
}