using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CicdFirstProject
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CicdFirstProjectStack(app, "CicdFirstProjectStack", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                    Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION"),
                }
                
                /*
                Env = new Amazon.CDK.Environment
                {
                    Account = "224412153406",
                    Region = "us-east-1",
                }
                */
            });
            app.Synth();
        }
    }
}
