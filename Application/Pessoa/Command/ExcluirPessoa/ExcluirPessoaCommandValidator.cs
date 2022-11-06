using FluentValidation;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.ExcluirPessoa
{
    public class ExcluirPessoaCommandValidator : AbstractValidator<ExcluirPessoaCommand>
    {
        public ExcluirPessoaCommandValidator(Contexto contexto)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty()
                .MustAsync(async(_, id, cancelation) => await contexto.Pessoas.AnyAsync(x => x.Id == id))
                .WithMessage("Usuario não encontrado!");
        }
    }
}
