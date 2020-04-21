using NerdStore.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services.Interfaces
{
    public interface ICategoriaAppService
    {
        Task Adicionar(CategoriaViewModel categoriaViewModel);

        Task Atualizar(CategoriaViewModel categoriaViewModel);

        Task<CategoriaViewModel> ObterPorId(Guid id);

        Task<IEnumerable<CategoriaViewModel>> ObterTodos();
    }
}
