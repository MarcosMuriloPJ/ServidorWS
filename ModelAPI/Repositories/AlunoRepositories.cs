using System;
using System.Data;
using System.Collections.Generic;
using ModelAPI.Models;

namespace ModelAPI.Repositories
{
    public class AlunoRepositories : DBConnectionFactory
    {
        public AlunoRepositories()
            : base("modeloSql")
        {
            //
        }

        // Espera lista de alunos como parametro
        // Retorna booleano
        public bool AdicionarLista(List<Aluno> alunos)
        {
            // Tipo de retorno
            bool retorno = true;

            // Cria a conexão
            using (var conn = CreateConnection())
            {
                // Cria o comando à ser executado
                using (var cmd = CreateCommand("PR_GravarAluno", conn))
                {
                    // Seta o tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seta os parâmetros necessários
                    foreach (var item in alunos)
                    {
                        AdicionaParamentro("@cpf", item.CPF, cmd);
                        AdicionaParamentro("@nome", item.Nome, cmd);
                        AdicionaParamentro("@dataNasc", item.DataNasc, cmd);
                        AdicionaParamentro("@nomeMae", item.NomeMae, cmd);
                        AdicionaParamentro("@bairro", item.Bairro, cmd);
                        AdicionaParamentro("@logradouro", item.Logradouro, cmd);
                        AdicionaParamentro("@nro", item.Nro, cmd);
                        AdicionaParamentro("@complemento", item.Complemento, cmd);

                        try
                        {
                            // Abre conexão
                            conn.Open();

                            // Executa o comando e verifica se retornou alguma linha
                            var resultado = cmd.ExecuteReader();
                            if (resultado.HasRows)
                                while (resultado.Read())
                                {
                                    if (Convert.ToBoolean(resultado["CADASTRADO"]) == false)
                                    {
                                        retorno = false;
                                    }
                                }
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message, e);
                        }
                        finally
                        {
                            // Fecha conexão
                            conn.Close();
                        }

                        // Limpa os paramêtros utilizados
                        cmd.Parameters.Clear();
                    }
                }
            }

            return retorno;
        }

        // Retorna lista de alunos
        public List<Aluno> Consultar()
        {
            // Tipo de retorno
            List<Aluno> retorno = new List<Aluno>();

            // Cria a conexão
            using (var conn = CreateConnection())
            {
                // Cria o comando à ser executado
                using (var cmd = CreateCommand("SELECT * FROM Alunos", conn))
                {
                    try
                    {
                        // Abre conexão
                        conn.Open();

                        // Executa o comando e verifica se retornou alguma linha
                        var resultado = cmd.ExecuteReader();
                        if (resultado.HasRows)
                        {
                            Aluno obj;
                            while (resultado.Read())
                            {
                                obj = new Aluno()
                                {
                                    Id = Convert.ToInt32(resultado["Id"]),
                                    CPF = resultado["CPF"].ToString(),
                                    Nome = resultado["Nome"].ToString(),
                                    DataNasc = Convert.ToDateTime(resultado["DataNasc"]),
                                    NomeMae = resultado["NomeMae"].ToString(),
                                    Bairro = resultado["Bairro"].ToString(),
                                    Logradouro = resultado["Logradouro"].ToString(),
                                    Nro = Convert.ToInt32(resultado["Nro"]),
                                    Complemento = resultado["Complemento"].ToString()
                                };

                                retorno.Add(obj);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    finally
                    {
                        // Fecha conexão
                        conn.Close();
                    }
                }
            }
            return retorno;
        }

        // Espera id de aluno como parametro
        // Retorna dados de aluno único
        public Aluno ConsultarPorId(int id)
        {
            // Tipo de retorno
            Aluno retorno = new Aluno();

            // Cria a conexão
            using (var conn = CreateConnection())
            {
                // Cria o comando à ser executado
                using (var cmd = CreateCommand("PR_BuscaAluno", conn))
                {
                    // Seta o tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seta os parâmetros necessários
                    AdicionaParamentro("@id", id, cmd);

                    try
                    {
                        // Abre conexão
                        conn.Open();

                        // Executa o comando e verifica se retornou alguma linha
                        var resultado = cmd.ExecuteReader();
                        if (resultado.HasRows)
                        {
                            while (resultado.Read())
                            {
                                retorno = new Aluno()
                                {
                                    Id = Convert.ToInt32(resultado["Id"]),
                                    CPF = resultado["CPF"].ToString(),
                                    Nome = resultado["Nome"].ToString(),
                                    DataNasc = Convert.ToDateTime(resultado["DataNasc"]),
                                    NomeMae = resultado["NomeMae"].ToString(),
                                    Bairro = resultado["Bairro"].ToString(),
                                    Logradouro = resultado["Logradouro"].ToString(),
                                    Nro = Convert.ToInt32(resultado["Nro"]),
                                    Complemento = resultado["Complemento"].ToString()
                                };
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    finally
                    {
                        // Fecha conexão
                        conn.Close();
                    }
                }
            }
            return retorno;
        }

        // Espera id de aluno como parametro
        // Retorna booleano
        public bool Apagar(int id)
        {
            // Tipo de retorno
            bool retorno = false;

            // Cria a conexão
            using (var conn = CreateConnection())
            {
                // Cria o comando à ser executado
                using (var cmd = CreateCommand("PR_ApagaAluno", conn))
                {
                    // Seta o tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seta os parâmetros necessários
                    AdicionaParamentro("@id", id, cmd);

                    try
                    {
                        // Abre conexão
                        conn.Open();

                        // Executa o comando e verifica se retornou alguma linha
                        var resultado = cmd.ExecuteReader();
                        if (resultado.HasRows)
                        {
                            while (resultado.Read())
                            {
                                retorno = Convert.ToBoolean(resultado["APAGADO"]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    finally
                    {
                        // Fecha conexão
                        conn.Close();
                    }
                }
            }

            return retorno;
        }
    }
}
