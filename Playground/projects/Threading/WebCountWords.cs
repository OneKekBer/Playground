using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.Threading.webcount
{

    interface IInput
    {
        public HashSet<string> GetLinks(); 
    }

    class ConsoleInput() : IInput
    {
        public HashSet<string> GetLinks()
        {
            string str = Console.ReadLine();

            var links = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            return links;
        }
    }

    class Core
    {
        IInput InputHandler { get; set; }

        public Core(IInput input)
        {
            InputHandler = input;
        }

        public async Task<int> GetLengthOfPage(HttpClient client, string link)
        {
            try
            {
                using var response = await client.GetAsync(link);

                var content = await response.Content.ReadAsStringAsync();

                return content.Length;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return 0;
            }

        }


        public void Display(int[] arr)
        {

        }

        public async void Start()
        {
            var result = new List<Task<int>>();

            var links = InputHandler.GetLinks();


            using (var client = new HttpClient())
            {
                foreach (var link in links)
                {
                    result.Add(GetLengthOfPage(client, link));  
                }

            }
            var total = Task.WhenAll(result);

            Display(result);
        }

        private void Display(List<Task<int>> res)
        {
            foreach (var item in res)
            {
                Console.WriteLine(item.Result);
            }
        }
    }

    class Program
    {


        public static void Start()
        {
            Core core = new Core(new ConsoleInput());

            core.Start();
        }
    }
}
