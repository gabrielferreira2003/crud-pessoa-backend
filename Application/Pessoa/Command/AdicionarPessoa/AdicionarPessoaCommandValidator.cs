using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.AdicionarPessoa
{
    public class AdicionarPessoaCommandValidator : AbstractValidator<AdicionarPessoaCommand>
    {
        public AdicionarPessoaCommandValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty()
                .Length(50)
                .WithMessage("O nome é muito grande inválido");

            RuleFor(x => x.Email).NotNull().NotEmpty()
                .Length(70)
                .EmailAddress()
                .WithMessage("O endereço de email informado é inválido");
        }
    }
}
