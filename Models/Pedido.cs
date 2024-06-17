namespace PedidoAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public required string Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public required ICollection<ItemPedido> Itens { get; set; }
    }
}
