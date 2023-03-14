namespace LambdaVerificarNomeRepo.Contracts
{
    public interface IGitHubApi
    {
        Task<HttpResponseMessage> ListarRepositorios(string tokenApiGitHub);
    }
}
