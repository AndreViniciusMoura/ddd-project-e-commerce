using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NerdStore.Catalogo.Application.Services.Interfaces;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        #region Propriedades

        private readonly IProdutoService _produtoService;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor

        public ProdutoAppService(IProdutoService produtoService,
                                 IEstoqueService estoqueService,
                                 IMapper mapper)
        {
            _produtoService = produtoService;
            _estoqueService = estoqueService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        public async Task Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoService.Adicionar(produto);
        }

        public async Task Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoService.Atualizar(produto);
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos());
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao debitar estoque.");
            }

            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
            {
                throw new DomainException("Falha ao repor estoque.");
            }

            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }

        #endregion
    }
}
