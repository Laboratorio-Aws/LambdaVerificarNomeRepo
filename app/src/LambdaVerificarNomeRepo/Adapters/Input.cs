using System.Text.Json;

namespace LambdaVerificarNomeRepo.Adapters
{
    public class Input
    {
        public string NomeTemplate { get; set; }
        public string NomeRepositorio { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
