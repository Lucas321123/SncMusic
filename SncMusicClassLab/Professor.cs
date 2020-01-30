using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;

namespace SncMusic
{
    class Professor
    {
        // atributos e propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        //métodos construtores
        public Professor()
        {


        }
        public Professor(int _id, string _nome, string _cpf, string _sexo, string _email, string _telefone, DateTime _dataCadastro)
        {
            Id = _id;
            Nome = _nome;
            Cpf = _cpf;
            Sexo = _sexo;
            Telefone = _telefone;
            Email = _email;
            DataCadastro = _dataCadastro;
        }
        public Professor(string _nome, string _cpf, string _sexo, string _email, string _telefone)
        {
            Nome = _nome;
            Cpf = _cpf;
            Sexo = _sexo;
            Telefone = _telefone;
            Email = _email;
        }
        public void Inserir()
        {
            var comm = Banco.Abrir();
            comm.CommandText = "insert into tb_aluno values (0,@nome,@cpf,@sexo,@email,@telefone,default)";
            comm.Parameters.Add("@nome", MySqlDbType.VarChar).Value = Nome;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = Cpf;
            comm.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = Sexo;
            comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = Email;
            comm.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = Telefone;
            comm.ExecuteNonQuery();
            comm.CommandText = "select @@identity";
            Id = Convert.ToInt32(comm.ExecuteScalar());
            comm.Connection.Close();
        }
        public bool Alterar(Professor professor)
        {
            var comm = Banco.Abrir();

            comm.CommandText = " update tb_aluno set nome_aluno = @nome,sexo_aluno = @sexo," +
                "telefone_ aluno = @telefone where id_aluno = @id";
            comm.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professor.Nome;

            comm.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = professor.Sexo;

            comm.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professor.Telefone;
            comm.Parameters.Add("@id", MySqlDbType.Int32).Value = professor.Id;

            comm.ExecuteNonQuery();
            Banco.Fechar();






            return true;
        }
        public void ConsultarPorId(int _id)
        {
            //consulte o professor
            var comm = Banco.Abrir();
            comm.CommandText = "select * from tb_professor where id_professor = " + +_id;
            var dr = comm.ExecuteReader();
            while (dr.Read())
            {
                Nome = dr.GetString(1);
                Email = dr.GetString(4);
                Cpf = dr.GetString(2);
                Sexo = dr.GetString(3);
                Telefone = dr.GetString(5);
                DataCadastro = Convert.ToDateTime(dr.GetString(6));
            }
            Banco.Fechar();
        }
        public List<Professor> ListarTodos()
        {
            List<Professor> ListarProfessor = new List<Professor>();
            var comm = Banco.Abrir();
            comm.CommandText = "select * from tb_aluno ";
            var dr = comm.ExecuteReader();
            while (dr.Read())
            {
                ListarProfessor.Add(new Professor(dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2), dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    Convert.ToDateTime(dr.GetValue(6))));

                //Aluno aluno = new Aluno();
                //aluno.Id = dr.GetInt32(0)
                //aluno.Nome = dr.GetString(1);
                //aluno.Email = dr.GetString(4);
                //aluno.Cpf = dr.GetString(2);
                //aluno.Sexo = dr.GetString(3);
                //aluno.Telefone = dr.GetString(5);
                //aluno.DataCadastro = Convert.ToDateTime(dr.GetString(6));
                //ListarAluno.Add(aluno);
            }
            Banco.Fechar();
            return ListarProfessor;

        }




    }
}
