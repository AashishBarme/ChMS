CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE IF NOT EXISTS `members` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `FirstName` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastName` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Email` varchar CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` varchar CHARACTER SET utf8mb4 NOT NULL,
    `SecondaryPhoneNumber` varchar CHARACTER SET utf8mb4 NULL,
    `BirthDate` varchar CHARACTER SET utf8mb4 NOT NULL,
    `Sex` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `Occupation` varchar CHARACTER SET utf8mb4 NULL,
    `Photo` varchar CHARACTER SET utf8mb4 NULL,
    `PermanentAddress` varchar CHARACTER SET utf8mb4 NULL,
    `TemporaryAddress` varchar CHARACTER SET utf8mb4 NULL,
    `GroupId` int NOT NULL,
    `ChurchRole` int NOT NULL,
    `CreatedDate` datetime NOT NULL,
    `UpdateDate` datetime NULL,
    `CreatedBy` bigint NOT NULL,
    `UpdateBy` bigint NOT NULL,
    CONSTRAINT `PK_members` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `roles` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_roles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `users` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(50) CHARACTER SET utf8mb4 NULL,
    `MiddleName` varchar(50) CHARACTER SET utf8mb4 NULL,
    `LastName` varchar(50) CHARACTER SET utf8mb4 NULL,
    `UserGroup` int NOT NULL,
    `IsActive` int NOT NULL,
    `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
    `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `role_claims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` bigint NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_role_claims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_role_claims_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `user_claims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` bigint NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_user_claims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_user_claims_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `user_logins` (
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_user_logins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_user_logins_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `user_roles` (
    `UserId` bigint NOT NULL,
    `RoleId` bigint NOT NULL,
    CONSTRAINT `PK_user_roles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_user_roles_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_user_roles_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE  IF NOT EXISTS `user_tokens` (
    `UserId` bigint NOT NULL,
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_user_tokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_user_tokens_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX IF NOT EXISTS `IX_role_claims_RoleId` ON `role_claims` (`RoleId`);

CREATE UNIQUE INDEX IF NOT EXISTS `RoleNameIndex` ON `roles` (`NormalizedName`);

CREATE INDEX IF NOT EXISTS `IX_user_claims_UserId` ON `user_claims` (`UserId`);

CREATE INDEX IF NOT EXISTS `IX_user_logins_UserId` ON `user_logins` (`UserId`);

CREATE INDEX IF NOT EXISTS `IX_user_roles_RoleId` ON `user_roles` (`RoleId`);

CREATE INDEX IF NOT EXISTS `EmailIndex` ON `users` (`NormalizedEmail`);

CREATE UNIQUE INDEX IF NOT EXISTS `UserNameIndex` ON `users` (`NormalizedUserName`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221221171908_InitialMemberCreate', '6.0.7');


CREATE TABLE IF NOT EXISTS `families` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Surname` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MemberHead`  char(36) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PermanentAddress` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TemporaryAddress` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `groups`(
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) NOT NULL,
    `Description` text NOT NULL,
    `FellowshipRoutine` varchar(255) NOT NULL,
    PRIMARY KEY(`Id`)
)ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `inventory`(
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) NOT NULL,
    `Code` varchar(50) NOT NULL,
    `Quantity` int(4) NOT NULL,
    PRIMARY KEY(`Id`)
)ENGINE=InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


COMMIT;