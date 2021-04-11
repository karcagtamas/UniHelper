START TRANSACTION;

ALTER TABLE `Periods` ADD `UserId` int NOT NULL DEFAULT 0;

ALTER TABLE `GlobalTasks` ADD `UserId` int NOT NULL DEFAULT 0;

ALTER TABLE `GlobalNotes` ADD `UserId` int NOT NULL DEFAULT 0;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FullName` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    `UserName` varchar(80) CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Registration` datetime(6) NOT NULL,
    `LastLogin` datetime(6) NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
);

CREATE INDEX `IX_Periods_UserId` ON `Periods` (`UserId`);

CREATE INDEX `IX_GlobalTasks_UserId` ON `GlobalTasks` (`UserId`);

CREATE INDEX `IX_GlobalNotes_UserId` ON `GlobalNotes` (`UserId`);

ALTER TABLE `GlobalNotes` ADD CONSTRAINT `FK_GlobalNotes_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `GlobalTasks` ADD CONSTRAINT `FK_GlobalTasks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Periods` ADD CONSTRAINT `FK_Periods_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210316210350_UserUpdate', '5.0.4');

COMMIT;

INSERT INTO UniHelper.Users (Id, FullName, UserName, Password, Email, Registration, LastLogin) VALUES (1, 'Karcag Tamas', 'karcagtamas', '1000:tSPRY0o9d8UyVEGH6Wctw42c+nNRCc1N:2buv3hlszeUnYlcve33cVSEPfPvHJLzE', 'karcagtamas@outlook.com', '2021-03-16 22:08:30.000000', '2021-04-11 20:03:47.508005');
INSERT INTO UniHelper.Users (Id, FullName, UserName, Password, Email, Registration, LastLogin) VALUES (2, 'Test User', 'testuser', '1000:tSPRY0o9d8UyVEGH6Wctw42c+nNRCc1N:2buv3hlszeUnYlcve33cVSEPfPvHJLzE', 'karcagtamas@gmail.com', '2021-03-17 17:00:46.521764', '2021-03-17 17:00:46.521675');
