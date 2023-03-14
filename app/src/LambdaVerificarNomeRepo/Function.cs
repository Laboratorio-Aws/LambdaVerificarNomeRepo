using Amazon.Lambda.Core;
using LambdaVerificarNomeRepo.Adapters;
using LambdaVerificarNomeRepo.Contracts;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaVerificarNomeRepo;

public class Function
{
    private readonly IInputHandler _inputHandler;

    public Function()
    {
        _inputHandler = new InputHandler();
    }
    public async Task<Response> FunctionHandler(Input input, ILambdaContext context)
    {
        try
        {
            context.Logger.LogLine("Lambda iniciada");
            context.Logger.LogLine(input.ToString());
            var response = await _inputHandler.Processar(input, context);
            return response;
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}
