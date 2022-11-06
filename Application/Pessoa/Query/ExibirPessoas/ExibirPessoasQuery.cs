using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pessoa.Query.ExibirPessoas
{
    public class ExibirPessoasQuery : IRequest<ExibirPessoasQueryResponse>
    {
        public int Id { get; set; }
    }
}
