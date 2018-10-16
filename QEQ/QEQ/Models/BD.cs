using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QEQ.Models
{
    public static class BD
    {
        public static string ConectionString = "Server=10.128.8.16;DataBase=QEQC03;User ID=QEQC03;Pwd=QEQC03;";

        public static SqlConnection Conectar()
        {
            SqlConnection Conexion = new SqlConnection(ConectionString);
            Conexion.Open();
            return Conexion;
        }

        public static void Desconectar(SqlConnection Conexion)
        {
            Conexion.Close();
        }

        public static List<Categorias> ListarCategorias(int id = 0)
        {
            List<Categorias> ListaDeCategorias = new List<Categorias>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ListarCategorias";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", id);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            while (DataReader.Read())
            {
                int Id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();
                

                Categorias cate = new Categorias(Id, Nombre);
                ListaDeCategorias.Add(cate);

            }
            Desconectar(Conexion);
            return ListaDeCategorias;
        }

        public static void InsertarCategoria(string Nombre)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", Nombre);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }

        public static void EliminarCategoria(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", id);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }

        public static void ModificarCategoria(Categorias cate)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", cate.Nombre);
            Consulta.Parameters.AddWithValue("@id", cate.id);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }
    }
}