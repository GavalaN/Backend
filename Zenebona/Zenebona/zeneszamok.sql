-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 08. 12:18
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `zeneszamok`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eloadok`
--

CREATE TABLE `eloadok` (
  `Id` int(11) NOT NULL,
  `Nev` longtext NOT NULL,
  `Nemzetiseg` longtext NOT NULL,
  `Elo` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `eloadok`
--

INSERT INTO `eloadok` (`Id`, `Nev`, `Nemzetiseg`, `Elo`) VALUES
(1, 'Én', 'magyar', 1),
(2, 'Te', 'magyar', 0),
(3, 'Ő', 'magyar', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kiadok`
--

CREATE TABLE `kiadok` (
  `Id` int(11) NOT NULL,
  `Nev` longtext NOT NULL,
  `AlapitasEve` smallint(6) NOT NULL,
  `Cim` longtext NOT NULL,
  `Email` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `kiadok`
--

INSERT INTO `kiadok` (`Id`, `Nev`, `AlapitasEve`, `Cim`, `Email`) VALUES
(1, 'Muzsika BT.', 2000, 'Miskolc', 'van'),
(2, 'A Zene Az Jó', 2020, 'Miskolc', 'azeneazjo@valami.com'),
(3, 'A Zene', 1870, 'Pest-Buda', 'akkor még nem volt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `zeneszamok`
--

CREATE TABLE `zeneszamok` (
  `Id` int(11) NOT NULL,
  `Nev` longtext DEFAULT NULL,
  `MegjelenesEve` int(11) NOT NULL,
  `LejatszasiIdo` double NOT NULL,
  `Jogdijas` tinyint(1) NOT NULL,
  `EloadoId` int(11) DEFAULT NULL,
  `KiadoId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `zeneszamok`
--

INSERT INTO `zeneszamok` (`Id`, `Nev`, `MegjelenesEve`, `LejatszasiIdo`, `Jogdijas`, `EloadoId`, `KiadoId`) VALUES
(1, 'ZeneBona', 2008, 5.6, 1, 1, 1),
(2, 'A Dalocska', 2022, 2.8, 0, 2, 2),
(3, 'Kossuth Lajos azt üzente', 1880, 3.4, 1, 3, 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241108085802_Initial', '8.0.10');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `eloadok`
--
ALTER TABLE `eloadok`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `kiadok`
--
ALTER TABLE `kiadok`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `zeneszamok`
--
ALTER TABLE `zeneszamok`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Zeneszamok_EloadoId` (`EloadoId`),
  ADD KEY `IX_Zeneszamok_KiadoId` (`KiadoId`);

--
-- A tábla indexei `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `eloadok`
--
ALTER TABLE `eloadok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `kiadok`
--
ALTER TABLE `kiadok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `zeneszamok`
--
ALTER TABLE `zeneszamok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `zeneszamok`
--
ALTER TABLE `zeneszamok`
  ADD CONSTRAINT `FK_Zeneszamok_Eloadok_EloadoId` FOREIGN KEY (`EloadoId`) REFERENCES `eloadok` (`Id`),
  ADD CONSTRAINT `FK_Zeneszamok_Kiadok_KiadoId` FOREIGN KEY (`KiadoId`) REFERENCES `kiadok` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
