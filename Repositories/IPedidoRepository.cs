using Microsoft.EntityFrameworkCore;
using PedidoAPI.Data;
using PedidoAPI.Models;

namespace PedidoAPI.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task<Pedido> AddPedidoAsync(Pedido pedido);
        Task<bool> UpdatePedidoAsync(Pedido pedido);
        Task<bool> DeletePedidoAsync(int id);
    }
}
