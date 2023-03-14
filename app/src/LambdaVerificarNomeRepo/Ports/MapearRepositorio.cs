using LambdaVerificarNomeRepo.Contracts;
using LambdaVerificarNomeRepo.Domain;
using System.Text.Json;

namespace LambdaVerificarNomeRepo.Ports
{
    public class MapearRepositorio : IMapearRepositorio
    {
        public List<Repositorio> Mapear(Stream stream)
        {
            return JsonSerializer.Deserialize<List<Repositorio>>(stream);
        }
    }
}
