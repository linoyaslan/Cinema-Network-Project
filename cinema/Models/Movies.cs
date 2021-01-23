using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace cinema.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public string movieName { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,2}$", ErrorMessage ="Age must start from 0")]
        public int ageLimit { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,2}$", ErrorMessage = "Price must start from 0")]
        public int currentPrice { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,2}$", ErrorMessage = "Price must start from 0")]
        public int previousPrice { get; set; }
        [Required]
        public string poster { get; set; }


        public void DeleteMovie(string movieName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CinemaDal"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteMovie", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@movieName";
                paramId.Value = movieName;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //public void InsertMovie(int movieID)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["CinemaDal"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spInsertMovie", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter paramId = new SqlParameter();
        //        paramId.ParameterName = "@movieID";
        //        paramId.Value = movieID;
        //        cmd.Parameters.Add(paramId);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}