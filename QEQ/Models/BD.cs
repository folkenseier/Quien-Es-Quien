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

        //-----------------------ABM-CATEGORIAS--------------------------------------------------------------------------------

        public static List<Categorias> ListarCategorias()
        {
            List<Categorias> ListaDeCategorias = new List<Categorias>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ListarCategorias";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader DataReader = Consulta.ExecuteReader();
            while (DataReader.Read())
            {
                int id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();
                

                Categorias cate = new Categorias(id, Nombre);
                ListaDeCategorias.Add(cate);

            }
            Desconectar(Conexion);
            return ListaDeCategorias;
        }

        public static Categorias ObtenerCategoria(int Id)
        {
            Categorias cate = new Categorias();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", Id);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            while (DataReader.Read())
            {
                int id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();

                cate = new Categorias(id, Nombre);
            }
            Desconectar(Conexion);
            return cate;
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

        //----------------------------------------------------------------------------------------------------------------------------------


        //----------------------------------------LOGIN-------------------------------------------------------------------------------

        public static Usuario TraerUsuario(string Email, string pwd)
        {
            Usuario UnUsuario = new Usuario();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "TraerUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Mail", Email);
            Consulta.Parameters.AddWithValue("@Contraseña", pwd);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {
                int id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();
                string Mail = DataReader["Mail"].ToString();
                string Contraseña = DataReader["Contraseña"].ToString();
                bool EsAdmin = Convert.ToBoolean(DataReader["EsAdmin"]);
                int Puntaje = Convert.ToInt32(DataReader["Puntaje"]);
                int Record = Convert.ToInt32(DataReader["Record"]);



                 UnUsuario = new Usuario(id, Nombre, Mail, Contraseña, EsAdmin, Puntaje, Record);
               

            }
            Desconectar(Conexion);
            return UnUsuario;
        }
        public static bool BuscarPorMail(string Email)
        {
            
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "BuscarPorMail";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Mail", Email);
            bool Ans = true;
            if (Consulta.ExecuteScalar() == null) Ans = false;
            Desconectar(Conexion);
            return Ans;
        }
        public static bool ValidarUser(string Email, string pwd)
        {
            bool Existe = false;
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "TraerUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Mail", Email);
            Consulta.Parameters.AddWithValue("@Contraseña", pwd);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {
                Existe = true;
            }
            Desconectar(Conexion);
            return Existe;
        }

        //-------------------------------------ABM USUARIOS--------------------------------------------------------//
        public static bool RegistrarUsuario(Usuario usuario)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "RegistrarUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            Consulta.Parameters.AddWithValue("@Mail", usuario.Mail);
            Consulta.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            Consulta.Parameters.AddWithValue("@EsAdmin", usuario.EsAdmin);
            try
            {
                Consulta.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
            
        }

        


        //----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------ABM-CATEGORIAS--------------------------------------------------------------------------------

        public static List<Caracteristicas> ListarCaracteristicas()
        {
            List<Caracteristicas> ListaDeCaracteristicas = new List<Caracteristicas>();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ListarCaracteristicas";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader DataReader = Consulta.ExecuteReader();
            while (DataReader.Read())
            {
                int id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();
                string TextoPregunta = DataReader["TextoPregunta"].ToString();
                int ValorPregunta = Convert.ToInt32(DataReader["ValorPregunta"]);


                Caracteristicas cara = new Caracteristicas(id, Nombre, TextoPregunta, ValorPregunta);
                ListaDeCaracteristicas.Add(cara);

            }
            Desconectar(Conexion);
            return ListaDeCaracteristicas;
        }

        public static Caracteristicas ObtenerCaracteristica(int Id)
        {
            Caracteristicas cara = new Caracteristicas();
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ObtenerCaracteristica";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", Id);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            while (DataReader.Read())
            {
                int id = Convert.ToInt32(DataReader["id"]);
                string Nombre = DataReader["Nombre"].ToString();
                string TextoPregunta = DataReader["TextoPregunta"].ToString();
                int ValorPregunta = Convert.ToInt32(DataReader["ValorPregunta"]);

                cara = new Caracteristicas(id, Nombre, TextoPregunta, ValorPregunta);
            }
            Desconectar(Conexion);
            return cara;
        }

        public static void InsertarCaracteristicas(string Nombre, string TextoPregunta, int ValorPregunta)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "InsertarCaracteristicas";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", Nombre);
            Consulta.Parameters.AddWithValue("@TextoPregunta", TextoPregunta);
            Consulta.Parameters.AddWithValue("@ValorPregunta", ValorPregunta);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }

        public static void EliminarCaracteristicas(int id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "EliminarCaracteristicas";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@id", id);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }

        public static void ModificarCaracteristicas(Caracteristicas cara)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandText = "ModificarCaracteristicas";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", cara.Nombre);
            Consulta.Parameters.AddWithValue("@id", cara.id);
            Consulta.Parameters.AddWithValue("@TextoPregunta", cara.TextoPregunta);
            Consulta.Parameters.AddWithValue("@ValorPregunta", cara.ValorPregunta);
            Consulta.ExecuteNonQuery();

            Desconectar(Conexion);
        }

        //------------------------------------------------------------------------------------------------------------------------------




    }
}