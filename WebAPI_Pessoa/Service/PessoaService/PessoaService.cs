using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI_Pessoa.DataContext;
using WebAPI_Pessoa.Models;

namespace WebAPI_Pessoa.Service.PessoaService
{
    public class PessoaService : IPessoaInterface
    {

        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> SelectPessoa()
        {

            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();
            

            try
            {   
                serviceResponse.Dados = _context.Pessoas.ToList();
                serviceResponse.Sucesso = true;
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> SelectPessoa(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();
            try
            {
                PessoaModel pessoa = _context.Pessoas.FirstOrDefault(x => x.Codigo == id);
                if(pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa Não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = pessoa;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<PessoaModel>>> SelectPessoa(string nomePessoa)
        {
            throw new NotImplementedException();
        }
        

        public async Task<ServiceResponse<List<PessoaModel>>> InsertPessoa(PessoaModel novoPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();
            try
            {
                if(novoPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informa dados!";
                    serviceResponse.Sucesso = false;
                }
                _context.Add(novoPessoa);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pessoas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
       

        public async Task<ServiceResponse<List<PessoaModel>>> UpadatePessoa(PessoaModel editarPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();
            try
            {
                PessoaModel pessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(x => x.Codigo == editarPessoa.Codigo);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa Não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Pessoas.Update(editarPessoa);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Pessoas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();
            try
            {
                PessoaModel pessoa = _context.Pessoas.FirstOrDefault(x => x.Codigo == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa Não localizado";
                    serviceResponse.Sucesso=false;
                }

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }
    }
}
