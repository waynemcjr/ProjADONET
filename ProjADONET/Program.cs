// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;
using ProjADONET;

var connection = new SqlConnection(DbConnection.GetConnectionString());

var pessoa = new Pessoa("Enrick", "18765134119", new DateOnly(2001, 6, 12));

var sqlInsertPessoa = $"INSERT INTO Pessoas (nome, cpf, dataNascimento) VALUES (@Nome, @CPF, @DataNascimento); SELECT SCOPE_IDENTITY();";

#region insert
connection.Open();

var command = new SqlCommand(sqlInsertPessoa, connection);

command.Parameters.AddWithValue("@Nome", pessoa.Nome);
command.Parameters.AddWithValue("@CPF", pessoa.Cpf);
command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);

int PessoaID = Convert.ToInt32(command.ExecuteScalar()); // scope identity

var telefone = new Telefone("11", "987654391", "Celular", PessoaID);

var sqlInsertTelefone = $"INSERT INTO Telefones (ddd, numero, tipo, pessoaId) VALUES (@Ddd, @Numero, @Tipo, @PessoaID);";

command = new SqlCommand(@sqlInsertTelefone, connection);
command.Parameters.AddWithValue("@Ddd", telefone.DDD);
command.Parameters.AddWithValue("@Numero", telefone.Numero);
command.Parameters.AddWithValue("@Tipo", telefone.Tipo);
command.Parameters.AddWithValue("@PessoaID", telefone.PessoaId);

command.ExecuteNonQuery();

connection.Close();
#endregion

#region select
connection.Open();

var sqlSelectPessoa = "SELECT id, nome, cpf, dataNascimento FROM Pessoas";

command = new SqlCommand(sqlSelectPessoa, connection);

var reader = command.ExecuteReader();

while (reader.Read())
{
    var pessoaLida = new Pessoa(
        reader.GetString(1),
        reader.GetString(2),
        DateOnly.FromDateTime(reader.GetDateTime(3))
    );
    pessoaLida.setId(reader.GetInt32(0));

    Console.WriteLine(pessoaLida);
}

connection.Close();
#endregion

#region update

connection.Open();

var sqlUpdatePessoa = "UPDATE Pessoas SET nome = @Nome WHERE id = @Id";

command = new SqlCommand(sqlUpdatePessoa, connection);
command.Parameters.AddWithValue("@Nome", "Felipe Silva");
command.Parameters.AddWithValue("@Id", 1);

command.ExecuteNonQuery();

connection.Close();

#endregion

#region delete

//connection.Open();

//var sqlDeletePessoa = "DELETE FROM Pessoas WHERE id = @Id";

//command = new SqlCommand(sqlDeletePessoa, connection);
//command.Parameters.AddWithValue("@Id", 2);
//command.ExecuteNonQuery();

//connection.Close();

#endregion