using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.CIBDigitalTech
{
   public  class DogBreedAPI
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<string> GetAllBreeds()
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {
                //HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/list/all");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://dog.ceo/api/breeds/list/all");
                HttpResponseMessage response = await client.SendAsync(request);

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

        public async Task<string> GetSubBreed(string breed)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {
       
                HttpResponseMessage response = await client.GetAsync($"https://dog.ceo/api/breed/{breed}/list");

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

        public async Task<string> GetSubBreedRandomImage(string breed)
        {
            string results = string.Empty;
            string errorMessage = string.Empty;

            try
            {

                HttpResponseMessage response = await client.GetAsync($"https://dog.ceo/api/breed/{breed}/images/random");

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
