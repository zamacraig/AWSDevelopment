using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CdkCicd
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CdkCicdStack(app, "CdkCicdStack", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = "224412153406",
                    Region = "us-west-1",
                }
            });
            app.Synth();
        }
    }
}
