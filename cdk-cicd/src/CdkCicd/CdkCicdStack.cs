using Amazon.CDK;
using Amazon.CDK.AWS.CodeBuild;
using Amazon.CDK.AWS.CodeCommit;
using Amazon.CDK.Pipelines;
using Constructs;

namespace CdkCicd
{
    public class CdkCicdStack : Stack
    {
        internal CdkCicdStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            //var repository = Repository.FromRepositoryName(this, "repository", "<CODECOMMIT-REPOSITORY-NAME>");
    
            // This construct creates a pipeline with 3 stages: Source, Build, and UpdatePipeline
            var pipeline = new CodePipeline(this, "pipeline", new CodePipelineProps
            {
                PipelineName = "LambdaPipeline",
                SelfMutation = true,
    
                // Synth represents a build step that produces the CDK Cloud Assembly.
                // The primary output of this step needs to be the cdk.out directory generated by the cdk synth command.
                Synth = new CodeBuildStep("Synth", new CodeBuildStepProps
                {
                    // The files downloaded from the repository will be placed in the working directory when the script is executed
                    Input = CodePipelineSource.Connection(
                        "AWSDevelopment",
                        "main",
                        new ConnectionSourceOptions { ConnectionArn = "arn:aws:codeconnections:us-east-1:224412153406:connection/d5f5c5ac-9840-4709-8f08-c2b4c707352b" }
                        ),
    
                    // Commands to run to generate CDK Cloud Assembly
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth" },
    
                    // Build environment configuration
                    BuildEnvironment = new BuildEnvironment
                    {
                        BuildImage = LinuxBuildImage.AMAZON_LINUX_2_4,
                        ComputeType = ComputeType.MEDIUM,
    
                        // Specify true to get a privileged container inside the build environment image
                        Privileged = true
                    }
                })
            });
        }
    }
}
