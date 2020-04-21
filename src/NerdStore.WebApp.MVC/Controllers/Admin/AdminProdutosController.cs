using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        #region Propriedades

        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;

        #endregion

        #region Construtor

        public AdminProdutosController(IProdutoAppService produtoAppService,
                                       ICategoriaAppService categoriaAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoViewModel()));
        }

        [Route("novo-produto")]
        [HttpPost]
        public async Task<IActionResult> NovoProduto(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoViewModel));

            await _produtoAppService.Adicionar(produtoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoAppService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoViewModel produtoViewModel)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            produtoViewModel.QtdEstoque = produto.QtdEstoque;

            ModelState.Remove("QtdEstoque");

            if (!ModelState.IsValid) return View(await PopularCategorias(produtoViewModel));

            await _produtoAppService.Atualizar(produtoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }

            return View("Index", await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoViewModel> PopularCategorias(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Categorias = await _categoriaAppService.ObterTodos();

            return produtoViewModel;
        }

        #endregion
    }
}
