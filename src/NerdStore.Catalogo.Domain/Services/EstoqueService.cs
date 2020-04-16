using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using NerdStore.Catalogo.Domain.Interfaces.Services;
using NerdStore.Core.bus;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        #region Propriedades

        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        #endregion

        #region Construtor

        public EstoqueService(IProdutoRepository produtoRepository,
                              IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        #endregion

        #region Metodos

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto is null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            //TODO: Parametrizar a quantidade de estoque baixo
            if (produto.QtdEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QtdEstoque));
            }

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto is null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        #endregion
    }
}
