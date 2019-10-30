using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo_Ble
{
    class Connection
    {

        public async Task<String> getToken(String usuario, String senha)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.furb.br");
                MD5 md5 = MD5.Create();
                string hash = GetMd5Hash(md5, senha);
                string jsonData = creatJason(usuario, hash);  
               

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/user/login", content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {
                return "405";
            }            
        }

        public String creatJason(String usuario, String senha)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter writer = new JsonTextWriter(sw) ;
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("login");
            writer.WriteValue(usuario + "@furb.br");
            writer.WritePropertyName("password");
            writer.WriteValue(senha);
            writer.WriteEnd();
            return sb.ToString().Trim();
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


    }
}
