CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `GlobalNotes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Text` varchar(240) CHARACTER SET utf8mb4 NOT NULL,
    `Created` datetime(6) NOT NULL,
    `LastUpdated` datetime(6) NOT NULL,
    `IsClosed` tinyint(1) NOT NULL,
    CONSTRAINT `PK_GlobalNotes` PRIMARY KEY (`Id`)
);

CREATE TABLE `GlobalTasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    `DueDate` datetime(6) NOT NULL,
    `Priority` int NOT NULL,
    `IsSolved` tinyint(1) NOT NULL,
    CONSTRAINT `PK_GlobalTasks` PRIMARY KEY (`Id`)
);

CREATE TABLE `Periods` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Periods` PRIMARY KEY (`Id`)
);

CREATE TABLE `PeriodNotes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PeriodId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PeriodId1` int NOT NULL,
    `Text` varchar(240) CHARACTER SET utf8mb4 NOT NULL,
    `Created` datetime(6) NOT NULL,
    `LastUpdated` datetime(6) NOT NULL,
    `IsClosed` tinyint(1) NOT NULL,
    CONSTRAINT `PK_PeriodNotes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PeriodNotes_Periods_PeriodId1` FOREIGN KEY (`PeriodId1`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PeriodTasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PeriodId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PeriodId1` int NOT NULL,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    `DueDate` datetime(6) NOT NULL,
    `Priority` int NOT NULL,
    `IsSolved` tinyint(1) NOT NULL,
    CONSTRAINT `PK_PeriodTasks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PeriodTasks_Periods_PeriodId1` FOREIGN KEY (`PeriodId1`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Subjects` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `LongName` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `ShortName` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `Code` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Credit` int NOT NULL,
    `FolderName` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `PeriodId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Result` int NULL,
    `IsActive` tinyint(1) NOT NULL,
    `PeriodId1` int NOT NULL,
    CONSTRAINT `PK_Subjects` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Subjects_Periods_PeriodId1` FOREIGN KEY (`PeriodId1`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Courses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Place` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `Start` datetime(6) NOT NULL,
    `End` datetime(6) NOT NULL,
    `Day` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `Teachers` longtext CHARACTER SET utf8mb4 NULL,
    `IsSelected` tinyint(1) NOT NULL,
    `SubjectId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SubjectId1` int NOT NULL,
    CONSTRAINT `PK_Courses` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Courses_Subjects_SubjectId1` FOREIGN KEY (`SubjectId1`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SubjectNotes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SubjectId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SubjectId1` int NOT NULL,
    `Text` varchar(240) CHARACTER SET utf8mb4 NOT NULL,
    `Created` datetime(6) NOT NULL,
    `LastUpdated` datetime(6) NOT NULL,
    `IsClosed` tinyint(1) NOT NULL,
    CONSTRAINT `PK_SubjectNotes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SubjectNotes_Subjects_SubjectId1` FOREIGN KEY (`SubjectId1`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SubjectTasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SubjectId` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SubjectId1` int NOT NULL,
    `Text` longtext CHARACTER SET utf8mb4 NULL,
    `DueDate` datetime(6) NOT NULL,
    `Priority` int NOT NULL,
    `IsSolved` tinyint(1) NOT NULL,
    CONSTRAINT `PK_SubjectTasks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SubjectTasks_Subjects_SubjectId1` FOREIGN KEY (`SubjectId1`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_Courses_SubjectId1` ON `Courses` (`SubjectId1`);

CREATE INDEX `IX_PeriodNotes_PeriodId1` ON `PeriodNotes` (`PeriodId1`);

CREATE INDEX `IX_PeriodTasks_PeriodId1` ON `PeriodTasks` (`PeriodId1`);

CREATE INDEX `IX_SubjectNotes_SubjectId1` ON `SubjectNotes` (`SubjectId1`);

CREATE INDEX `IX_Subjects_PeriodId1` ON `Subjects` (`PeriodId1`);

CREATE INDEX `IX_SubjectTasks_SubjectId1` ON `SubjectTasks` (`SubjectId1`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210120140131_Init', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `Subjects` DROP COLUMN `FolderName`;

ALTER TABLE `Periods` ADD `End` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE `Periods` ADD `IsCurrent` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Periods` ADD `Start` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210120171201_UpdateEntities', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `SubjectTasks` MODIFY COLUMN `Text` varchar(200) CHARACTER SET utf8mb4 NOT NULL DEFAULT '';

ALTER TABLE `Subjects` ADD `Type` int NOT NULL DEFAULT 0;

ALTER TABLE `PeriodTasks` MODIFY COLUMN `Text` varchar(200) CHARACTER SET utf8mb4 NOT NULL DEFAULT '';

ALTER TABLE `Periods` MODIFY COLUMN `Name` varchar(20) CHARACTER SET utf8mb4 NOT NULL DEFAULT '';

ALTER TABLE `GlobalTasks` MODIFY COLUMN `Text` varchar(200) CHARACTER SET utf8mb4 NOT NULL DEFAULT '';

ALTER TABLE `Courses` MODIFY COLUMN `Start` time(6) NOT NULL;

ALTER TABLE `Courses` MODIFY COLUMN `End` time(6) NOT NULL;

ALTER TABLE `Courses` MODIFY COLUMN `Day` int NOT NULL;

ALTER TABLE `Courses` ADD `Type` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210120211049_UpgradeEntities', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `Courses` DROP FOREIGN KEY `FK_Courses_Subjects_SubjectId1`;

ALTER TABLE `PeriodNotes` DROP FOREIGN KEY `FK_PeriodNotes_Periods_PeriodId1`;

ALTER TABLE `PeriodTasks` DROP FOREIGN KEY `FK_PeriodTasks_Periods_PeriodId1`;

ALTER TABLE `SubjectNotes` DROP FOREIGN KEY `FK_SubjectNotes_Subjects_SubjectId1`;

ALTER TABLE `Subjects` DROP FOREIGN KEY `FK_Subjects_Periods_PeriodId1`;

ALTER TABLE `SubjectTasks` DROP FOREIGN KEY `FK_SubjectTasks_Subjects_SubjectId1`;

ALTER TABLE `SubjectTasks` DROP INDEX `IX_SubjectTasks_SubjectId1`;

ALTER TABLE `Subjects` DROP INDEX `IX_Subjects_PeriodId1`;

ALTER TABLE `SubjectNotes` DROP INDEX `IX_SubjectNotes_SubjectId1`;

ALTER TABLE `PeriodTasks` DROP INDEX `IX_PeriodTasks_PeriodId1`;

ALTER TABLE `PeriodNotes` DROP INDEX `IX_PeriodNotes_PeriodId1`;

ALTER TABLE `Courses` DROP INDEX `IX_Courses_SubjectId1`;

ALTER TABLE `SubjectTasks` DROP COLUMN `SubjectId1`;

ALTER TABLE `Subjects` DROP COLUMN `PeriodId1`;

ALTER TABLE `SubjectNotes` DROP COLUMN `SubjectId1`;

ALTER TABLE `PeriodTasks` DROP COLUMN `PeriodId1`;

ALTER TABLE `PeriodNotes` DROP COLUMN `PeriodId1`;

ALTER TABLE `Courses` DROP COLUMN `SubjectId1`;

ALTER TABLE `SubjectTasks` MODIFY COLUMN `SubjectId` int NOT NULL;

ALTER TABLE `Subjects` MODIFY COLUMN `PeriodId` int NOT NULL;

ALTER TABLE `SubjectNotes` MODIFY COLUMN `SubjectId` int NOT NULL;

ALTER TABLE `PeriodTasks` MODIFY COLUMN `PeriodId` int NOT NULL;

ALTER TABLE `PeriodNotes` MODIFY COLUMN `PeriodId` int NOT NULL;

ALTER TABLE `Courses` MODIFY COLUMN `SubjectId` int NOT NULL;

CREATE INDEX `IX_SubjectTasks_SubjectId` ON `SubjectTasks` (`SubjectId`);

CREATE INDEX `IX_Subjects_PeriodId` ON `Subjects` (`PeriodId`);

CREATE INDEX `IX_SubjectNotes_SubjectId` ON `SubjectNotes` (`SubjectId`);

CREATE INDEX `IX_PeriodTasks_PeriodId` ON `PeriodTasks` (`PeriodId`);

CREATE INDEX `IX_PeriodNotes_PeriodId` ON `PeriodNotes` (`PeriodId`);

CREATE INDEX `IX_Courses_SubjectId` ON `Courses` (`SubjectId`);

ALTER TABLE `Courses` ADD CONSTRAINT `FK_Courses_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `PeriodNotes` ADD CONSTRAINT `FK_PeriodNotes_Periods_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `PeriodTasks` ADD CONSTRAINT `FK_PeriodTasks_Periods_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `SubjectNotes` ADD CONSTRAINT `FK_SubjectNotes_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Subjects` ADD CONSTRAINT `FK_Subjects_Periods_PeriodId` FOREIGN KEY (`PeriodId`) REFERENCES `Periods` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `SubjectTasks` ADD CONSTRAINT `FK_SubjectTasks_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210125170050_FixId', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `Courses` DROP COLUMN `End`;

ALTER TABLE `Courses` DROP COLUMN `Start`;

ALTER TABLE `Courses` ADD `Length` int NOT NULL DEFAULT 0;

ALTER TABLE `Courses` ADD `Number` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210130140835_CourseLengthUpdate', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `Subjects` MODIFY COLUMN `Code` varchar(16) CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210131123936_CodeLengthUpdate', '5.0.4');

COMMIT;

START TRANSACTION;

CREATE TABLE `LessonHours` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Number` int NOT NULL,
    `IsStart` tinyint(1) NOT NULL,
    `Start` time(6) NOT NULL,
    `End` time(6) NOT NULL,
    CONSTRAINT `PK_LessonHours` PRIMARY KEY (`Id`)
);

INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (1, '08:25:00', TRUE, 0, '07:40:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (2, '09:15:00', TRUE, 1, '08:30:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (3, '10:10:00', TRUE, 2, '09:25:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (4, '11:05:00', TRUE, 3, '10:20:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (5, '12:00:00', TRUE, 4, '11:15:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (6, '12:55:00', TRUE, 5, '12:10:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (7, '13:50:00', TRUE, 6, '13:05:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (8, '14:45:00', TRUE, 7, '14:00:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (9, '15:35:00', TRUE, 8, '14:50:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (10, '16:25:00', TRUE, 9, '15:40:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (11, '17:15:00', TRUE, 10, '16:30:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (12, '18:05:00', TRUE, 11, '17:20:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (13, '18:55:00', TRUE, 12, '18:10:00');
INSERT INTO `LessonHours` (`Id`, `End`, `IsStart`, `Number`, `Start`)
VALUES (14, '19:45:00', TRUE, 13, '19:00:00');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210201083734_LessonHourUpdate', '5.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE `LessonHours` DROP COLUMN `IsStart`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210201085328_LessonHourFix', '5.0.4');

COMMIT;

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
