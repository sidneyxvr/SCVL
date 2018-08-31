using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Enum;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Web.ViewModels;

namespace Web.Controllers
{
    public class LivrosController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly IUsuarioService _usuarioService;
        private readonly IVendaService _vendaService;

        public LivrosController(IAnuncioService anuncioService, IUsuarioService usuarioService, IVendaService vendaService)
        {
            _anuncioService = anuncioService;
            _usuarioService = usuarioService;
            _vendaService = vendaService;
        }

        // GET: Livros
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Tuple<string, IEnumerable<Anuncio>>>,
                                   List<Tuple<string, IEnumerable<AnuncioViewModel>>>>(_anuncioService.GetGroupByCategory(3)));
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var anuncio = _anuncioService.GetById((int)id);
            if(anuncio == null)
            {
                return NotFound();
            }
            
            ViewBag.Avaliacao = _vendaService.RateById(anuncio.UsuarioId).ToString().Replace(',', '.');
            return View(Mapper.Map<Anuncio, AnuncioViewModel>(anuncio));
        }

        [Authorize]
        public ActionResult Comprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anuncio = _anuncioService .GetById((int)id);
            if(anuncio == null)
            {
                return NotFound();
            }
            ViewBag.FormaPagamento = FormaPagamento.GetFormaPagamento();
            var cliente = _usuarioService.GetById(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var venda = new Venda { VendedorId = anuncio.UsuarioId, ClienteId = cliente.Id, Cliente = cliente,
                                    Anuncio = anuncio, AnuncioId = anuncio.Id, Vendedor = anuncio.Usuario };
            return View(Mapper.Map<Venda, VendaViewModel>(venda));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comprar(int id, VendaViewModel venda)
        {
            if(ModelState.IsValid)
            {
                _vendaService.Add(Mapper.Map<VendaViewModel, Venda>(venda));
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        public ActionResult ListarPorCategoria(string id)
        {
            var v = id;
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_anuncioService.GetByCategory(id)));
        }
    }
}