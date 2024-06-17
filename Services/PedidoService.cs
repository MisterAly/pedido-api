using PedidoAPI.Models;
using PedidoAPI.Repositories;

namespace PedidoAPI.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return _pedidoRepository.GetPedidosAsync();
        }

        public Task<Pedido> GetPedidoByIdAsync(int id)
        {
            return _pedidoRepository.GetPedidoByIdAsync(id);
        }

        public Task<Pedido> AddPedidoAsync(Pedido pedido)
        {
            return _pedidoRepository.AddPedidoAsync(pedido);
        }

        public Task<bool> UpdatePedidoAsync(Pedido pedido)
        {
            return _pedidoRepository.UpdatePedidoAsync(pedido);
        }

        public Task<bool> DeletePedidoAsync(int id)
        {
            return _pedidoRepository.DeletePedidoAsync(id);
        }
    }
}
