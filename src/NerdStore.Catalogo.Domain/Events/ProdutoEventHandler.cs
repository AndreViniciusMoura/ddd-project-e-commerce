using MediatR;
using NerdStore.Catalogo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        #region Propriedades

        private readonly IProdutoRepository _produtoRepository;

        #endregion

        #region Contrutor

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        #endregion

        #region Metodos

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            //Enviar um email para aquisicao de mais produto
            //O que vc irá implementar para o processo que vc precisa.
        }

        #endregion
    }
}
