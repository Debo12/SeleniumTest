pipeline{
    agent any
    stages{
         stage('checkout code'){
             steps{
                git 'https://github.com/Debo12/SeleniumTest.git'   
             }
        }
        stage('Restore nuget'){
            steps{
                bat label: '', script: '"C:\\Program Files (x86)\\NuGet\\nuget.exe" restore AutomationTestingProject.sln'   
            }
        }
        stage('build'){
            steps{
                bat "\"${tool 'MSBuildLocal'}\" AutomationTestingProject.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"   
            }
        }
        stage('test'){
            steps{
                bat label: '', script: '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\vstest.console.exe" "C:\\Users\\DEBOJYOTI\\source\\repos\\SeleniumTest\\AutomationTestingProject\\bin\\Debug\\AutomationTestingProject.dll"'
            }
        }   
    }
}