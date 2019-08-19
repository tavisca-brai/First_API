
pipeline
{
    agent any
    parameters 
    {
		string(name: 'JOB_NAME', defaultValue: 'Demo-WebApi', description: 'Name of the current job that is going to run the pipeline.')

        string(name: 'APPLICATION_NAME', defaultValue: 'First_API', description: 'Name of the project that you want to test/deploy/etc.')
        string(name: 'SOLUTION_PATH', defaultValue: 'First_API.sln')
        string(name: 'TEST_PATH', defaultValue: 'First_API_Test/First_API_Test.csproj', description: 'Relative Path of the .csproj file of test project')
        
        string(name: 'DOCKER_HUB_USERNAME', defaultValue: 'bhanur92')
        string(name: 'DOCKER_HUB_CREDENTIALS_ID', defaultValue: 'docker-hub-credentials')
        string(name: 'DOCKER_IMAGE_NAME', defaultValue: 'first-api', description: 'Name of the image to be created')
        string(name: 'DOCKER_IMAGE_TAG', defaultValue: 'latest', description: 'Release information')

        choice(name: 'JOB', choices:  ['Test' , 'Build', 'Create Image'])
    }
    environment
    {
        nugetRepository = 'https://api.nuget.org/v3/index.json'

        restoreCommand = "dotnet restore ${env.SOLUTION_PATH} --source ${env.nugetRepository}"
        buildCommand = "dotnet build ${env.SOLUTION_PATH} -p:Configuration=release -v:n --no-restore"

        artifactsDirectory = "MyArtifacts"
    }
    stages 
    {
        stage('Build') 
        {
            steps
            {    
                powershell(script: "echo '*********Starting Restore and Build***************'")
                powershell(script: '$env:restoreCommand')
                powershell(script: '$env:buildCommand')
                powershell(script: "echo '***************Recovery Finish********************'")
            }
        }
        stage('Test') 
        {
            when
            {
                expression { params.JOB == 'Test'}
            }
            
            steps 
            {
                powershell(script: "dotnet test ${env.TEST_PATH}")
            }
        }
        stage('Publish') 
        {
            steps 
            {
                powershell(script: "dotnet publish ${env.APPLICATION_NAME} -c Release -o ${env.artifactsDirectory} --no-restore")
            }
        }
		stage('Set-up for docker CustomImage creation')
        {
            steps
            {
                powershell "mv Dockerfile ${env.APPLICATION_NAME}/${env.artifactsDirectory}"
            }
        }
        stage('Build Custom Docker Image')
        {
            steps 
            {
                script 
                {
                    dir("${env.APPLICATION_NAME}/${env.artifactsDirectory}") 
                    {
                        powershell "docker build -t ${env.DOCKER_HUB_USERNAME}/${env.DOCKER_IMAGE_NAME}:${env.DOCKER_IMAGE_TAG} --build-arg APPLICATION_NAME_TO_BE_HOSTED=${env.APPLICATION_NAME} ."
                    }
                }
            }
        }
        stage('Push Docker CustomImage to DockerIO registry') 
        {
            steps {
                script {
                    docker.withRegistry('https://www.docker.io/', "${env.DOCKER_HUB_CREDENTIALS_ID}") 
                    {
                        powershell "docker push ${env.DOCKER_HUB_USERNAME}/${env.DOCKER_IMAGE_NAME}:${env.DOCKER_IMAGE_TAG}"   
                    }
                }
            }
        }
    }
    post
    {
        always
        {
            deleteDir()
        }
    }
}
