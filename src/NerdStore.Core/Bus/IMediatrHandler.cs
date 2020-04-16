using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
