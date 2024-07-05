# BCPE API

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README.md)
[![br](https://img.shields.io/badge/lang-br-green.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-br.md)
[![es](https://img.shields.io/badge/lang-es-orange.svg)](https://github.com/victor-souza-dev/BCPE/blob/main/README-es.md)
  
<br />

> FRONT-END: https://github.com/victor-souza-dev/BCPE_Front

<br />

## 🚀 Introducción
¡Bienvenido al proyecto BCPE API! Esta es una aplicación backend desarrollada en C# utilizando .NET 8.0.6. La API está diseñada para interactuar perfectamente con el frontend de BCPE, permitiendo la extracción de valores CSS y su transformación a JSON. Este proyecto utiliza herramientas y bibliotecas modernas de desarrollo para proporcionar una interfaz robusta y fácil de usar para la gestión de configuraciones de CSS y la carga de archivos.

## 🌟 Propósito de la Aplicación
Imagina que tienes un conjunto de archivos CSS que siguen un modelo de estilización repetitivo, donde las clases y la estructura son consistentes, pero los valores varían. Ahora, imagina que necesitas extraer valores específicos de estas clases en varios archivos CSS. Esta aplicación fue creada precisamente para eso: te permite definir tu modelo a través de una interfaz gráfica y recibir un archivo zip con todos los valores CSS formateados en JSON, según la estructura que especifiques.

## ✨ Funcionalidades
- 🖥️ .NET 8.0.6: Plataforma de desarrollo para crear aplicaciones de alto rendimiento.
- 🛠️ Entity Framework: ORM para la manipulación eficiente de datos y el mapeo objeto-relacional.
- 📦 SQLite: Base de datos ligera y de fácil configuración, ideal para desarrollo y pruebas.

## 🛠️ Empezando
Para comenzar con el proyecto BCPE API, sigue los siguientes pasos:

1. Clona el repositorio:
```csharp
git clone https://github.com/victor-souza-dev/BCPE.git
cd bcpe
```

2. Configura la base de datos:
Asegúrate de que SQLite esté configurado correctamente. Las configuraciones por defecto están en el archivo appsettings.json.

3. Ejecuta la aplicación:
Puedes ejecutar la aplicación usando Visual Studio o desde la línea de comandos:
```csharp
dotnet run
```

Por defecto, la aplicación se ejecutará en http://localhost:5015.

## ⚙️ Configuración
Asegúrate de tener la URL base correcta de la API configurada en tus variables de entorno o archivos de configuración. Puedes ajustar las configuraciones de CORS en el archivo Program.cs para permitir peticiones desde el servidor de desarrollo del frontend.
Ejemplo de configuración de CORS en Program.cs:
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

## 📜 Licencia
Este proyecto está bajo la Licencia MIT.

***

¡Siéntete libre de explorar el código, sugerir mejoras y contribuir para hacer que BCPE API sea aún mejor! 🎉
