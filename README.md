# OracleDB_Project
 NBA team and player management application

This is an application for managing NBA teams and players. 
It is made in VisualStudio2022. 
A local Oracle database is used as data storage space. 

The application is composed of 2 parts: 
	1 Simple user who can only see data from the tables. 
	2 User with admin rights who can make various changes in the tables, such as inserting data, deleting and updating, to have admin rights it is necessary to enter the password and user "admin" .



SCRIPTS FOR CREATE TABLES:
*for the application to run, you need to have the scripts implimented

CREATE Table Jucatori(
    IdJucator NUMBER PRIMARY KEY,
    Nume VARCHAR2(100) NOT NULL,
    Prenume VARCHAR2(100) NOT NULL,
    DataNasterii DATE NOT NULL,
    TaraNatala VARCHAR2(50) NOT NULL,
    DraftPick NUMBER NOT NULL,
    Pozitie VARCHAR2(10) NOT NULL
);

CREATE TABLE Echipe(
    IdEchipa NUMBER PRIMARY KEY,
    Nume VARCHAR2(100) NOT NULL,
    Oras VARCHAR2(100) NOT NULL,
    Conferenta VARCHAR2(10) NOT NULL,
    AnulInfiintarii DATE NOT NULL
);

CREATE TABLE Meciuri(
    IdMeci NUMBER PRIMARY KEY,
    Data DATE NOT NULL,
    Locatie VARCHAR2(100) NOT NULL,
    ScorGazda NUMBER NOT NULL,
    ScorOaspeti NUMBER NOT NULL,
    IdEchipaGazda NUMBER NOT NULL,
    IdEchipaOaspeti NUMBER NOT NULL,
    CONSTRAINT FK_EchipaGazda FOREIGN KEY (IdEchipaGazda) REFERENCES Echipe(IdEchipa),
    CONSTRAINT FK_EchipaOaspeti FOREIGN KEY (IdEchipaOaspeti) REFERENCES Echipe(IdEchipa)
);

CREATE TABLE Contracte(
    IdContract NUMBER PRIMARY KEY,
    IdJucator NUMBER NOT NULL,
    IdEchipa NUMBER NOT NULL,
    DataInceput DATE NOT NULL,
    DataSfarsit DATE NOT NULL,
    SalariuAnual NUMBER NOT NULL,
    CONSTRAINT FK_Jucator FOREIGN KEY (IdJucator) REFERENCES Jucatori(IdJucator),
    CONSTRAINT FK_Echipa FOREIGN KEY (IdEchipa) REFERENCES Echipe(IdEchipa)
);


CREATE SEQUENCE seq_Jucatori;

CREATE SEQUENCE seq_Echipe;

CREATE SEQUENCE seq_Meciuri;

CREATE SEQUENCE seq_Contracte;





author: Tatarciuc Victor                 SUCEAVA2023