info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 2.2.6-servicing-10079 initialized 'NorthwindContext' using provider 'Pomelo.EntityFrameworkCore.MySql' with options: MigrationsHistoryTable=dbo.__EFMigrationsHistory 
CREATE DATABASE IF NOT EXISTS `dbo`;
CREATE TABLE IF NOT EXISTS `dbo`.`__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE DATABASE IF NOT EXISTS `dbo`;

CREATE TABLE `dbo`.`Answer` (
    `Id` char(36) NOT NULL,
    `ParticipantId` char(36) NOT NULL,
    `SubQuestionId` char(36) NOT NULL,
    `Value` char(36) NOT NULL,
    `Text` varchar(1000) NULL,
    `SessionId` char(36) NOT NULL,
    `Date` datetime NULL,
    CONSTRAINT `PK_Answer` PRIMARY KEY (`Id`)
);

CREATE TABLE `dbo`.`Choise` (
    `Id` char(36) NOT NULL,
    `Name` varchar(1000) NULL,
    `Description` varchar(1000) NULL,
    `Status` varchar(20) NULL,
    `By` varchar(50) NULL,
    `Date` datetime NULL,
    CONSTRAINT `PK_Choise` PRIMARY KEY (`Id`)
);

CREATE TABLE `dbo`.`Participant` (
    `Id` char(36) NOT NULL,
    `SessionId` char(36) NOT NULL,
    `Name` varchar(500) NULL,
    `Email` varchar(500) NULL,
    `Status` varchar(20) NULL,
    `By` varchar(50) NULL,
    `Date` datetime NULL,
    CONSTRAINT `PK_Participant` PRIMARY KEY (`Id`)
);

CREATE TABLE `dbo`.`Question` (
    `Id` char(36) NOT NULL,
    `Title` varchar(500) NULL,
    `Description` varchar(1000) NULL,
    `Status` varchar(20) NULL,
    `Order` int NOT NULL,
    `By` varchar(50) NULL,
    `Date` datetime NULL,
    CONSTRAINT `PK_Question` PRIMARY KEY (`Id`)
);

CREATE TABLE `dbo`.`SubChoise` (
    `Id` char(36) NOT NULL,
    `ChoiseId` char(36) NOT NULL,
    `Title` varchar(500) NULL,
    `Description` varchar(1000) NULL,
    `Order` int NOT NULL,
    `AllowSelect` bit NOT NULL,
    CONSTRAINT `PK_SubChoise` PRIMARY KEY (`Id`)
);

CREATE TABLE `dbo`.`SubQuestion` (
    `Id` char(36) NOT NULL,
    `QuestionId` char(36) NOT NULL,
    `ChoiseId` char(36) NOT NULL,
    `Value` varchar(500) NULL,
    `Description` varchar(1000) NULL,
    `Status` varchar(20) NULL,
    `Order` int NOT NULL,
    `Type` varchar(10) NULL,
    `By` varchar(50) NULL,
    `Date` datetime NULL,
    CONSTRAINT `PK_SubQuestion` PRIMARY KEY (`Id`)
);

INSERT INTO `dbo`.`__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831194358_''initailize@01092019''', '2.2.6-servicing-10079');

ALTER TABLE `dbo`.`SubQuestion` MODIFY COLUMN `ChoiseId` char(36) NULL;

INSERT INTO `dbo`.`__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831203901_''initailize2@01092019''', '2.2.6-servicing-10079');

ALTER TABLE `dbo`.`Answer` DROP COLUMN `SessionId`;

INSERT INTO `dbo`.`__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831204836_''initailize3@01092019''', '2.2.6-servicing-10079');


