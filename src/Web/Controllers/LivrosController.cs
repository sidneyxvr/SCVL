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
        public ActionResult Index(string message)
        {
            if(message != null)
            {
                if(message == "VendaSucesso")
                {
                    ViewBag.PurchaseSuccess = "Compra realizada com sucesso";
                }
                else
                {
                    ViewBag.UserCreated = "Usuário cadastrado";
                }
            }
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
            var anuncio = _anuncioService.GetById((int)id);
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
            venda.Avaliacao = 0;
            if(ModelState.IsValid)
            {
                _vendaService.Add(Mapper.Map<VendaViewModel, Venda>(venda));
                return RedirectToAction("Index", "Livros", new { message = "VendaSucesso" });
                //return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        public ActionResult ListarPorCategoria(string id)
        {
            ViewBag.Categorias = _anuncioService.GetAllCategory();
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_anuncioService.GetByCategory(id)));
        }

        public ActionResult Vendas()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var vendas = _vendaService.GetBySeller(userId);
            if(vendas == null)
            {
                return NotFound();
            }
            ViewBag.Avaliacao = _vendaService.RateById(userId).ToString().Replace(',', '.'); 
            ViewBag.Status = StatusVenda.GetStatusVenda();
            ViewBag.FormaPagamento = FormaPagamento.GetFormaPagamento();
            return View(Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(vendas));
        }

        public ActionResult Pedidos()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var vendas = _vendaService.GetByCustomer(userId);
            if (vendas == null)
            {
                return NotFound();
            }
            ViewBag.Status = StatusVenda.GetStatusVenda();
            ViewBag.FormaPagamento = FormaPagamento.GetFormaPagamento();
            return View(Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(vendas));
        }


        public ActionResult AvaliarVendedor(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vendas = _vendaService.GetById((int)id);
            if (vendas == null)
            {
                return NotFound();
            }
            ViewBag.Status = StatusVenda.GetStatusVenda();
            ViewBag.FormaPagamento = FormaPagamento.GetFormaPagamento();
            return View(Mapper.Map<Venda, VendaViewModel>(vendas));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AvaliarVendedor(int? id, VendaViewModel venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }
            _vendaService.UpdateSellerStatus(venda.Id, venda.Avaliacao);
            return RedirectToAction(nameof(Pedidos));
        }

        public ActionResult AtualizarStatus(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.Status = StatusVenda.GetStatusVenda();
            ViewBag.FormaPagamento = FormaPagamento.GetFormaPagamento();
            return View(Mapper.Map<Venda, VendaViewModel>(_vendaService.GetById((int)id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarStatus(int? id, VendaViewModel venda)
        {
            if (id == null)
            {
                return NotFound();
            }
            _vendaService.UpdateStatus(Mapper.Map<VendaViewModel, Venda>(venda));
            return RedirectToAction(nameof(Vendas));
        }

        public ActionResult Pesquisar(string pesquisar)
        {
            ViewBag.Categorias = _anuncioService.GetAllCategory();
            return View(Mapper.Map<IEnumerable<Anuncio>, IEnumerable<AnuncioViewModel>>(_anuncioService.Search(pesquisar)));
        }
    }
}