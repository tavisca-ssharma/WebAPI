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
            defaultValue: 'sharmashantanu07/first-docker',
            description: ''
        )
    string (
            name : 'REGISTRY_CREDENTIALS',
            defaultValue: 'dockerhub',
            description: ''
        )
    string (
            name : 'DOCKERHUB_USERNAME',
            defaultValue: 'sharmashantanu07',
            description: ''
        )
    string (
            name : 'DOCKERHUB_PASSWORD',
            defaultValue: 'shantanu96',
            description: ''
        )
    string (
            name : 'GIT_SSH_PATH',
            defaultValue: 'https://github.com/tavisca-ssharma/WebAPI.git',
            description: ''
        )
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "Build\nTest\nPublish\nDockerBuild\nDockerHub",
        description: '' 
        ) 
    }
 stages {
     stage('Build') {	
      steps {
        powershell''' 
	    echo \'=======================Restore Project Started=======================\'
            dotnet restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json
            echo \'=====================Restore Project Completed====================\'
            echo \'=======================Build Project Started=======================\'
            dotnet build ${SOLUTION_FILE} -p:Configuration=release -v:q
            echo \'=====================Build Project Completed====================\'
	    echo \'=======================Test Project Started=======================\'
            dotnet test ${TEST_PROJECT_PATH}
            echo \'=====================Test Project Completed====================\'
	    echo \'=======================Publish Project Started=======================\'
            dotnet publish ${PROJECT_PATH}
            echo \'=====================Publish Project Completed====================\'
	'''
      }
    }
    stage('Deploy') {
	steps{
           powershell '''
	          echo \'=====================Docker Image Build Started====================\'
		  docker build --tag=images .
		  echo \'=====================Docker Image Build Completed====================\'
		  echo \'=====================Docker Image Pushing on DockerHub Started====================\'
		  docker tag images sharmashantanu07/first-docker:try
              	  docker login --username=${DOCKERHUB_USERNAME} --password=${DOCKERHUB_PASSWORD}
	          docker push sharmashantanu07/first-docker
		  echo \'=====================Docker Image Pushing on DockerHub Completed====================\'
           '''
        }      
    }
  }
  post() {
    always {
       echo \'=====================Jenkins Workspace Cleaning Started====================\'
       deleteDir()
       echo \'=====================Jenkins Workspace Cleaning Completed====================\'
    }
  }  	
}
