using WebApp.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Data.Entity;
using WebApp.Context;

namespace WebApp.Services
{
    public class PessoaService : IPessoaService
    {
        private AppDbContext _contexto;

        public PessoaService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public void AddPessoa(Pessoa item)
        {
            _contexto.Pessoa.Add(item);
            _contexto.SaveChanges();
        }

        public Pessoa GetPessoa(int id)
        {
            return _contexto.Pessoa.Where(x => x.Id == id).FirstOrDefault(); ;
        }

        public List<Pessoa> GetPessoas()
        {
            return _contexto.Pessoa.ToList();
        }

        public void UpdatePessoa(Pessoa item)
        {
            Pessoa pessoa = _contexto.Pessoa.Where(p => p.Id == item.Id).FirstOrDefault();

            pessoa.Nome = item.Nome;
            pessoa.Sobrenome = item.Sobrenome;
            pessoa.Email = item.Email;

            _contexto.SaveChanges();
        }

        public void DeletePessoa(int id)
        {
            Pessoa pessoa = _contexto.Pessoa.Where(p => p.Id == id).FirstOrDefault();
            _contexto.Pessoa.Remove(pessoa);

            _contexto.SaveChanges();
        }

        public bool PessoaExists(int id)
        {
            return _contexto.Pessoa.Any(p => p.Id == id);
        }
    }
}
