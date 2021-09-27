using Flurl;
using Flurl.Http;
using Refit;
using System;
using System.Threading.Tasks;

namespace RestLibs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = RestService.For<ICepApiService>("https://viacep.com.br");
            string meuCep = "81940320";
            Console.WriteLine($"Consultando dados do CEP: {meuCep}");

            var address = await client.GetAddressAsync(meuCep);
            Console.Write($"\nLogradouro: {address.Logradouro}\nBairro: {address.Bairro}\nEstado: {address.Uf}\nCódigo Ibge: {address.Ibge}");
            Console.WriteLine(Environment.NewLine);

            var url = "https://pokeapi.co/api/v2/pokemon";

            var result = await url
                .SetQueryParams(new { limit = 50 })
                .GetJsonAsync<NamedAPIResourceList>();

            Console.WriteLine($"Count: {result.Count}");

            foreach (var item in result.Results)
            {
                Console.WriteLine($"Name: {item.Name}\nUrl: { item.Url}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}