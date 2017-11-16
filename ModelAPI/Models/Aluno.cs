using System;
using System.Collections.Generic;
using ModelAPI.Repositories;

namespace ModelAPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string NomeMae { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Nro { get; set; }
        public string Complemento { get; set; }

        // Método para adicionar uma lista de alunos
        internal bool Adicionar(List<Aluno> alunos)
        {
            AlunoRepositories objAlunoRepo = new AlunoRepositories();
            return objAlunoRepo.AdicionarLista(alunos);
        }

        // Método para listar os dados dos alunos
        internal List<Aluno> Consultar()
        {
            AlunoRepositories objAlunoRepo = new AlunoRepositories();
            return objAlunoRepo.Consultar();
        }

        // Método para listar os dados do aluno selecionado
        internal Aluno ConsultarPorId(int id)
        {
            AlunoRepositories objAlunoRepo = new AlunoRepositories();
            return objAlunoRepo.ConsultarPorId(id);
        }

        // Método para deletar os dados do aluno selecionado
        internal bool Apagar(int id)
        {
            AlunoRepositories objAlunoRepo = new AlunoRepositories();
            return objAlunoRepo.Apagar(id);
        }
    }
}