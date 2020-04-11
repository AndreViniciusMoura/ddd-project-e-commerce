using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        Task<IEnumerable<Categoria>> ObterCategorias();

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        #region Produto

        void Adicionar(Produto produto);

        void Atualizar(Produto produto);

        #endregion

        #region Categoria

        void Adicionar(Categoria categoria);

        void Atualizar(Categoria categoria);

        #endregion
    }
}
