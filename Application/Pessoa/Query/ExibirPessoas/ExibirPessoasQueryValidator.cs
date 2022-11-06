using FluentValidation;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Query.ExibirPessoas
{
    public class ExibirPessoasQueryValidator : AbstractValidator<ExibirPessoasQuery>
    {
        public ExibirPessoasQueryValidator(Contexto contexto)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty()
                .MustAsync(async (_, id, cancelation) => await contexto.Pessoas.AnyAsync(x => x.Id == id))
                .WithMessage("Usuario não encontrado!");
        }
    }
}
