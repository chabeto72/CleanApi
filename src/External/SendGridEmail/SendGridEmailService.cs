using Application.External.SendGridEmail;
using Domain.Models.SendGridEmail;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace External.SendGridEmail
{
    public class SendGridEmailService: ISendGridEmailService
    {
        private readonly IConfiguration _configuration;
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> Execute(SendGridEmailRequestModel model)
        {
            string apiKey = _configuration["SendGridApiKey"];
            string apiUrl = "https://api.sendgrid.com/v3/mail/send";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", $"application/json");
            var emailData = new
            {
                personalizations = new[]
              {
                    new
                    {
                        to = new[]
                        {
                            new { email = "chabeto86@gmail.com" }
                        },
                        subject = "Preuba de registro"
                    }
                },
                from = new
                {
                    email = "chabeto72@hotmail.com"
                },
                content = new[]
              {
                    new
                    {
                        type = "text/html",
                        value = "Hola, este es un correo de prueba enviado desde una aplicación C# usando SendGrid y HttpClient."
                    }
                }
            };

            string emailConten = JsonConvert.SerializeObject(emailData);
            var response = await client.PostAsync(apiUrl, new StringContent(emailConten, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
