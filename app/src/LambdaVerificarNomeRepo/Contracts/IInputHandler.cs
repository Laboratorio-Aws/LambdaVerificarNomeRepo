using Amazon.Lambda.Core;
using LambdaVerificarNomeRepo.Adapters;

namespace LambdaVerificarNomeRepo.Contracts
{
    public interface IInputHandler
    {
        Task<Response> Processar(Input input, ILambdaContext context);
    }
}
