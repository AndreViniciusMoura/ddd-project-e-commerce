using MediatR;
using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.bus
{
    public class MediatrHandler: IMediatrHandler
    {
        #region Propriedades

        private readonly IMediator _mediator;

        #endregion

        #region Contrutor

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Metodos

        public async Task PublicarEvento<T>(T evento) where T: Event
        {
            await _mediator.Publish(evento);
        }

        #endregion
    }
}
