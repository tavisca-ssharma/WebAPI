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
		  ${IMAGE} = docker.build ${REGISTRY}
           '''
        }      
    }
    stage('DockerHub') {
	steps{
           powershell '''
              docker.withRegistry( 'https://registry.hub.docker.com', ${REGISTRY_CREDENTIALS} ) {
              ${IMAGE}.push()
              }
           '''
      }
    }
  }
}
