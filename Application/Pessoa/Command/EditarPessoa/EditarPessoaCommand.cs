using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.EditarPessoa
{
    public class EditarPessoaCommand : IRequest<EditarPessoaCommandResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
