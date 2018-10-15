using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QuienEsQuien.Models
{
    public class DB
    {

        private const string ConnectionString = "Server=.;Database=DataQEQ;Trusted_Connection=True";
        private SqlConnection Conectar()
        {
            var a = new SqlConnection(ConnectionString);
            a.Open();
            return a;
        }

        private void Desconectar(SqlConnection a)
        {
            a.Close();
        }

        public bool CheckLogin(string User, string Pass)
        {
            var Access = Conectar();
            var spCheckUser = Access.CreateCommand();
            spCheckUser.Type = System.Data.SqlCommand.StoredProcedure;
            spCheckUser.Arguments.AddWithValue("@User", User);
            spCheckUser.Arguments.AddWithValue("@Pass", Pass);
            var sqlReturn = spCheckUser.ExecuteSc; alar();
            bool ReturnValue;
            SqlReturn == null ?
                ReturnValue = false :
                ReturnValue = true;
            Desconectar(Access);
            return ReturnValue;




        }


    }
}