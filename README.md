# VoteV2
Cette application a pour but d'aider son gestionnaire à créer des postes, des candidats et les associer à des candidatures.
# configuration
+ Comme environnement de stockage de donnée il est nécessaire d'utiliser sqlSever.
Pour faire fonctionner notre application il faut créer la base de donnée `vote` et ensuite executer le script suivant
```
USE [Vote]
GO
/****** Objet : Table [dbo].[candidature] Date du script : 3/30/2023 3:39:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[candidature] (
    [Idcandidature] INT IDENTITY (1, 1) NOT NULL,
    [Idcandidat]    INT NULL,
    [IdPoste]       INT NULL
);

CREATE TABLE [dbo].[candidat] (
    [IdCandidat]  INT          IDENTITY (1, 1) NOT NULL,
    [Nom]         VARCHAR (45) NOT NULL,
    [prenom]      VARCHAR (45) NOT NULL,
    [Description] TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCandidat] ASC)
);

CREATE TABLE [dbo].[etudiant] (
    [IdEtudiant] INT          IDENTITY (1, 1) NOT NULL,
    [Code]       VARCHAR (45) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEtudiant] ASC)
);
CREATE TABLE [dbo].[etudiant] (
    [IdEtudiant] INT          IDENTITY (1, 1) NOT NULL,
    [Code]       VARCHAR (45) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEtudiant] ASC)
);

CREATE TABLE [dbo].[poste] (
    [Idposte]     INT          IDENTITY (1, 1) NOT NULL,
    [Appelation]  VARCHAR (45) NULL,
    [Description] TEXT         NULL
);
```

+ Modifier la chaine de connexion dans `appsettings.json` en remplacant 
```
Server=<votre chaine>;Database=Vote;Trusted_Connection=True;MultipleActiveResultSets=true"
  ```
  
# Execution
A partir du repertoire principal executer le fichier `VoteV2.sln` et à partir de votre environnement exécuter juste le projet en vous assurant que les configurations
ont bien été effectuer.

# À implémenter...

Avec du temps on ajouteras à notre application 
+ un moyen de pouvoir authentifier chaque utilisateur pour garantir un accès sécurisé
+ La possibilité de définir le roles et la fonctionnalité `voter`
+ Et également ajouter une section de statistique pour connaitre le déroulement des votes en temps réels.










