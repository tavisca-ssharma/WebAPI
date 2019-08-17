pipeline {
  environment {
    registry = "sharmashantanu07/first-docker"
    registryCredential = 'dockerhub'
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
        choices: "DockerBuild\nDockerHub",
        description: '' 
        ) 
    }
 stages {
    stage('DockerBuild') {
	steps{
           powershell '''
		   dockerImage = docker.build("${registry}")
           '''
        }      
    }
    stage('DockerHub') {
	steps{
           powershell '''
              docker.withRegistry( 'https://registry.hub.docker.com', 'registryCredential' ) {
	      echo 'Helllllllllllllllloooooooooooo'
              dockerImage.push()
              }
           '''
      }
    }
  }
}
