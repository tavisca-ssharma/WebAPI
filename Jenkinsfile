pipeline {
  environment {
    registry = "sharmashantanu07/first-docker"
    registryCredential = ‘dockerhub’
    dockerImage = ''
}
  agent { label 'master'
  }
  parameters {
        string (
            name : 'GIT_SSH_PATH',
            defaultValue: 'https://github.com/tavisca-ssharma/WebAPI.git',
            description: ''
        )            
            
         string (
            name : 'SOLUTIION_FILE',
            defaultValue: 'WebApplicationTest.sln',
            description: ''    
        )
        string (
            name : 'NETCORE_VERSION',
            defaultValue: '',
            description: ''    
        )
        string (
            name : 'TEST_PROJECT_PATH',
            defaultValue: 'TestCase/TestCase.csproj',
            description: ''    
        )
    string (
            name : 'PROJECT_PATH',
            defaultValue: 'WebApplicationTest/WebApplicationTest.csproj',
            description: ''
        )
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "Build\nTest\nPublish\nDockerBuild\nDockerHub",
        description: '' 
        ) 
    }
 stages {
    def app
    stage('Build') {	
       when {
              expression {params.RELEASE_ENVIRONMENT == 'Build' || params.RELEASE_ENVIRONMENT=='Run'}
       }
      steps {
        powershell''' 
	    echo \'=======================Restore Project Start=======================\'
            dotnet restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json
            echo \'=====================Restore Project Completed====================\'
            echo \'=======================Build Project Start=======================\'
            dotnet build ${SOLUTION_FILE} -p:Configuration=release -v:q
            echo \'=====================Build Project Completed====================\'
	'''
      }
    }
    stage('Test') {
        steps {    
            powershell'''
              dotnet test ${TEST_PROJECT_PATH}
            '''

        }
    }
    stage('Publish') {
        steps {    
            powershell'''
              dotnet publish ${PROJECT_PATH}
            '''
        }
    }
    stage('DockerBuild') {
        steps {    
            script {
               dockerImage = docker.build registry + ":$BUILD_NUMBER"
        }
        }
    }
    stage('DockerHub') {
	steps{
           script {
              docker.withRegistry( '', registryCredential ) {
              dockerImage.push()
          }
        }
      }
    }
  }
}
