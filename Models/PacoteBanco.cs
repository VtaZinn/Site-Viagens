using MySqlConnector;
using System.Collections.Generic;


namespace atividade2CRUD.Models
{
    public class PacoteBanco 
    {
        private const string DadosConexao = "DataBase=atividade_2; Data Source=localhost; User Id = root;";
        
        public Usuario ValidarLogin(Usuario usuario){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM Usuario WHERE Login=@Login AND Senha=@Senha";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();
            if (Reader.Read())
            {
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login"))){
                    UsuarioEncontrado.Nome = Reader.GetString("Login");
                }
                 if (!Reader.IsDBNull(Reader.GetOrdinal("Senha"))){
                    UsuarioEncontrado.Nome = Reader.GetString("Senha");
                }
            }
            Conexao.Close();
            return UsuarioEncontrado;
        }
        
        public List<Pacote> Listar(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM pacote";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Pacote> Lista = new List<Pacote>();

            while (Reader.Read())
            {
                Pacote PacoteEncontrado = new Pacote();
                PacoteEncontrado.id_pacotes = Reader.GetInt32("id_pacotes");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
                    PacoteEncontrado.Nome = Reader.GetString("Nome");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem"))){
                    PacoteEncontrado.Origem = Reader.GetString("Origem");
                }
                 if (!Reader.IsDBNull(Reader.GetOrdinal("Destino"))){
                    PacoteEncontrado.Destino = Reader.GetString("Destino");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos"))){
                    PacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Saida"))){
                    PacoteEncontrado.Saida = Reader.GetDateTime("Saida");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Retorno"))){
                    PacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Id"))){
                    PacoteEncontrado.Id = Reader.GetInt32("Id");
                }

                Lista.Add(PacoteEncontrado);
            }
            Conexao.Close();
            return Lista;
        }

        public void Inserir(Pacote pacote){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "INSERT INTO pacote (Nome,Origem,Destino,Atrativos,Saida,Retorno,Id) values (@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno,@Id)";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Id", pacote.Id);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Atualizar(Pacote pacote){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "UPDATE pacote SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno WHERE id_pacotes=@id_pacotes";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            Comando.Parameters.AddWithValue("@id_pacotes", pacote.id_pacotes);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public void Remover(int id_pacotes){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "DELETE FROM pacote WHERE id_pacotes=@id_pacotes";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            Comando.Parameters.AddWithValue("@id_pacotes", id_pacotes);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public Pacote BuscarPorId(int id_pacotes){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM pacote WHERE id_pacotes=@id_pacotes";
            MySqlCommand Comando = new MySqlCommand(Query,Conexao);
            Comando.Parameters.AddWithValue("@id_pacotes", id_pacotes);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Pacote PacoteEncontrado = new Pacote();
            if (Reader.Read())
            {
                PacoteEncontrado.id_pacotes = Reader.GetInt32("id_pacotes");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
                    PacoteEncontrado.Nome = Reader.GetString("Nome");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem"))){
                    PacoteEncontrado.Origem = Reader.GetString("Origem");
                }
                 if (!Reader.IsDBNull(Reader.GetOrdinal("Destino"))){
                    PacoteEncontrado.Destino = Reader.GetString("Destino");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos"))){
                    PacoteEncontrado.Atrativos = Reader.GetString("Atrativos");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Saida"))){
                    PacoteEncontrado.Saida = Reader.GetDateTime("Saida");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Retorno"))){
                    PacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("Id"))){
                    PacoteEncontrado.Id = Reader.GetInt32("Id");
                }
            }
            Conexao.Close();
            return PacoteEncontrado;
        }


        public void TestarConexao(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Conexao.Close();
        }
        
    }
}