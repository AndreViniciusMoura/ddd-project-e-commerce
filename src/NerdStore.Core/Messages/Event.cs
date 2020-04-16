using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        #region Propriedades

        public DateTime Timestamp { get; private set; }

        #endregion

        #region Construtor

        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
