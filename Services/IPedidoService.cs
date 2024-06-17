using PedidoAPI.Models;
using PedidoAPI.Repositories;

namespace PedidoAPI.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task<Pedido> AddPedidoAsync(Pedido pedido);
        Task<bool> UpdatePedidoAsync(Pedido pedido);
        Task<bool> DeletePedidoAsync(int id);
    }
}
