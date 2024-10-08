﻿using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiCdCloudFormationTemplate
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CiCdCloudFormationTemplateStack(app, "CiCdCloudFormationTemplateStack", new StackProps
            {
                Env = new Amazon.CDK.Environment
                {
                    Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                    Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION"),
                }
            });
            app.Synth();
        }
    }
}
