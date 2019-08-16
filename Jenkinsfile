pipeline {
  environment {
    RELEASE_ENVIRONMENT = "${params.RELEASE_ENVIRONMENT}"
  }

  agent { label 'master'
  }

  parameters {
        string (
            name : 'GIT_SSH_PATH',
            defaultValue: '',
            description: ''
        )            
            
         string (
            name : 'SOLUTIION_FILE',
            defaultValue: 'develop',
            description: ''    
        )
        string (
            name : 'NETCORE_VERSION',
            defaultValue: '',
            description: ''    
        )
        string (
            name : 'TEST_PROJECT_PATH',
            defaultValue: '',
            description: ''    
        ) 
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "Build\nTest",
        description: '' 
        ) 
    }
 stages {
    stage('Build') {
      when {
              expression { "$env:RELEASE_ENVIRONMENT" == 'Build' }                
        }
      steps {
        powershell'''
            echo '=======================Restore Project Start======================='
            dotnet$env:NETCORE_VERSION restore $env:SOLUTION_FILE --source https://api.nuget.org/v3/index.json
            echo '=====================Restore Project Completed===================='
            echo '=======================Build Project Start======================='
            dotnet$env:NETCORE_VERSION build $env:SOLUTION_FILE -p:Configuration=release -v:q
            echo '=====================Build Project Completed===================='
        '''
      }
    }
    stage('Test') {
       when {
              expression { "$env:RELEASE_ENVIRONMENT" == 'Test' }
       }
        steps {    
            powershell'''
              dotnet$env:NETCORE_VERSION test $env:TEST_PROJECT_PATH
            '''
          script {
              zip zipFile: 'artifacts.zip', archive: false, dir: 'WebApplicationTest/bin/Debug/netcoreapp2.2/publish'
              archiveArtifacts artifacts: 'artifacts.zip', fingerprint: true
          }
        }
    }
  }
}
