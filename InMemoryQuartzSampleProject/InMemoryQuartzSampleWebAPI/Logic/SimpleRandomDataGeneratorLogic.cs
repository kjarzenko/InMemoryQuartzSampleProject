using System;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryQuartzSampleWebAPI.Logic
{
    public class SimpleRandomDataGeneratorLogic : ISimpleRandomDataGeneratorLogic
    {
        const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private Random random;

        public SimpleRandomDataGeneratorLogic()
        {
            random = new Random();
        }

        public async Task<string> GenerateData()
        {
            return await Task.Run(() =>
            {
                var length = random.Next(0, 20);
                return new string(Enumerable.Repeat(Chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            });
        }
    }
}