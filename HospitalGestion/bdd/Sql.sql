CREATE TABLE rdv(
	id INT PRIMARY KEY IDENTITY(1,1),
	code INT NOT NULL,
	idMedecin INT NOT NULL,
	date DATETIME,
	idService INT,
	idPatient INT NULL,
	annule INT NULL DEFAULT 1, 
);

CREATE TABLE patient(
	id INT PRIMARY KEY IDENTITY(1,1),
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	dateNaissance DATETIME,
	sexe INT,
	adresse VARCHAR(MAX),
	situationFamilliale INT,
	assuranceMedical VARCHAR(50),
	codeAssurance VARCHAR(max),
	tel VARCHAR(15),
	nomPere VARCHAR(50),
	nomMere VARCHAR(50),
	nomPersonnePrevenir VARCHAR(50),
	telPersonnePrevenir VARCHAR(15)
);

CREATE TABLE traitement(
	id INT PRIMARY KEY IDENTITY(1,1),
	date DATETIME,
	prix DECIMAL,
	idPatient INT NULL, 
);

CREATE TABLE examenBiologique(
	id INT PRIMARY KEY IDENTITY(1,1),
	designation VARCHAR(100),
	resultat VARCHAR(max)
);

CREATE TABLE examenRadiologique(
	id INT PRIMARY KEY IDENTITY(1,1),
	designation VARCHAR(100),
	resultat VARCHAR(max),
);

CREATE TABLE chirurgie(
	id INT PRIMARY KEY IDENTITY(1,1),
	idChirurgien INT,
	idAnesthesiste INT
);

CREATE TABLE prescription(
	id INT PRIMARY KEY IDENTITY(1,1),
	date DATETIME,
	idPatient INT,
	note VARCHAR(max)
);

CREATE TABLE consultation(
	id INT PRIMARY KEY IDENTITY(1,1),
	date DATETIME,
	synthese VARCHAR(max),
	typeConsultation VARCHAR(max),
	prix DECIMAL,
	idPatient INT NOT NULL,
);

CREATE TABLE medecin(
	id INT PRIMARY KEY IDENTITY(1,1),
	nom VARCHAR(50),
	prenom VARCHAR(50),
	tel VARCHAR(15),
	specialite INT,
	serviceNom INT
);

CREATE TABLE chambre(
	id INT PRIMARY KEY IDENTITY(1,1),
	etage INT,
	capacite INT,
	prix DECIMAL,
	occupe INT
);

CREATE TABLE facture(
	id INT PRIMARY KEY IDENTITY(1,1),
	date DATETIME,
	prix DECIMAL,
	idPatient INT,
	payee INT NULL, 
);

CREATE TABLE hospitalisation(
	id INT PRIMARY KEY IDENTITY(1,1),
	dateAdmission DATETIME,
	typeAdmission VARCHAR(max),
	motifAdmission VARCHAR(max),
	idMedecin INT,
	nomAccompagnant VARCHAR(50),
	prenomAccompagnant VARCHAR(50),
	lientParente INT,
	dateEntreeAcc DATETIME,
	dateSortieAcc DATETIME,
	motifSortie VARCHAR(max),
	resultatSortie VARCHAR(max),
	dateDeces DATETIME,
	motifDeces VARCHAR(max),
	idPatient INT NOT NULL,
	dateSortie DATETIME NULL, 
	
);

CREATE TABLE hopital(
	id INT PRIMARY KEY IDENTITY(1,1),
	nom VARCHAR(100),
);