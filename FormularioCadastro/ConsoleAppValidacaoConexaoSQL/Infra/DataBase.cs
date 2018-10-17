using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppValidacaoConexaoSQL.Infra
{
    public class DataBase
    {
        public string ConnectionString { get; set; }

        public DataBase()
        {
            this.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionAmbienteDEV"].ToString();
        }

        public DataBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DataTable ExecuteDataTable(string comandoSql)
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand(comandoSql, conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }

        public List<DataTable> ExecuteDataTables(string comandoSql)
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand(comandoSql, conn);
            SqlDataAdapter da = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            List<DataTable> listDataTable = new List<DataTable>();
            for(int i = 0; i < ds.Tables.Count; i++)
            {
                listDataTable.Add(ds.Tables[i]);
            }

            return listDataTable;
        }

    }
}
