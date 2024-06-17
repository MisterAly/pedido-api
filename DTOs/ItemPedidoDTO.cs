namespace PedidoAPI.DTOs
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public required string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
