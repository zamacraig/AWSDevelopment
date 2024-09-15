import * as cdk from 'aws-cdk-lib';
import { CodeCommitSourceAction } from 'aws-cdk-lib/aws-codepipeline-actions';
import { CodePipeline } from 'aws-cdk-lib/aws-events-targets';
import { CodePipelineSource, ShellStep } from 'aws-cdk-lib/pipelines';
import { Construct } from 'constructs';
import { pipeline } from 'stream/promises';

export class CdkCicdTypescriptStack extends cdk.Stack {
  constructor(scope: Construct, id: string, props?: cdk.StackProps) {
    super(scope, id, props);

    new cdk.pipelines.CodePipeline(this, 'Pipeline', {
      pipelineName: 'AwesomePipeline',
      synth: new ShellStep('Synth', {
        input: CodePipelineSource.gitHub('zamacraig/AWSDevelopment', 'cicd-practice'),
        commands: [
          'cd cdk-cicd-typescript',
          'npm ci',
          'npx cdk synth'
        ],
        primaryOutputDirectory: 'cdk-cicd-typescript/cdk.out'
      })
    })

  }
}
