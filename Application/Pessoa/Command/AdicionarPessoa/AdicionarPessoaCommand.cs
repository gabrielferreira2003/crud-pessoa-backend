using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.AdicionarPessoa
{
    public class AdicionarPessoaCommand : IRequest<AdicionarPessoaCommandResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
