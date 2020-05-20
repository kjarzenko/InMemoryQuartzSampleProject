using System.Threading.Tasks;

namespace InMemoryQuartzSampleWebAPI.Logic
{
    public interface ISimpleRandomDataGeneratorLogic
    {
        Task<string> GenerateData();
    }
}