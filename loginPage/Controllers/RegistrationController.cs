using loginPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Data.SqlClient;

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
            int i = cmd.ExecuteNonQuery();
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
    }
}
