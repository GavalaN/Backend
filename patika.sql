-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 27. 21:41
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `patika`
--
CREATE DATABASE IF NOT EXISTS `patika` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `patika`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `betegseg`
--

CREATE TABLE IF NOT EXISTS `betegseg` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Megnevezes` varchar(255) NOT NULL,
  `Leiras` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `betegseg`
--

INSERT INTO `betegseg` (`Id`, `Megnevezes`, `Leiras`) VALUES
(1, 'magas vérnyomás', 'A hipertónia, más néven magas vérnyomás, vagy néha artériás hipertónia elterjedt krónikus kóros állapot, amelynek során emelkedik a vérnyomás az artériákban. Ehhez az emelkedéshez a szívnek a szokásosnál több munkájába kerül a vér erekben való keringtetése. A vérnyomás megállapítása két méréssel, a szisztoléssel és a diasztoléssel történik, ami attól függ, hogy a szívizom éppen összehúzódik (szisztolés) vagy ellazul (diasztolés) a szívverések között. A normál vérnyomás nyugalmi állapotban 100–140 Hgmm szisztolés (felső érték) és 60–90 Hgmm diasztolés (alsó érték) tartományon belül van. A magas vérnyomás ismérve, hogy az artériás vérnyomás tartósan meghaladja a 140 Hgmm szisztolés, illetve a 90 Hgmm diasztolés értéket.'),
(2, 'hörghurut', 'A hörghurut a légcső és az ennek folytatását képező hörgők gyakran váladékképződéssel kísért gyulladása.'),
(3, 'asztma', 'Az asztma (görögül ἅσθμα, ásthma, „zihálás\") a légutak egyik gyakori krónikus gyulladásos betegsége, amelynek jellemzői a változékony és ismétlődő tünetek, a légutak reverzibilis elzáródása, és a hörgőgörcs. Gyakori tünetei közé tartozik a zihálás, a köhögés, a mellkasi szorító érzés, és a légszomj.');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyogyszer`
--

CREATE TABLE IF NOT EXISTS `gyogyszer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nev` varchar(64) NOT NULL,
  `Hatoanyag` varchar(64) NOT NULL,
  `Venykoteles` tinyint(1) NOT NULL,
  `kepnev` varchar(32) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `gyogyszer`
--

INSERT INTO `gyogyszer` (`Id`, `Nev`, `Hatoanyag`, `Venykoteles`, `kepnev`) VALUES
(1, 'TRITACE 5 mg tabletta', 'ramipril', 1, 'tritace5.jpg'),
(2, 'ALVESCO 160 µg túlnyomásos inhalációs oldat', 'ciclesonide', 1, 'alvesco60.jpg'),
(3, 'AMBROXOL-EGIS 30 mg tabletta', 'ambroxol', 0, 'ambroxolegis.jpg'),
(4, 'CONCOR 5 mg filmtabletta', 'bizoprolol', 1, 'concor5.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kezel`
--

CREATE TABLE IF NOT EXISTS `kezel` (
  `GyogyszerId` int(11) NOT NULL,
  `BetegsegId` int(11) NOT NULL,
  KEY `GyogyszerId` (`GyogyszerId`),
  KEY `BetegsegId` (`BetegsegId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `kezel`
--

INSERT INTO `kezel` (`GyogyszerId`, `BetegsegId`) VALUES
(2, 3),
(3, 2),
(4, 1),
(1, 1);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `kezel`
--
ALTER TABLE `kezel`
  ADD CONSTRAINT `kezel_ibfk_1` FOREIGN KEY (`GyogyszerId`) REFERENCES `gyogyszer` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `kezel_ibfk_2` FOREIGN KEY (`BetegsegId`) REFERENCES `betegseg` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
