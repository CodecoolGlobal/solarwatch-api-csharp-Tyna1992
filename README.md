<p align="center">
  <img src="https://img.icons8.com/external-tal-revivo-regular-tal-revivo/96/external-readme-is-a-easy-to-build-a-developer-hub-that-adapts-to-the-user-logo-regular-tal-revivo.png" width="100" />
</p>
<p align="center">
    <h1 align="center">SOLARWATCH-API-CSHARP-TYNA1992</h1>
</p>
<p align="center">
    <em><code>SolarWatch API - A C# project for solar data management</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/CodecoolGlobal/solarwatch-api-csharp-Tyna1992?style=flat&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/CodecoolGlobal/solarwatch-api-csharp-Tyna1992?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/CodecoolGlobal/solarwatch-api-csharp-Tyna1992?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/CodecoolGlobal/solarwatch-api-csharp-Tyna1992?style=flat&color=0080ff" alt="repo-language-count">
<p>
<p align="center">
		<em>Developed with the software and tools below.</em>
</p>
<p align="center">
	<img src="https://img.shields.io/badge/JavaScript-F7DF1E.svg?style=flat&logo=JavaScript&logoColor=black" alt="JavaScript">
	<img src="https://img.shields.io/badge/HTML5-E34F26.svg?style=flat&logo=HTML5&logoColor=white" alt="HTML5">
	<img src="https://img.shields.io/badge/Vite-646CFF.svg?style=flat&logo=Vite&logoColor=white" alt="Vite">
	<img src="https://img.shields.io/badge/React-61DAFB.svg?style=flat&logo=React&logoColor=black" alt="React">
	<img src="https://img.shields.io/badge/ESLint-4B32C3.svg?style=flat&logo=ESLint&logoColor=white" alt="ESLint">
	<img src="https://img.shields.io/badge/Docker-2496ED.svg?style=flat&logo=Docker&logoColor=white" alt="Docker">
	<img src="https://img.shields.io/badge/GitHub%20Actions-2088FF.svg?style=flat&logo=GitHub-Actions&logoColor=white" alt="GitHub%20Actions">
	<img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON">
</p>
<hr>

##  Quick Links

