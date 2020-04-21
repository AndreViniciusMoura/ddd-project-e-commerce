using NerdStore.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
    }
}
