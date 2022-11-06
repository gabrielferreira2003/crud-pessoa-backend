using Application.Pessoa.Command.AdicionarPessoa;
using Application.Pessoa.Command.EditarPessoa;
using Application.Pessoa.Command.ExcluirPessoa;
using Application.Pessoa.Query.ExibirPessoas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_pessoa_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<AdicionarPessoaCommandResponse> AdicionarPessoa([FromBody] AdicionarPessoaCommand request)
        { 
            return await _mediator.Send(request);
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<EditarPessoaCommandResponse> EditarPessoa([FromBody] EditarPessoaCommand request)
        {
            return await _mediator.Send(request);
        }

        [Route("[action]/id")]
        [HttpDelete]
        public async Task<ExcluirPessoaCommandResponse> ExcluirPessoa([FromQuery] ExcluirPessoaCommand request)
        {
            return await _mediator.Send(request);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ExibirPessoasQueryResponse> ExibirPessoa([FromQuery] ExibirPessoasQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
