using Amazon.CDK;
using Constructs;
using cfnInc = Amazon.CDK.CloudFormation.Include;

namespace CiCdCloudFormationTemplate
{
    public class CiCdCloudFormationTemplateStack : Stack
    {
        internal CiCdCloudFormationTemplateStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var template = new cfnInc.CfnInclude(this, "Template", new cfnInc.CfnIncludeProps
            {
                TemplateFile = "my-template.json",
                PreserveLogicalIds = false
            });
        }
    }
}
