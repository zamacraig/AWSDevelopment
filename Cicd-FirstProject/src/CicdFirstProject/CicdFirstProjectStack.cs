using Amazon.CDK;
using Constructs;
using Amazon.CDK.AWS.Lambda;

namespace CicdFirstProject
{
    public class CicdFirstProjectStack : Stack
    {
        internal CicdFirstProjectStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Define the Lambda function resource
            var myFunction = new Function(this, "HelloWorldFunction", new FunctionProps
            {
                Runtime = Runtime.NODEJS_20_X, // Provide any supported Node.js runtime
                Handler = "index.handler",
                Code = Code.FromInline(@"
                exports.handler = async function(event) {
                    return {
                    statusCode: 200,
                    body: JSON.stringify('Hello World!'),
                    };
                };
                "),
            });

             // Define the Lambda function URL resource
            var myFunctionUrl = myFunction.AddFunctionUrl(new FunctionUrlOptions
            {
                AuthType = FunctionUrlAuthType.NONE
            });

            // Define a CloudFormation output for your URL
            new CfnOutput(this, "myFunctionUrlOutput", new CfnOutputProps
            {
                Value = myFunctionUrl.Url
            });
        }
    }
}
