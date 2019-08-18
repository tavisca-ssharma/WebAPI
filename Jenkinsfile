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
	      docker tag f44176f0d9bd sharmashantanu07/first-docker:firsttry
              docker login --username=sharmashantanu07 --password=shantanu96
	      docker push sharmashantanu07/first-docker
           '''
      }
    }
  }
}
