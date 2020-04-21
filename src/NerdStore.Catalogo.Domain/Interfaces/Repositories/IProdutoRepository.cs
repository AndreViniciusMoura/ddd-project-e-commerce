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
        void Adicionar(Produto produto);

        void Atualizar(Produto produto);

        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
    }
}
