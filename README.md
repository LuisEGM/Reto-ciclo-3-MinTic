# Soccer tournament manager
En este repositorio se almacenara el código y las tareas realizadas en el reto del ciclo # 3 de MinTic 2021

## Recomendación
Seria ideal que una vez clonado el repositorio, ejecute el archivo prepararProyecto.bat, este se encargara de ejecutar una seria de comandos para cargar correctamente
el proyecto y generar las carpetas /obj y /bin dentro de cada paquete al ejecutar los comandos:
> dotnet restore and dotnet build

## Para hacer la migración y posterior creación de la DB tener en cuenta:
Debe estar ubicado en el directorio correspondiente a persistencia. Abra una consola en esa ubicación y escriba los siguientes comandos:

### Para generar la migración ejecute:
> dotnet ef migrations add Inicial --startup-project ..\SoccerTournametManager.App.Consola

### Para ejecutar la migración y crear la DB ejecute:
> dotnet ef database update --startup-project ..\SoccerTournametManager.App.Consola

## Diagrama de clases
![diagrama](https://firebasestorage.googleapis.com/v0/b/warehouse-ee161.appspot.com/o/UML_SoccerTournamentManager.jpg?alt=media&token=57309eeb-5d5a-4b30-9e0e-01679c435e85)
