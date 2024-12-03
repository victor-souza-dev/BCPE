# BCPE API

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README.md)
[![br](https://img.shields.io/badge/lang-br-green.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-br.md)
[![es](https://img.shields.io/badge/lang-es-orange.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-es.md)
  
<br />

> FRONT-END: [https://github.com/victor-souza-dev/BCPE_Front](https://github.com/victor-souza-dev/BCPE_Front)

<br />

## 🚀 Introduction
Welcome to the BCPE API project! This is a backend application developed in C# using .NET 8.0.6. The API is designed to seamlessly interact with the BCPE front-end, allowing extraction of CSS values and transforming them into JSON. This project utilizes modern development tools and libraries to provide a robust and user-friendly interface for managing CSS configurations and file uploads.

## 🌟 Purpose of the Application
Imagine you have a set of CSS files that follow a repetitive styling model, where classes and structure are consistent but values vary. Now, imagine you need to extract specific values from these classes across multiple CSS files. This application was created precisely for this purpose: it allows you to define your model through a graphical interface and receive a zip file containing all CSS values formatted in JSON, according to the structure you specify.

> [Use Case Diagram](https://app.diagrams.net/?tags=%7B%7D&lightbox=1&highlight=0000ff&edit=_blank&layers=1&nav=1&title=use_case_diagram.drawio#Uhttps%3A%2F%2Fraw.githubusercontent.com%2Fvictor-souza-dev%2FBCPE%2Fmain%2Fdocs%2Fuse_case_diagram.drawio)

<br />

## ✨ Features
- .NET 8.0.6: Development platform for creating high-performance applications.
- Entity Framework: ORM for efficient data manipulation and object-relational mapping.
- SQLite: Lightweight and easy-to-configure database, ideal for development and testing.

## 🛠️ Getting Started
To get started with the BCPE API project, follow these steps:

1. Clone the repository:
```csharp
git clone https://github.com/victor-souza-dev/BCPE.git
cd bcpe
```

2. Configure the database:
Ensure SQLite is configured correctly. Default settings are in the appsettings.json file.

3. Run the application:
You can run the application using Visual Studio or the command line:
```csharp
dotnet run
```

By default, the application will run at http://localhost:5015.

## ⚙️ Configuration
Ensure you have the correct API base URL set in your environment variables or configuration files. You can adjust CORS settings in the Program.cs file to allow requests from the front-end development server.
Example CORS configuration in Program.cs:

```csharp
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => {
        var origins = new string[] { "http://localhost:5173", "https://localhost:5173" };
        builder.WithOrigins(origins)
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
```

## 📜 License
This project is licensed under the MIT License.

***

Feel free to explore the code, suggest improvements, and contribute to making BCPE API even better! 🎉
