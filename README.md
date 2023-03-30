# VoteV2

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

+Modifier la chaine de connexion dans `appsettings.json` en remplacant 
```
Server=<votre chaine>;Database=Vote;Trusted_Connection=True;MultipleActiveResultSets=true"
  ```








