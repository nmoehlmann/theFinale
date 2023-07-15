-- Active: 1688241707400@@SG-Database-7664-mysql-master.servers.mongodirector.com@3306@firstDatabase

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg varchar(255) COMMENT 'User CoverImg'
    ) default charset utf8 COMMENT '';

ALTER TABLE accounts
ADD
    coverImg varchar(255) COMMENT 'User CoverImg';

CREATE TABLE
    IF NOT EXISTS vaults(
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId varchar(255) NOT NULL,
        name varchar(255) NOT NULL,
        description varchar(255) NOT NULL,
        img text NOT NULL,
        isPrivate TINYINT NOT NULL DEFAULT 0,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId varchar(255) NOT NULL,
        name varchar(255) NOT NULL,
        description text NOT NULL,
        img text NOT NULL,
        views INT NOT NULL DEFAULT 0,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    keeps (
        Name,
        Description,
        img,
        creatorId
    )
VALUES (
        "dawg",
        "cwazy",
        "asdlkf",
        "asa;lfk"
    );

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId varchar(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE accounts;

DROP TABLE vaults;

DROP TABLE keeps;

DROP TABLE vaultKeeps;

SELECT * FROM keeps
JOIN accounts ON accounts.id = '64b17fe0de8c335127556c93'
WHERE keeps.creatorId = '64b17fe0de8c335127556c93';

SELECT
k.*,
act.*
FROM keeps k
JOIN accounts act ON act.id = '64b17fe0de8c335127556c93'
WHERE k.creatorId = '64b17fe0de8c335127556c93';

SELECT
v.*,
act.*
FROM vaults v
JOIN accounts act ON act.id = '64b17fe0de8c335127556c93'
WHERE v.creatorId = '64b17fe0de8c335127556c93';

SELECT
vaultkeep.*,
keep.*,
creator.*
FROM vaultKeeps vaultkeep
JOIN keeps keep ON keep.id = vaultkeep.keepId
JOIN accounts creator ON creator.id = vaultkeep.creatorId
WHERE vaultkeep.vaultId = 88;

SELECT * FROM vaultKeeps
JOIN keeps ON keeps.id = vaultKeep.keepId;

SELECT * FROM vaultKeeps
JOIN keeps ON keeps.id = vaultKeeps.keepId
JOIN accounts ON accounts.id = vaultKeeps.creatorId
WHERE vaultKeeps.vaultId = 70;

SELECT
v.*,
act.*
FROM vaults v
JOIN accounts act ON act.id = '64b17fe0de8c335127556c93'
WHERE v.creatorId = '64b17fe0de8c335127556c93'



