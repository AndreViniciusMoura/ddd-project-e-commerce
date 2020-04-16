using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        #region Propriedades

        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        #endregion

        #region Construtor

        public Message()
        {
            MessageType = GetType().Name;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
