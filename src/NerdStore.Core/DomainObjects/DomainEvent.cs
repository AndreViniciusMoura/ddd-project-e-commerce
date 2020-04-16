using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.DomainObjects
{
    public class DomainEvent : Event
    {
        #region Propriedades

        #endregion

        #region Construtor

        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
