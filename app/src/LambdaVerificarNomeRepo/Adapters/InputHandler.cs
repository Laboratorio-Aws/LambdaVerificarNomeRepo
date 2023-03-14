using Amazon.Lambda.Core;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using LambdaVerificarNomeRepo.Contracts;
using LambdaVerificarNomeRepo.Ports;
using System.Text.Json;

namespace LambdaVerificarNomeRepo.Adapters
{
    public class InputHandler : IInputHandler
    {
        private readonly IAmazonSecretsManager _amazonSecretsManager;
        private readonly IGitHubApi _gitHubApi;
        private readonly IMapearRepositorio _mapearRepositorio;
        public InputHandler()
        {
            _amazonSecretsManager = new AmazonSecretsManagerClient();
            _gitHubApi = new GitHubApi();
            _mapearRepositorio = new MapearRepositorio();
        }
        public async Task<Response> Processar(Input input, ILambdaContext context)
        {
            context.Logger.LogLine("Obtendo token api github");
            var tokenApiGitHub = await _amazonSecretsManager.GetSecretValueAsync(new GetSecretValueRequest { SecretId = "TokenApiGitHub" });

            context.Logger.LogLine("Listar repositorios github");
            var responseGithub = await _gitHubApi.ListarRepositorios(tokenApiGitHub.SecretString);

            var responseStream = await responseGithub.Content.ReadAsStreamAsync();

            context.Logger.LogLine("Lista dos repositorios encontrados");
            var repositorios = _mapearRepositorio.Mapear(responseStream);
            context.Logger.LogLine(JsonSerializer.Serialize(repositorios));

            return new Response { StatusCode = 200, Body = "Lambda Finalizada" };
        }
    }
}
