using NerdStore.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services.Interfaces
{
    public interface IProdutoAppService
    {
        Task Adicionar(ProdutoViewModel produtoViewModel);

        Task Atualizar(ProdutoViewModel produtoViewModel);

        Task<ProdutoViewModel> ObterPorId(Guid id);

        Task<IEnumerable<ProdutoViewModel>> ObterTodos();

        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

        Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);

        Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}
