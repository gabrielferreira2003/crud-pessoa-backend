using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Command.ExcluirPessoa
{
    public class ExcluirPessoaCommand : IRequest<ExcluirPessoaCommandResponse>
    {
        public int Id { get; set; }
    }
}
