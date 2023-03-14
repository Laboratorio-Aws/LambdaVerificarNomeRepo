using LambdaVerificarNomeRepo.Domain;

namespace LambdaVerificarNomeRepo.Contracts
{
    public interface IMapearRepositorio
    {
        public List<Repositorio> Mapear(Stream stream);
    }
}
