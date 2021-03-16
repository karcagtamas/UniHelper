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
