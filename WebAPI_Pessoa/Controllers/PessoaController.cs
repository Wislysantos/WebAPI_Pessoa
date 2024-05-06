using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Pessoa.Models;
using WebAPI_Pessoa.Service.PessoaService;

namespace WebAPI_Pessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;
        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> GetPessoa()
        {

            return Ok(await _pessoaInterface.SelectPessoa());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> GetById(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = await _pessoaInterface.SelectPessoa(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> PostPessoa(PessoaModel novoPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.InsertPessoa(novoPessoa);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> PutPessoa(PessoaModel EditarPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.UpadatePessoa(EditarPessoa);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> DeletaPessoa(int id)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.DeletePessoa(id);
            return Ok(serviceResponse);
        }
    }
}
