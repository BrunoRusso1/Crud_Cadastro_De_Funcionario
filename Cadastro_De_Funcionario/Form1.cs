global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace Cadastro_De_Funcionario
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataReader leitor;
        SqlDataAdapter atualizar;

        protected string sql;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-EDJRHUU\BRUNOSQL; Database=Funcionarios; User ID = sa; Password = 123456789;");

                sql = "INSERT INTO Funcionarios (Id, Nome, Email, Telefone) VALUES (@Id, @Nome, @Email, @Telefone)";

                comando = new SqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@Id", txtID.Text);
                comando.Parameters.AddWithValue("@Nome", txtNome.Text);
                comando.Parameters.AddWithValue("@Email", txtEmail.Text);
                comando.Parameters.AddWithValue("Telefone", txtTelefone.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Salvo com Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;
            }


        }

        private void btnExibir_Click(object sender, EventArgs e)
        {

            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-EDJRHUU\BRUNOSQL; Database=Funcionarios; User ID = sa; Password = 123456789;");

                sql = "SELECT * FROM Funcionarios";

                DataSet ds = new DataSet();

                atualizar = new SqlDataAdapter(sql, conexao);


                conexao.Open();

                atualizar.Fill(ds);
                dgv.DataSource = ds.Tables[0];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-EDJRHUU\BRUNOSQL; Database=Funcionarios; User ID = sa; Password = 123456789;");

                sql = "SELECT * FROM Funcionarios WHERE ID=@ID";

                comando = new SqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@Id", txtConsulta.Text);


                conexao.Open();
                leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    txtID.Text = Convert.ToString(leitor["Id"]);
                    txtNome.Text = (String)leitor["Nome"];
                    txtEmail.Text = (String)leitor["Email"];
                    txtTelefone.Text = (String)leitor["Telefone"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-EDJRHUU\BRUNOSQL; Database=Funcionarios; User ID = sa; Password = 123456789;");

                sql = "UPDATE Funcionarios SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";

                comando = new SqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@Id", txtID.Text);
                comando.Parameters.AddWithValue("@Nome", txtNome.Text);
                comando.Parameters.AddWithValue("@Email", txtEmail.Text);
                comando.Parameters.AddWithValue("Telefone", txtTelefone.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Editado com Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-EDJRHUU\BRUNOSQL; Database=Funcionarios; User ID = sa; Password = 123456789;");

                sql = "DELETE Funcionarios WHERE Id = @Id";

                comando = new SqlCommand(sql, conexao);

                comando.Parameters.AddWithValue("@Id", txtID.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Excluído com Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conexao.Close();
                conexao = null;
                comando = null;
            }
        }


    }
}