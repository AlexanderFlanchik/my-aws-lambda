using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyLambda;

public class Function
{
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogInformation("MyLambda function invoked.");
        context.Logger.LogInformation($"Route data: {request.RawQueryString}");

        var data = new Message()
        {
            Content = "Hello from AWS Lambda!!!"
        };

        var response = new APIGatewayHttpApiV2ProxyResponse()
        {
            StatusCode = 200,
            Body = JsonConvert.SerializeObject(data)
        };

        return response;
    }
}