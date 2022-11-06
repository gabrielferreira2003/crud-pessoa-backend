using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexto;

namespace Application.Pessoa.Command.EditarPessoa
{
    public class EditarPessoaCommandHandler : IRequestHandler<EditarPessoaCommand, EditarPessoaCommandResponse>
    {
        private readonly Contexto _contexto;
        public EditarPessoaCommandHandler(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<EditarPessoaCommandResponse> Handle(EditarPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoaEditar = new Domain.Models.Entidades.Pessoa()
                { 
                    Id = request.Id,
                    Nome = request.Nome,
                    Email = request.Email,
                    Data = DateTime.UtcNow
                };

                _contexto.Pessoas.Update(pessoaEditar);
                await _contexto.SaveChangesAsync();

                return new EditarPessoaCommandResponse() { Sucesso = true };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
