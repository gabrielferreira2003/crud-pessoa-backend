using FluentValidation;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.EditarPessoa
{
    public class EditarPessoaCommandValidator : AbstractValidator<EditarPessoaCommand>
    {
        public EditarPessoaCommandValidator(Contexto contexto)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty()
                .MustAsync(async (_, id, cancelation) => await contexto.Pessoas.AnyAsync(x => x.Id == id, cancellationToken: cancelation))
                .WithMessage("Usuário não encontrado!");

            RuleFor(x => x.Nome).NotNull().NotEmpty()
                .Length(50)
                .WithMessage("Nome muito grande!");

            RuleFor(x => x.Email).NotNull().NotEmpty()
                .Length(70)
                .EmailAddress()
                .WithMessage("O endereço de email informado é inválido!");
        }
    }
}
