using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    public class Screenings
    {
        public string movieName { get; set; }
        [Key ,Column(Order = 1)]
        public string sHour { get; set; }
        [Key ,Column(Order = 2)]
        public string sDate { get; set; }
        [Key ,Column(Order = 3)]
        public string hall { get; set; }

        public virtual Movies movies { get; set; }
        public virtual Hall halls { get; set; }

        public void DeleteScreening(string movieName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CinemaDal"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteScreening", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@movieName";
                paramId.Value = movieName;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}