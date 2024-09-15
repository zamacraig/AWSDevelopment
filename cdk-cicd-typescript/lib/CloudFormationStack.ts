import { Stack, StackProps } from "aws-cdk-lib";
import { CloudFormationDeployStackSetAction } from "aws-cdk-lib/aws-codepipeline-actions";
import { CloudFormationTemplate } from "aws-cdk-lib/aws-servicecatalog";
import { Construct } from "constructs";

interface CloudFormationStackProps extends StackProps{
    stageName?: string
}

export class CloudFormationStack extends Stack {

    constructor(scope: Construct, id: string, props: StackProps){
        super(scope, id, props)

    }

}