> - [Overview](#overview)
> - [Features](#features)
> - [Repository Structure](#repository-structure)
> - [Modules](#modules)
> - [Getting Started](#getting-started)
>   - [Installation](#installation)
>   - [Running solarwatch-api-csharp-Tyna1992](#running-solarwatch-api-csharp-tyna1992)
>   - [Tests](#tests)
> - [Project Roadmap](#project-roadmap)
> - [Contributing](#contributing)
> - [License](#license)
> - [Acknowledgments](#acknowledgments)

---

##  Overview

<code>SolarWatch API is a comprehensive project for managing solar data using C#. It provides endpoints for user registration, authentication, and retrieval of solar data. The project is built with a robust architecture, ensuring scalability and maintainability.</code>

---

## Features

<code>
- User Registration and Authentication
- Solar Data Retrieval
- Integration with External GeoCoding APIs
- JSON Processing and Data Storage
- Unit and Integration Testing
- Docker Support for Containerization
- CI/CD with GitHub Actions
</code>

---

## Repository Structure

```sh
└── solarwatch-api-csharp-Tyna1992/
    ├── .github
    │   └── workflows
    │       └── dotnet.yml
    ├── README.md
    ├── SolarTests
    │   ├── InetgrationTests
    │   │   ├── AuthControllerTests.cs
    │   │   ├── SolarControllerTests.cs
    │   │   ├── SolarWebApplicationFactory.cs
    │   │   └── TestAuthHandler.cs
    │   ├── SolarTests.csproj
    │   └── Usings.cs
    ├── SolarUnitTests
    │   ├── CoordinatesTests.cs
    │   ├── SolarDataTests.cs
    │   ├── SolarUnitTests.csproj
    │   └── Usings.cs
    ├── SolarWatch
    │   ├── Contracts
    │   │   ├── RegistrationRequest.cs
    │   │   └── RegistrationResponse.cs
    │   ├── Controllers
    │   │   ├── AuthController.cs
    │   │   └── SolarController.cs
    │   ├── Data
    │   │   ├── GeoCoordinatesContext.cs
    │   │   └── UserContext.cs
    │   ├── Dockerfile
    │   ├── Migrations
    │   │   ├── 20240221165425_InitialCreate.Designer.cs
    │   │   ├── 20240221165425_InitialCreate.cs
    │   │   ├── 20240221200705_ChangeData.Designer.cs
    │   │   ├── 20240221200705_ChangeData.cs
    │   │   ├── GeoCoordinatesContextModelSnapshot.cs
    │   │   └── User
    │   │       ├── 20240308085634_initialMigration.Designer.cs
    │   │       ├── 20240308085634_initialMigration.cs
    │   │       ├── 20240308091547_addRoles.Designer.cs
    │   │       ├── 20240308091547_addRoles.cs
    │   │       └── UserContextModelSnapshot.cs
    │   ├── Model
    │   │   ├── City.cs
    │   │   ├── GeoCoordinates.cs
    │   │   ├── JwtSettings.cs
    │   │   ├── SolarWatch.cs
    │   │   └── SunriseSunset.cs
    │   ├── Program.cs
    │   ├── Properties
    │   │   └── launchSettings.json
    │   ├── Services
    │   │   ├── Authentication
    │   │   │   ├── AuthRequest.cs
    │   │   │   ├── AuthResponse.cs
    │   │   │   ├── AuthResult.cs
    │   │   │   ├── AuthService.cs
    │   │   │   ├── AuthenticationSeeder.cs
    │   │   │   ├── IAuthService.cs
    │   │   │   ├── ITokenService.cs
    │   │   │   └── Tokenservice.cs
    │   │   ├── GeoCodingApi.cs
    │   │   ├── IGeoCodingApi.cs
    │   │   ├── IJsonProcessor.cs
    │   │   ├── ISunApi.cs
    │   │   ├── JsonProcessor.cs
    │   │   ├── Repositories
    │   │   │   ├── CityRepository.cs
    │   │   │   ├── ICityRepository.cs
    │   │   │   ├── ISunsetSunriseRepository.cs
    │   │   │   └── SunriseSunsetRepository.cs
    │   │   └── SunApi.cs
    │   ├── SolarWatch.csproj
    │   ├── appsettings.Development.json
    │   └── appsettings.json
    ├── SolarWatch.sln
    ├── SolarWatchClient
    │   ├── .eslintrc.cjs
    │   ├── .gitignore
    │   ├── README.md
    │   ├── index.html
    │   ├── package-lock.json
    │   ├── package.json
    │   ├── public
    │   │   └── vite.svg
    │   ├── src
    │   │   ├── App.css
    │   │   ├── App.jsx
    │   │   ├── Components
    │   │   │   └── LogoutButton.jsx
    │   │   ├── Pages
    │   │   │   ├── All.jsx
    │   │   │   ├── Home.jsx
    │   │   │   ├── Login.jsx
    │   │   │   ├── Registration.jsx
    │   │   │   └── SolarData.jsx
    │   │   ├── assets
    │   │   │   └── react.svg
    │   │   ├── index.css
    │   │   └── main.jsx
    │   └── vite.config.js
    └── global.json
```

---

## Modules




<details closed><summary>SolarTests.InetgrationTests</summary>

| File                                                                                                                                                                    | Summary                         |
| ---                                                                                                                                                                     | ---                             |
| [SolarControllerTests.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarTests/InetgrationTests/SolarControllerTests.cs)             | Contains integration tests for the `SolarController` to ensure the correctness of endpoints related to solar data retrieval. |
| [AuthControllerTests.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarTests/InetgrationTests/AuthControllerTests.cs)               | Contains integration tests for the `AuthController` to verify user authentication and registration functionalities. |
| [SolarWebApplicationFactory.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarTests/InetgrationTests/SolarWebApplicationFactory.cs) | Provides a custom `WebApplicationFactory` for configuring the test server and dependencies used in integration tests. |
| [TestAuthHandler.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarTests/InetgrationTests/TestAuthHandler.cs)                       | Implements a test authorization handler to mock authentication and authorization in integration tests. |

</details>


<details closed><summary>SolarWatch</summary>

| File                                                                                                                                                 | Summary                         |
| ---                                                                                                                                                  | ---                             |
| [Program.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Program.cs)                                     | Contains the entry point for the application, setting up the web host and configuring services and middleware. |

</details>


<details closed><summary>SolarWatch.Model</summary>

| File                                                                                                                                 | Summary                         |
| ---                                                                                                                                  | ---                             |
| [SolarWatch.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Model/SolarWatch.cs)         | Represents the main model for the solar watch data, including properties and methods for solar information. |
| [GeoCoordinates.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Model/GeoCoordinates.cs) | Defines a model for geographical coordinates, including latitude and longitude properties. |
| [JwtSettings.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Model/JwtSettings.cs)       | Contains settings related to JWT (JSON Web Token) authentication, including secret keys and token expiration. |
| [SunriseSunset.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Model/SunriseSunset.cs)   | Represents the data model for sunrise and sunset times, including properties for storing these values. |
| [City.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Model/City.cs)                     | Defines the model for a city, including properties such as name, country, and geographical coordinates. |

</details>


<details closed><summary>SolarWatch.Contracts</summary>

| File                                                                                                                                                 | Summary                         |
| ---                                                                                                                                                  | ---                             |
| [RegistrationResponse.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Contracts/RegistrationResponse.cs) | Defines the structure for the response returned after a user registration, including properties for status and messages. |
| [RegistrationRequest.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Contracts/RegistrationRequest.cs)   | Contains the data structure for a user registration request, including properties for user details such as username, password, and email. |

</details>

<details closed><summary>SolarWatch.Services</summary>

| File                                                                                                                                    | Summary                                                                                           |
| ---                                                                                                                                     | ---                                                                                               |
| [JsonProcessor.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/JsonProcessor.cs)   | Provides methods for processing JSON data, including serialization and deserialization routines.  |
| [IGeoCodingApi.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/IGeoCodingApi.cs)   | Defines the interface for geocoding services, specifying methods for obtaining geographic data.   |
| [SunApi.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/SunApi.cs)                 | Implements methods for interacting with the Sun API to retrieve sunrise and sunset information.   |
| [IJsonProcessor.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/IJsonProcessor.cs) | Defines the interface for JSON processing, specifying methods for handling JSON data.            |
| [ISunApi.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/ISunApi.cs)               | Defines the interface for Sun API services, specifying methods for retrieving solar information.  |
| [GeoCodingApi.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/GeoCodingApi.cs)     | Implements methods for interacting with a geocoding API to obtain location-based data.            |

</details>


<details closed><summary>SolarWatch.Services.Authentication</summary>

| File                                                                                                                                                               | Summary                                                                                              |
| ---                                                                                                                                                                | ---                                                                                                  |
| [AuthRequest.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/AuthRequest.cs)                   | Represents the data structure for authentication requests, including username and password.          |
| [Tokenservice.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/Tokenservice.cs)                 | Provides methods for generating and validating JWT tokens for authenticated users.                   |
| [IAuthService.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/IAuthService.cs)                 | Defines the interface for authentication services, specifying methods for user authentication.       |
| [ITokenService.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/ITokenService.cs)               | Defines the interface for token services, specifying methods for handling JWT tokens.                |
| [AuthResponse.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/AuthResponse.cs)                 | Represents the data structure for authentication responses, including the JWT token and user details.|
| [AuthResult.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/AuthResult.cs)                     | Represents the result of an authentication attempt, including success status and error messages.     |
| [AuthenticationSeeder.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/AuthenticationSeeder.cs) | Seeds initial authentication data, such as default users and roles, into the system.                 |
| [AuthService.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Authentication/AuthService.cs)                   | Implements methods for user authentication, including login and registration functionalities.         |

</details>


<details closed><summary>SolarWatch.Services.Repositories</summary>

| File                                                                                                                                                                     | Summary                                                                                                       |
| ---                                                                                                                                                                      | ---                                                                                                           |
| [ICityRepository.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Repositories/ICityRepository.cs)                   | Defines the interface for operations related to city data storage and retrieval in the application.           |
| [ISunsetSunriseRepository.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Repositories/ISunsetSunriseRepository.cs) | Defines the interface for operations related to sunrise and sunset data storage and retrieval in the app.     |
| [CityRepository.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Repositories/CityRepository.cs)                     | Implements the city repository interface, providing methods to interact with city data in the database.        |
| [SunriseSunsetRepository.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Services/Repositories/SunriseSunsetRepository.cs)   | Implements the sunrise and sunset repository interface, handling storage and retrieval of daylight data.       |

</details>

<details closed><summary>SolarWatch.Data</summary>

| File                                                                                                                                              | Summary                                                                                               |
| ---                                                                                                                                               | ---                                                                                                   |
| [GeoCoordinatesContext.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Data/GeoCoordinatesContext.cs) | Defines the database context for managing GeoCoordinates data, including configurations and entity sets. |
| [UserContext.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Data/UserContext.cs)                     | Defines the database context for managing User data, including configurations and entity sets.          |

</details>


<details closed><summary>SolarWatch.Controllers</summary>

| File                                                                                                                                         | Summary                                                                                      |
| ---                                                                                                                                          | ---                                                                                          |
| [AuthController.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Controllers/AuthController.cs)   | Controller responsible for handling authentication-related HTTP requests and responses.       |
| [SolarController.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatch/Controllers/SolarController.cs) | Controller responsible for managing solar-related data and operations in the API endpoints.  |

</details>


<details closed><summary>SolarWatchClient.src</summary>

| File                                                                                                                     | Summary                                                                                          |
| ---                                                                                                                      | ---                                                                                              |
| [App.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/App.jsx)     | Entry point component for the SolarWatch client application, handling main application logic.     |
| [App.css](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/App.css)     | CSS stylesheet for styling the App component and its children within the SolarWatch client app.  |
| [index.css](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/index.css) | CSS stylesheet for styling the overall index.html page of the SolarWatch client application.     |
| [main.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/main.jsx)   | Main entry point for rendering the SolarWatch client application within the browser environment.  |

</details>




<details closed><summary>SolarWatchClient.src.Pages</summary>

| File                                                                                                                                         | Summary                                                                                     |
| ---                                                                                                                                          | ---                                                                                         |
| [Login.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/Pages/Login.jsx)               | Component responsible for handling user login functionality within the SolarWatch client app. |
| [SolarData.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/Pages/SolarData.jsx)       | Component for displaying solar data retrieved from the SolarWatch API in the client app.     |
| [Registration.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/Pages/Registration.jsx) | Component for handling user registration process within the SolarWatch client app.           |
| [Home.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/Pages/Home.jsx)                 | Home page component providing an overview or landing page functionality for the app.         |
| [All.jsx](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarWatchClient/src/Pages/All.jsx)                   | Component for displaying all available data or items in the SolarWatch client application.   |

</details>


<details closed><summary>.github.workflows</summary>

| File                                                                                                                    | Summary                                                                                              |
| ---                                                                                                                     | ---                                                                                                  |
| [dotnet.yml](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/.github/workflows/dotnet.yml) | GitHub Actions workflow file for CI/CD purposes using .NET tools, likely including build and test steps. |

</details>


<details closed><summary>SolarUnitTests</summary>

| File                                                                                                                                       | Summary                                                         |
| ---                                                                                                                                        | ---                                                             |
| [SolarUnitTests.csproj](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarUnitTests/SolarUnitTests.csproj) | Project file for the unit tests of the SolarWatch API.           |
| [CoordinatesTests.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarUnitTests/CoordinatesTests.cs)     | Test cases for testing coordinate-related functionality.         |
| [SolarDataTests.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarUnitTests/SolarDataTests.cs)         | Test cases for SolarData-related functionality.                  |
| [Usings.cs](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/master/SolarUnitTests/Usings.cs)                         | File likely containing using directives for unit tests.          |

</details>


---

## Getting Started

***Requirements***

Ensure you have the following dependencies installed on your system:

* **.NET**: `7.0`
* **Node.js**
* **npm**

### Installation

1. Clone the solarwatch-api-csharp-Tyna1992 repository:

```sh
git clone https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992
```

2. Change to the project directory:

```sh
cd solarwatch-api-csharp-Tyna1992
```

3. Install the dependencies:

```sh
dotnet build
```
4. Install frontend dependencies:
 ```sh
cd SolarWatchClient
npm install
```
### Running solarwatch-api-csharp-Tyna1992

Use the following command to run solarwatch-api-csharp-Tyna1992:

```sh
dotnet run
```
```sh
npm run dev
```
### Tests

To execute tests, run:

```sh
dotnet test
```

---

## Project Roadmap

- [X] `Implement user registration and authentication`
- [X] `Integrate external GeoCoding APIs`
- [X] `Develop solar data retrieval endpoints`

---

## Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Submit Pull Requests](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/discussions)**: Share your insights, provide feedback, or ask questions.
- **[Report Issues](https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992/issues)**: Submit bugs found or log feature requests for Solarwatch-api-csharp-tyna1992.

<details closed>
    <summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your GitHub account.
2. **Clone Locally**: Clone the forked repository to your local machine using a Git client.
   ```sh
   git clone https://github.com/CodecoolGlobal/solarwatch-api-csharp-Tyna1992
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to GitHub**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.

Once your PR is reviewed and approved, it will be merged into the main branch.

</details>

---


## Acknowledgments

- Special thanks to the contributors and maintainers of this project. Your efforts make this project possible.

[**Return**](#-quick-links)

---
