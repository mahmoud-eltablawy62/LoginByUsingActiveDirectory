# Login MVC by Using Active Directory on Local Server

This project demonstrates how to integrate Active Directory (AD) authentication into an ASP.NET MVC application running on a local server. 
Users can log in using their AD credentials, simplifying the authentication process and enhancing security.

## Key Concepts

- **ASP.NET MVC**: A framework used to build web applications using the Model-View-Controller pattern. This project uses it to create the web application's structure.

- **Active Directory (AD)**: Active Directory is a directory service that provides a centralized location for managing network resources and users.
- It uses a hierarchical structure to organize resources, which include users, groups, computers, and other objects.

- **Local Server**: This project is set up to run on a local server in your network,
-  meaning it’s not intended to be deployed on a cloud service but rather on an internal server within your organization.

## Features

- **Active Directory Authentication**: Users can log in using their AD username and password.

- **Single Sign-On (SSO)**: Once logged in, users can access multiple parts of the application without needing to log in again.

## How It Works

### Setting Up the Project

1. You need to have a .NET development environment (like Visual Studio) to work with this project.
2. Clone the project repository to your local machine:

    ```bash
    git clone https://github.com/yourusername/loginMvcByUsingActiveDirectoryOnLocalServer.git
    cd loginMvcByUsingActiveDirectoryOnLocalServer
    ```

### Configuring the Application

1. **AD Settings**: You need to provide information about your AD server and client ID in the configuration file (`Web.config`).


### Running the Application

1. Build and run the project.
2. Access the application through your web browser using `http://localhost:yourport/Account/Login`.

### Logging In

- On the login page, enter your AD credentials (username and password).
- After logging in, you can access various parts of the application based on your AD permissions.

## Troubleshooting

- **Authentication Issues**: Ensure that the AD server details are correctly configured and that your local server can reach the AD server.

- **Build Errors**: Make sure all necessary libraries and packages are installed and the project builds correctly.


