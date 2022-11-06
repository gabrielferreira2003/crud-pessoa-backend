using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Application.Pessoa.Command.ExcluirPessoa
{
    public class ExcluirPessoaCommandHandler : IRequestHandler<ExcluirPessoaCommand, ExcluirPessoaCommandResponse>
    {
        private readonly Contexto _contexto;
        public ExcluirPessoaCommandHandler(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<ExcluirPessoaCommandResponse> Handle(ExcluirPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoaSelecionada = await _contexto.Pessoas.FirstOrDefaultAsync(p => p.Id == request.Id);

                _contexto.Pessoas.Remove(pessoaSelecionada);
                await _contexto.SaveChangesAsync();

                return new ExcluirPessoaCommandResponse() { Sucesso = true };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
