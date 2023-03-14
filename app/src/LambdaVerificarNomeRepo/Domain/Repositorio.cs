using System.Text.Json.Serialization;

namespace LambdaVerificarNomeRepo.Domain
{
    public class Repositorio
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
