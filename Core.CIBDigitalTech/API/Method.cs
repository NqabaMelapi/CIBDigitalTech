using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.CIBDigitalTech.API
{
    public class Method
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> Get(string url)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
                return errorMessage;
            }

            return results;
        }

        public async Task<string> Post(string url)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
                return errorMessage;
            }

            return results;
        }

        public async Task<string> Put(string url)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
                return errorMessage;
            }

            return results;
        }

        public async Task<string> Delete(string url)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
                return errorMessage;
            }

            return results;
        }
    }
}
