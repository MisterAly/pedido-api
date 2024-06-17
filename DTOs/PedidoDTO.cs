namespace PedidoAPI.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public required string Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public required List<ItemPedidoDto> Itens { get; set; }
    }
}
