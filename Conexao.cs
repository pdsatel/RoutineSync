using MySql.Data.MySqlClient;

namespace Tcc
{
    public static class Conexao
    {
        private static string conexao = "server=localhost;database=routinesync1_db;uid=root;pwd=;";

        public static MySqlConnection ObterConexao()
        {
            var conn = new MySqlConnection(conexao);
            conn.Open();
            return conn;
        }
    }
}
