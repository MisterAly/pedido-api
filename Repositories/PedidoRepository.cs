using Microsoft.EntityFrameworkCore;
using PedidoAPI.Data;
using PedidoAPI.Models;

namespace PedidoAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await _context.Pedidos.Include(p => p.Itens).ToListAsync();
        }

        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            var pedido = await _context
                .Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pedido ?? throw new Exception("Pedido not found.");
        }

        public async Task<Pedido> AddPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> UpdatePedidoAsync(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(pedido.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return false;
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
