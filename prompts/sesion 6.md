 
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

  //Agregar un nuevo codesnippet:

  <?xml version="1.0" encoding="utf-8"?>
  <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
      <Header>
        <Title>MediatR Query (CQRS)</Title>
        <Shortcut>mediatrquery</Shortcut>
        <Description>Genera una Query y Handler basados en CQRS usando MediatR.</Description>
        <Author>Alfredo Benaute</Author>
      </Header>
      <Snippet>
        <Declarations>
          <Literal>
            <ID>Entity</ID>
            <ToolTip>Nombre de la entidad o tipo de resultado</ToolTip>
            <Default>Product</Default>
          </Literal>
          <Literal>
            <ID>QueryName</ID>
            <ToolTip>Nombre de la Query</ToolTip>
            <Default>GetAllProductsQuery</Default>
          </Literal>
          <Literal>
            <ID>Namespace</ID>
            <ToolTip>Espacio de nombres del proyecto</ToolTip>
            <Default>MyApp.Application.Features.Products.Queries</Default>
          </Literal>
        </Declarations>

        <Code Language="csharp"><![CDATA[
  using MediatR;
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;

  namespace $Namespace$
  {
      // ✅ Query Definition
      public record $QueryName$ : IRequest<IEnumerable<$Entity$>>
      {
          // Puedes agregar filtros opcionales, por ejemplo:
          // public string? Category { get; init; }
      }

      // ✅ Handler Implementation
      public class $QueryName$Handler : IRequestHandler<$QueryName$, IEnumerable<$Entity$>>
      {
          private readonly I$Entity$Repository _repository;

          public $QueryName$Handler(I$Entity$Repository repository)
          {
              _repository = repository;
          }

          public async Task<IEnumerable<$Entity$>> Handle($QueryName$ request, CancellationToken cancellationToken)
          {
              // Lógica de negocio o acceso a datos
              var result = await _repository.GetAllAsync(cancellationToken);

              // Puedes aplicar filtros adicionales si es necesario
              return result;
          }
      }

      // ✅ Repository Interface (opcional)
      public interface I$Entity$Repository
      {
          Task<IEnumerable<$Entity$>> GetAllAsync(CancellationToken cancellationToken);
      }
  }
        ]]></Code>
      </Snippet>
    </CodeSnippet>
  </CodeSnippets>

  <!-- Snippet: Registrar en log -->
  <?xml version="1.0" encoding="utf-8"?>
  <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
      <Header>
        <Title>ILogger Extension - Log Method</Title>
        <Shortcut>logmethod</Shortcut>
        <Description>Genera un método de extensión para ILogger que registra un mensaje con nivel y EventId opcionales.</Description>
        <Author>Alfredo Benaute</Author>
      </Header>
      <Snippet>
        <Declarations>
          <Literal>
            <ID>Namespace</ID>
            <ToolTip>Namespace donde se ubicará la extensión</ToolTip>
            <Default>MyApp.Shared.Logging</Default>
          </Literal>
          <Literal>
            <ID>ClassName</ID>
            <ToolTip>Nombre de la clase estática que contendrá la extensión</ToolTip>
            <Default>LoggerExtensions</Default>
          </Literal>
          <Literal>
            <ID>MethodName</ID>
            <ToolTip>Nombre del método de extensión</ToolTip>
            <Default>LogInformationWithEvent</Default>
          </Literal>
        </Declarations>
        <Code Language="csharp"><![CDATA[
using Microsoft.Extensions.Logging;

namespace $Namespace$
{
    public static class $ClassName$
    {
        public static void $MethodName$(this ILogger logger, string message, LogLevel level = LogLevel.Information, int? eventId = null)
        {
            if (logger == null) return;

            if (eventId.HasValue)
            {
                logger.Log(level, new EventId(eventId.Value), message);
            }
            else
            {
                logger.Log(level, message);
            }
        }
    }
}
        ]]></Code>
      </Snippet>
    </CodeSnippet>
  </CodeSnippets>

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