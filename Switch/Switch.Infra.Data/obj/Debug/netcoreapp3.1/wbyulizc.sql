CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Usuarios` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NULL,
    `Sobrenome` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `Senha` longtext CHARACTER SET utf8mb4 NULL,
    `DataNascimento` datetime(6) NOT NULL,
    `Sexo` int NOT NULL,
    `UrlFoto` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Usuarios` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831004158_Inicial', '3.1.7');

ALTER TABLE `Usuarios` MODIFY COLUMN `UrlFoto` varchar(400) CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Sobrenome` varchar(400) CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Senha` varchar(400) CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Nome` varchar(400) CHARACTER SET utf8mb4 NOT NULL;

ALTER TABLE `Usuarios` MODIFY COLUMN `Email` varchar(400) CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831104009_AdicionandoUsuarioConfiguration', '3.1.7');

CREATE TABLE `Postagems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataPublicacao` datetime(6) NOT NULL,
    `Texto` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Postagems` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831120934_AdicionadoPostagem', '3.1.7');

CREATE TABLE `StatusRelacionamento` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_StatusRelacionamento` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831122007_AdicionadoStatusRelacionamento', '3.1.7');

CREATE TABLE `Identificacao` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TipoDocumento` int NOT NULL,
    `Numero` longtext CHARACTER SET utf8mb4 NULL,
    `UsuarioId` int NOT NULL,
    CONSTRAINT `PK_Identificacao` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Identificacao_Usuarios_UsuarioId` FOREIGN KEY (`UsuarioId`) REFERENCES `Usuarios` (`Id`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `IX_Identificacao_UsuarioId` ON `Identificacao` (`UsuarioId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831135356_AddIntentificacao', '3.1.7');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200831140021_AddIntentificacao2', '3.1.7');

