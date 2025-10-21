

# CONFIGURACIONES PARA COMMITS:

1- Desde Visual studio

## Prompt para generar mensajes de commit
El mensaje de commit no debe ser mayor a 200 caracteres.

## Prompt para generar mensajes de commit
Crea un mensaje de commit siguiendo la convención Conventional Commits.
El mensaje no debe ser mayor a 200 caracteres.

2- Desde .copilot.json

Agregar archivo .copilot.json y añadir
{
  "commitMessage": {
    "language": "en",
    "instructions": "Usa mensajes de commit con formato Conventional Commits. Menciona el módulo afectado. Ejemplo: fix(core): corrige error de autenticación."
  }
}


# GITHUB CLI:

Instalar:

winget install GitHub.cli

gh auth login

gh extension install github/gh-copilot

gh copilot --help

gh copilot suggest "listar los 5 archivos más grandes en el directorio actual"

gh copilot suggest "crear una carpeta llamada logs y mover todos los archivos .txt a esa carpeta"

gh copilot explain "tar -czvf backup.tar.gz /var/www"

gh copilot generate "un script bash que haga ping a google cada 10 segundos y guarde el resultado en un archivo log"

gh copilot suggest "mostrar los últimos 5 commits con el mensaje en una sola línea"

gh copilot suggest "crear nueva rama feature/login, añadir todos los cambios y hacer commit con mensaje 'add login module'"

gh copilot suggest "Mostrar los procesos que usan más memoria"	

"Eliminar todos los archivos temporales del directorio actual"	

"Contar cuántas líneas tiene un archivo llamado data.txt"	

"Ver las IPs activas en la red local"	

"Empaquetar todos los archivos .log en un zip llamado logs.zip"	


