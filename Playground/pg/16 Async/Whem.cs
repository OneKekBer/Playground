using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public record TodoDto
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}

namespace Playground.pg._16_Async.when
{
    internal class Program
    {
        public async static IAsyncEnumerable<TodoDto> GetTodos()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStreamAsync();

            var todos = JsonSerializer.DeserializeAsyncEnumerable<TodoDto>(body);

            await foreach ( var item in todos)
            {
                yield return item;
            }
        }

        public static async void Start()
        {
            var todos = GetTodos();
            await foreach (var item in todos)
            {
                Console.WriteLine(item.title);
            }

        }
    }
}
