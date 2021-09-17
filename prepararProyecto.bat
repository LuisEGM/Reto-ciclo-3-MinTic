@echo off
echo #################################
echo ### Soccer Tournament Manager ###
echo #################################
echo #.
echo #.
echo #.
echo °°°°°°°°°°°°°°°°  Estamos preparando el proyecto para usted °°°°°°°°°°°°°°°°

cd .\SoccerTournametManager.App.Consola\
dotnet restore
dotnet build
cd ..

echo #.
echo #.
echo °°°°°°°°°°°°°°°° Proceso terminado °°°°°°°°°°°°°°°°
echo #.
echo °°°°°°°°°°°°°°°°  Feliz codeo :)   °°°°°°°°°°°°°°°°
echo #.
echo #.
pause
exit