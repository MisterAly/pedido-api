using FluentValidation;
using PedidoAPI.Models;

namespace PedidoAPI.Validations
{
    public class ItemPedidoValidator : AbstractValidator<ItemPedido>
    {
        public ItemPedidoValidator()
        {
            RuleFor(i => i.Produto)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do produto deve ser um valor positivo.");

            RuleFor(i => i.Preco)
                .GreaterThan(0).WithMessage("O preço do produto deve ser um valor positivo.");
        }
    }
}
