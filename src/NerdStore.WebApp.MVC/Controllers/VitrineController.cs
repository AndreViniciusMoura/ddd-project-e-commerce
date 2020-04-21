using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class VitrineController : Controller
    {
        #region Propriedades

        private readonly IProdutoAppService _produtoAppService;

        #endregion

        #region Construtor

        public VitrineController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _produtoAppService.ObterPorId(id));
        }

        #endregion
    }
}
