using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace rest_client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var repositories = ProcessRepositories().Result;

            foreach (var repo in repositories)
            {
                Console.Write($"{repo.Name} ");
                Console.Write($"{repo.Description} ");
                Console.Write($"{repo.GitHubHomeUrl} ");
                Console.Write($"{repo.Homepage} ");
                Console.Write($"{repo.Watchers} ");
                Console.Write($"{repo.LastPush}\n");
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "tatwd repos reporter");

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
            var streamTask = client.GetStreamAsync("https://api.github.com/users/tatwd/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;

            return repositories;
        }
    }

}