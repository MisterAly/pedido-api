using FluentValidation;
using PedidoAPI.Models;

namespace PedidoAPI.Validations
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(p => p.Cliente)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .Length(2, 100).WithMessage("O nome do cliente deve ter entre 2 e 100 caracteres.");

            RuleForEach(p => p.Itens).SetValidator(new ItemPedidoValidator());
        }
    }
}
