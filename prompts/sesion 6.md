 
# TESTS

## Modificar BookService
 //agrega una validacion para verificar si el libro ya existe
 //agrega una validación para verificar si el precio es negativo
 //agrega una validación para verificar si el título está vacío
 //agrega una validación para verificar si la descripción está vacía
 //agrega una validación para verificar que el titulo solo permita letras, numero y espacios

 ## Generar tests para BookService
 // Copilot, genera pruebas unitarias para la clase BookService
// Usa Moq para las dependencias y asegúrate de probar métodos como GetByIdAsync y AddAsync

// Copilot, agrega una prueba negativa donde AddAsync lance excepción si el título está vacío

// Copilot, agrega un test parametrizado con [Theory] para validar precios de libros


# SONARCLOUD

1- Crear cuenta en SonarCloud
2- Vincular proyecto a Sonarcloud
3- Configurar entorno local con sonarcloud

https://sonarcloud.io/projects

https://marketplace.visualstudio.com/items?itemName=SonarSource.SonarLintforVisualStudio2022

dotnet tool install --global dotnet-sonarscanner

dotnet sonarscanner begin `
  /key:"alfredodasser_base-clean-architecture-net8" `
  /organization:"alfredodeveloper" `
  /d:sonar.token="44f4c0621a61ef58a8fba11a7e1ae2046171e1b9" `
  /d:sonar.host.url="https://sonarcloud.io"

dotnet build

dotnet sonarscanner end /d:sonar.token="44f4c0621a61ef58a8fba11a7e1ae2046171e1b9"


# DOCUMENTAR CODIGO

/// Copilot, documenta todos los métodos de esta clase usando comentarios XML


# VINCULAR GITHUB

En GitHub → pestaña Projects o Issues, crear una tarea:
“Aumentar cobertura de pruebas de BookService al 90%”

Vincular el commit generado desde Visual Studio:

git commit -m "Add unit tests for BookService to improve coverage #1"


# SNIPPETS


# APROVECHAR CONTEXTO

Activar el modo de contexto
    Abre varios archivos relacionados:
        BookService.cs
        IBookRepository.cs
        Book.cs

Esto permite que Copilot use tu propio código como contexto.

PROMPT:

// Copilot, genera una nueva función en BookService que devuelva los libros publicados en los últimos N días
// Usa la estructura y patrones ya existentes en esta clase