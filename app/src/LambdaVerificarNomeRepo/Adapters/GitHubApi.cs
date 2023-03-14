using LambdaVerificarNomeRepo.Contracts;

namespace LambdaVerificarNomeRepo.Adapters
{
    public class GitHubApi : IGitHubApi
    {
        public async Task<HttpResponseMessage> ListarRepositorios(string tokenApiGitHub)
        {
            using var httpClient = new HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add("Authorization", $"Bearer {tokenApiGitHub}");
            headers.Add("Accept", "application/vnd.github+json");
            headers.Add("X-GitHub-Api-Version", "2022-11-28");
            headers.Add("User-Agent", ".Net 6");

            var uri = new Uri("https://api.github.com/orgs/MiraiTem/repos");

            var response = await httpClient.GetAsync(uri);

            return response;
        }
    }
}
