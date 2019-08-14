
pipeline
{
    agent any
    parameters 
    {
        string(name: 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-brai/First_API.git')
        string(name: 'SOLUTION_FILE_PATH', defaultValue: 'First_API.sln')
        string(name: 'TEST_FILE_PATH', defaultValue: 'First_API_Test/First_API_Test.csproj')
        choice(name: 'Job', choices: ["Build","Test"])
    }
    stages
    {
        stage('Build')
        {
            steps
            {
                sh '''dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
                dotnet build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n'''
            }
        }
        stage('Test')
        {
            when
            {
                expression { params.Job == "Test" }
            }
            steps
            {
                sh 'dotnet test ${TEST_FILE_PATH}'
            }
        }
        stage('Pubish')
        {
            steps
            {
                sh 'dotnet publish --framework netcoreapp2.1 --configuration Release -o bin\Release\PublishOutput'
            }
        }
    }
}
