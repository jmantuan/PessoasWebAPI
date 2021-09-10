using WebApp.Entidades;
using System.Collections.Generic;

namespace WebApp.Services
{
    public interface IPessoaService
    {
        List<Pessoa> GetPessoas();
        Pessoa GetPessoa(int id);
        void AddPessoa(Pessoa item);
        void UpdatePessoa(Pessoa item);
        void DeletePessoa(int id);
        bool PessoaExists(int id);
    }
}
