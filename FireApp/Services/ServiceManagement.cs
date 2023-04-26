using FireApp.Dtos;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FireApp.Services
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly IConfiguration _configuration;
        private EmailService _emailService;
        private EmailDto _emailDto = new EmailDto();
        private Object[] rows = new object[5] ;

        public ServiceManagement(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        
        public void UpdateDatabase()
        {
            Console.WriteLine($"Every Min  : UpdateDatabase() {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            try
            {

                string connStr = _configuration.GetConnectionString("TrinketDBConn");
                SqlConnection conn = new SqlConnection(connStr);
                //Console.WriteLine(connStr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM FireApp_tbl;", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dr.GetValues(rows);
                        Array.ForEach(rows, i => Console.Write(i.ToString() + " - "));

                        _emailDto.To = (string)rows[3];
                        _emailDto.Subject = (string)rows[0];
                        _emailDto.Body = (string)rows[1];
                        Console.WriteLine(_emailDto.ToString());

                        if (dr.GetDateTime("event_datetime") < DateTime.Now)
                        {
                            Console.WriteLine("Sending Email...");
                            _emailService = new EmailService(_configuration);
                            _emailService.SendEmail(_emailDto);
                        }
                        
                        

                    }

                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }


        }
    }
}
