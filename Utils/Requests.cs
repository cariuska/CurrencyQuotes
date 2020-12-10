using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CurrencyQuotes.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyQuotes.Utils
{
    public class Requests
    {
        public Requests(){

        }

        /*
        https://economia.awesomeapi.com.br/json/all
        https://docs.awesomeapi.com.br/api-de-moedas
        */

        public async Task<T> Get<T>(string url, string urlParameters = "") where T : new(){

            //Console.WriteLine("url:"+url);
            
            //Console.WriteLine("urlParameters:"+urlParameters);

            T dadoRetorno = new T();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {

                try{
                    string json = await response.Content.ReadAsStringAsync();

                    json = json.Substring(json.IndexOf(":") + 1);
                    json = json.Substring(0, json.Length - 1);

                    //Console.WriteLine("json:"+json);
                    // Parse the response body.
                    dadoRetorno = JsonConvert.DeserializeObject<T>(json);  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    
                    //Console.WriteLine("{0}", linkeTrack.codigo);
                }catch(Exception e){
                    Console.WriteLine("erro:"+e.StackTrace);

                }
                
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return dadoRetorno;
        }
    }
}