pipeline {
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
    string (
            name : 'PROJECT_PATH',
            defaultValue: 'WebApplicationTest/WebApplicationTest.csproj',
            description: ''
        )
        choice(
        name: 'RELEASE_ENVIRONMENT',
        choices: "Build\nTest\nPublish\nRun",
        description: '' 
        ) 
    }
 stages {
    stage('Build') {	
       when {
              expression {params.RELEASE_ENVIRONMENT == 'Build' }
       }
      steps {
        powershell label: '', script: '''echo \'=======================Restore Project Start=======================\'
            dotnet${NETCORE_VERSION} restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json
            echo \'=====================Restore Project Completed====================\'
            echo \'=======================Build Project Start=======================\'
            dotnet${NETCORE_VERSION} build ${SOLUTION_FILE} -p:Configuration=release -v:q
            echo \'=====================Build Project Completed====================\'
'''
      }
    }
    stage('Test') {
       when {
              expression {params.RELEASE_ENVIRONMENT == 'Test' }
       }
        steps {    
            powershell'''
              dotnet${NETCORE_VERSION} test ${TEST_PROJECT_PATH}
            '''

        }
    }
    stage('Publish') {
       when {
              expression {params.RELEASE_ENVIRONMENT == 'Publish' }
       }
        steps {    
            powershell'''
              dotnet${NETCORE_VERSION} publish ${PROJECT_PATH}
            '''
          
        }
    }
    stage('Run') {
       when {
              expression {params.RELEASE_ENVIRONMENT == 'Run' }
       }
        steps {    
            powershell'''
              dotnet run --project C:/Program Files (x86)/Jenkins/workspace/Testing_Jenkins
            '''
        }
    }
  }
}
