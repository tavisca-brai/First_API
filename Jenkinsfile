
pipeline
{
    agent any
    parameters 
    {
        string(name: 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-brai/First_API.git')
        string(name: 'SOLUTION_FILE_PATH', defaultValue: 'First_API.sln')
        string(name: 'TEST_FILE_PATH', defaultValue: 'First_API_Test/First_API_Test.csproj')
        choice(name: 'Job', choices: ["Build","Test"])
        string(name: 'NUGET_REPO', defaultValue: 'https://api.nuget.org/v3/index.json')
    }
    environment
    {
        projectToBePublished = 'First_API'
        restoreCommand = 'dotnet restore $env:SOLUTION_PATH --source $env:NUGET_REPO'
        buildCommand = 'dotnet build $env:SOLUTION_PATH -p:Configuration=release -v:n'
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
                powershell(script: 'dotnet test $env:TEST_PATH')
            }
        }
        stage('Publish') 
        {
            steps 
            {
                powershell(script: 'dotnet publish $env:projectToBePublished -c Release -o artifacts')
            }
        }
        stage('Archive')
        {
            steps
            {
                powershell(script: 'compress-archive DemoWebApp/artifacts publish.zip -Update')
                archiveArtifacts artifacts: 'publish.zip'    
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
