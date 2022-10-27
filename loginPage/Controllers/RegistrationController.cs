using loginPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;

namespace loginPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UsersDB").ToString());
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Registration(username, password, email, IsActive) VALUES('" + registration.username + "','" + registration.password + "','" + registration.email + "','" + registration.IsActive + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return "Data inserted.";
            }
            else
            {
                return "Error.";
            }
            return "";
        }

        [HttpGet]
        [Route("login")]
        public string login(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UsersDB").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE email = '" + registration.email +"' AND password = '" + registration.password+"' AND IsActive = 1", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return "Valid User";
            }
            else
            {
                return "Invalid User";
            }
        }
    }
}
