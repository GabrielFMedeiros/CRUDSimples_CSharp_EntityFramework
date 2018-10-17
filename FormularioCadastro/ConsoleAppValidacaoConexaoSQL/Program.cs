using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppValidacaoConexaoSQL
{
    public class Pessoa {

        public int Idade { get; set; }
        public string Nome { get; set; }

        public Pessoa(int idade, string nome)
        {
            this.Idade = idade;
            this.Nome = nome;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Infra.DataBase dataBase = new Infra.DataBase();

            DataTable dtResult = dataBase.ExecuteDataTable("Select IdProduto, Nome from Produtos");
            
            string DDD = System.Configuration.ConfigurationManager.AppSettings.Get("DDD").ToString();

            string connectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["connectionAmbienteDEV"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select IdProduto, Nome from Produtos select * from Categorias ", conn);
                        
            SqlDataAdapter da = new SqlDataAdapter(command);

            List<Pessoa> listPessoa = new List<Pessoa>();

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dtProduto = ds.Tables[0];
            DataTable dtCategoria = ds.Tables[1];

            int qtdProduto = dtProduto.Rows.Count;
            int qtdCateogira = dtCategoria.Rows.Count;

            for(int i =0; i < dtProduto.Rows.Count; i++)
            {
                DataRow linhaAtual = dtProduto.Rows[i];

                int idproduto = Convert.ToInt32(linhaAtual["IdProduto"].ToString());
                
            }

            //apenas executa o comando, sem retorno
            //int rows = command.ExecuteNonQuery();
            //if (rows > 0) { //registro at}

            SqlDataReader dr = command.ExecuteReader();

            
            while(dr.Read()){

                int idade = Convert.ToInt32(dr["IdProduto"].ToString());
                string nome = "";//dr["Nome"].ToString();

                Pessoa pessoa = new Pessoa(idade, nome);
                listPessoa.Add(pessoa);
            }

            

            conn.Close();
        }
    }
}
