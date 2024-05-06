using WebAPI_Pessoa.Models;

namespace WebAPI_Pessoa.Service.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> SelectPessoa();
        Task<ServiceResponse<PessoaModel>> SelectPessoa(int id);
        Task<ServiceResponse<List<PessoaModel>>> SelectPessoa(string nomePessoa);
        Task<ServiceResponse<List<PessoaModel>>> InsertPessoa(PessoaModel novoPessoa);
        Task<ServiceResponse<List<PessoaModel>>> UpadatePessoa(PessoaModel novoPessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id);
    }
}
