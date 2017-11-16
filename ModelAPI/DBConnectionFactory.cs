using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ModelAPI
{
    /// <summary>
    /// Classe responsável por armazenar a criação de conexão com o banco de dados e escolha de ConnectionString.
    /// </summary>
    public class DBConnectionFactory
    {
        private string _connectionString;

        /// <summary>
        /// Método responsável por buscar no web.config a ConnectionString que fará conexão com a base de dados escolhida.
        /// </summary>
        /// <param name="dbName">Nome da base de dados que será buscada no web.config</param>
        public DBConnectionFactory(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                throw new ArgumentNullException("connectionName");
            }

            _connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException(string.Format("Não foi possível encontrar a connection string '{0}' no arquivo de configuração.", dbName));
            }
        }

        #region MetodosAdicionarParametros
        /// <summary>
        /// Métodos responsáveis por adicionar parametro ao comando sql
        /// </summary>
        public void AdicionaParamentro(string nome, string valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.VarChar).Value = valor;
        } // Valor de entrada do tipo STRING

        public void AdicionaParamentro(string nome, int valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.Int).Value = valor;
        } // Valor de entrada do tipo INT

        public void AdicionaParamentro(string nome, int? valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.Int).Value = valor;
        } // Valor de entrada do tipo INT OPCIONAL

        public void AdicionaParamentro(string nome, DateTime valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.DateTime2).Value = valor;
        } // Valor de entrada do tipo DATETIME

        public void AdicionaParamentro(string nome, DateTime? valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.DateTime2).Value = valor;
        } // Valor de entrada do tipo DATETIME OPCIONAL

        public void AdicionaParamentro(string nome, bool valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.Bit).Value = valor;
        } // Valor de entrada do tipo BOOL

        public void AdicionaParamentro(string nome, decimal valor, SqlCommand cmd)
        {
            cmd.Parameters.Add(nome, SqlDbType.Decimal).Value = valor;
        } // Valor de entrada do tipo DECIMAL
        #endregion

        #region CriarComando
        /// <summary>
        ///  Método responsável por criar o comando sql
        /// </summary>
        public SqlCommand CreateCommand(string Comando, SqlConnection conn)
        {
            return new SqlCommand(Comando, conn);
        }
        #endregion

        /// <summary>
        /// Método responsável por criar uma nova conexão com o banco de dados.
        /// </summary>
        /// <returns>Retonar um SqlConnection já com a ConnectionString atribuida.</returns>
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
