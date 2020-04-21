using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Adicionar(Categoria categoria);

        void Atualizar(Categoria categoria);

        Task<IEnumerable<Categoria>> ObterTodos();

        Task<Categoria> ObterPorId(Guid id);
    }
}
