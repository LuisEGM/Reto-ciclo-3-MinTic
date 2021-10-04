USE SoccerTournamentManager;

-- Insertando minicipios
-- SELECT * FROM Municipios
INSERT INTO Municipios (Nombre) VALUES ('Fundacion')
INSERT INTO Municipios (Nombre) VALUES ('Reten')

-- Insertando estadios
-- SELECT * FROM Estadios
INSERT INTO Estadios (Nombre, Direccion, MunicipioId) VALUES ('Estadio_1','Direccion_1',1)
INSERT INTO Estadios (Nombre, Direccion, MunicipioId) VALUES ('Estadio_2','Direccion_2',2)
INSERT INTO Estadios (Nombre, Direccion, MunicipioId) VALUES ('Estadio_3','Direccion_3',2)

-- Insertando DTs
-- SELECT * FROM Personas
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono) VALUES ('Zidane','756435454', 'DirectorTecnico','300213334')
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono) VALUES ('Pekerman','74324423', 'DirectorTecnico','3023458793')

-- Insertando desempeño de equipos
-- SELECT * FROM DesempeñosDeEquipos
INSERT INTO DesempeñosDeEquipos (PartidosJugados, PartidosGanados, PartidosEmpatados, GolesAFavor, GolesEnContra, Puntos) VALUES (10, 6, 3, 12, 4, 28)
INSERT INTO DesempeñosDeEquipos (PartidosJugados, PartidosGanados, PartidosEmpatados, GolesAFavor, GolesEnContra, Puntos) VALUES (11, 5, 3, 8, 5, 20)

--Insertando Equipos
-- SELECT * FROM Equipos
INSERT INTO Equipos (Nombre, MunicipioId, DirectorTecnicoId, DesempeñoEquipoId) VALUES ('Example F.C', 1, 1, 1)
INSERT INTO Equipos (Nombre, MunicipioId, DirectorTecnicoId, DesempeñoEquipoId) VALUES ('Indendiente Test', 2, 2, 2)

-- Insertando Jugadores
-- SELECT * FROM Personas
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Cuadrado','234234545', 'Jugador','300213334', 10, 'delantero', 1)
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Mejia','65743554', 'Jugador','3005467643', 6, 'Medio centro', 1)
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Sanchez','347668768', 'Jugador','3002341678', 3, 'Defensa', 1)
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Barrera','73472938', 'Jugador','3003678394', 11, 'delantero', 2)
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Viera','26312835', 'Jugador','3903435657', 6, 'Medio centro', 2)
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Numero, Posicion, EquipoId) VALUES ('Barrios','47293843', 'Jugador','321564564', 2, 'Defensa', 2)

-- Insertando Arbitros
-- SELECT * FROM Personas
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Colegio) VALUES ('Pitana','234234545', 'Arbitro','300213334', 'Fifa sed_1')
INSERT INTO Personas (Nombre, Documento, Discriminator, Telefono, Colegio) VALUES ('Betancout','65743554', 'Arbitro','3005467643', 'Fifa sed_2')

-- Insertando Partidos
-- SELECT * FROM Partidos
INSERT INTO Partidos(EquipoLocalId,EquipoVisitanteId,EstadioId,FechaHora,ArbitroId) VALUES (1,2,2,'04-10-2021 16:30:15',10)

-- Insertando Novedad
-- SELECT * FROM NovedadesDePartidos
INSERT INTO NovedadesDePartidos (Novedad, Minuto, JugadorInvolucradoId, PartidoId) VALUES (0, 85, 3, 1)