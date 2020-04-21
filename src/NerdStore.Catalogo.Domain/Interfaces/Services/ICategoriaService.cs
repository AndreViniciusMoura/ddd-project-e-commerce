using NerdStore.Catalogo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task Adicionar(Categoria categoria);

        Task Atualizar(Categoria categoria);

        Task<IEnumerable<Categoria>> ObterTodos();

        Task<Categoria> ObterPorId(Guid id);
    }
}
