using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CurrencyQuotes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CurrencyQuotes.Models;
using Microsoft.EntityFrameworkCore;
using CurrencyQuotes.Utils;
using CurrencyQuotes.Services;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CurrencyQuotes.Utils
{
    public static class Util
    {

        public static IConfiguration Configuration { get; set; }

        private static string GetHeader(HttpRequest Request, string key){
                        
            //Request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();

            StringValues value = "";
            Request.Headers.TryGetValue(key, out value);
            return value;
        }

        private static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


    }
}