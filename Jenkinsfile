pipeline {
    agent any

    environment {
        // Chemin du SDK .NET
        DOTNET_HOME = "/usr/share/dotnet"
        PATH = "${env.DOTNET_HOME}:${env.PATH}"
    }

    stages {
        stage('Restore Dependencies') {
            steps {
                script {
                    echo "Restoring dependencies..."
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build Project') {
            steps {
                script {
                    echo "Building the project..."
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Run Tests') {
            steps {
                script {
                    echo "Running tests..."
                    sh 'dotnet test --logger trx'
                }
            }
        }

        stage('Publish Artifacts') {
            steps {
                script {
                    echo "Publishing the application..."
                    sh 'dotnet publish --configuration Release --output ./publish'
                }
            }
        }
    }

    post {
        always {
            echo "Pipeline finished."
        }
        success {
            echo "Pipeline executed successfully!"
        }
        failure {
            echo "Pipeline failed."
        }
    }
}
