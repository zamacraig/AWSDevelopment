import * as cdk from 'aws-cdk-lib';
import { CodeCommitSourceAction } from 'aws-cdk-lib/aws-codepipeline-actions';
import { CodePipeline } from 'aws-cdk-lib/aws-events-targets';
import { CodePipelineSource, ShellStep } from 'aws-cdk-lib/pipelines';
import { Construct } from 'constructs';
import { pipeline } from 'stream/promises';
import { PipelineStage } from './PipelineStage';

export class CdkCicdTypescriptStack extends cdk.Stack {
  constructor(scope: Construct, id: string, props?: cdk.StackProps) {
    super(scope, id, props);

    const pipeline = new cdk.pipelines.CodePipeline(this, 'GithubPipeline', {
      pipelineName: 'GithubPipeline',
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

    const devStage = pipeline.addStage(new PipelineStage(this, 'PipelineStage1', {
      stageName: 'test-CloudFormationStack'
    }))

    const testStage = pipeline.addStage(new PipelineStage(this, 'PipelineStage2', {
      stageName: 'test-LambdaStack'
    }))

  }
}
