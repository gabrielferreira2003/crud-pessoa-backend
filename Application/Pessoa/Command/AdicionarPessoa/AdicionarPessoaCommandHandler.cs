using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexto;
using FluentValidation;

namespace Application.Pessoa.Command.AdicionarPessoa
{
    public class AdicionarPessoaCommandHandler : IRequestHandler<AdicionarPessoaCommand, AdicionarPessoaCommandResponse>
    {
        private readonly Contexto _contexto;
        public AdicionarPessoaCommandHandler(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<AdicionarPessoaCommandResponse> Handle(AdicionarPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoaAdicionar = new Domain.Models.Entidades.Pessoa()
                {
                    Nome = request.Nome,
                    Email = request.Email,
                    Data = DateTime.UtcNow
                };

                await _contexto.Pessoas.AddAsync(pessoaAdicionar);
                await _contexto.SaveChangesAsync();

                return new AdicionarPessoaCommandResponse() { Sucesso = true };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
