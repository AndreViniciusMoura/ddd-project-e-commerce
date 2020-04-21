using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Services
{
    public class ProdutoService : IProdutoService, IDisposable
    {
        #region Propriedades

        private readonly IProdutoRepository _produtoRepository;

        #endregion

        #region Contrutor

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        #endregion

        #region Metodos
        public async Task Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(Produto produto)
        {
            _produtoRepository.Atualizar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _produtoRepository.ObterPorCategoria(codigo);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        #endregion
    }
}
