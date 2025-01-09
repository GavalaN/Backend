using KonyvtarakWPFClient.DTOs;
using KonyvtarakWPFClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace KonyvtarakWPFClient.Services
{
    internal class KonyvtarakService
    {
        public static async Task<List<KonyvtarakDTO>> GetDTOList(HttpClient client)
        {
            return await client.GetFromJsonAsync<List<KonyvtarakDTO>>("Konyvtarak/DTO");
        }

        public static async Task<string> POST(HttpClient client, Konyvtarak ujKonyvtar)
        {
            string url = $"{client.BaseAddress}Konyvtarak";
            string uj = JsonSerializer.Serialize(ujKonyvtar, JsonSerializerOptions.Default);
            var request = new StringContent(uj, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, request);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(content);
                return content;
                
            }
            else
            {
                MessageBox.Show(content);
                return $"Hiba: {content}";
            }
        }

        public static async Task<string> PUT(HttpClient client, Konyvtarak modositKonyvtar)
        {
            string url = $"{client.BaseAddress}Konyvtarak";
            string uj = JsonSerializer.Serialize(modositKonyvtar, JsonSerializerOptions.Default);
            var request = new StringContent(uj, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, request);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(content);
                return content;

            }
            else
            {
                MessageBox.Show(content);
                return $"Hiba: {content}";
            }
        }

        public static async Task<string> DELETE(HttpClient client, Konyvtarak torolKonyvtar)
        {
            string url = $"{client.BaseAddress}Konyvtarak?id={torolKonyvtar.Id}";
            var response = await client.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(content);
                return content;

            }
            else
            {
                MessageBox.Show(content);
                return $"Hiba: {content}";
            }
        }
    }
}
