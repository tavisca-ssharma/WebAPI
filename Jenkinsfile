pipeline {
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
            name : 'REGISTRY',
            defaultValue: 'https://registry.hub.docker.com/sharmashantanu07/first-docker',
            description: ''
        )
    string (
            name : 'REGISTRY_CREDENTIALS',
            defaultValue: 'dockerhub',
            description: ''
        )
    string (
            name : 'IMAGE',
            defaultValue: '',
            description: ''
        )
    string (
            name : 'GIT_SSH_PATH',
            defaultValue: 'https://github.com/tavisca-ssharma/WebAPI.git',
            description: ''
        )
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "DockerBuild\nDockerHub",
        description: '' 
        ) 
    }
 stages {
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
	steps{
           powershell '''
		  docker build --tag=images .
           '''
        }      
    }
    stage('DockerHub') {
	steps{
           powershell '''
	      docker tag f44176f0d9bd sharmashantanu07/first-docker:images
              docker login --username=sharmashantanu07 --password=shantanu96
	      docker push sharmashantanu07/first-docker
           '''
      }
    }
  }
}
