using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Application.Pessoa.Query.ExibirPessoas
{
    public class ExibirPessoasQueryHandler : IRequestHandler<ExibirPessoasQuery, ExibirPessoasQueryResponse>
    {
        private readonly Contexto _contexto;
        public ExibirPessoasQueryHandler(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<ExibirPessoasQueryResponse> Handle(ExibirPessoasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoaSelecionada = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.Id == request.Id);

                var pessoasExibir = new ExibirPessoasQueryResponse()
                {
                    Id = pessoaSelecionada.Id,
                    Nome = pessoaSelecionada.Nome,
                    Email = pessoaSelecionada.Email,
                    Data = pessoaSelecionada.Data,
                };

                return pessoasExibir;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
