-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 25 2025 г., 12:14
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `pr45`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Library`
--

CREATE TABLE `Library` (
  `Id` int NOT NULL,
  `Name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` text NOT NULL,
  `Mail` varchar(255) NOT NULL,
  `Phone` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Library`
--

INSERT INTO `Library` (`Id`, `Name`, `Address`, `Mail`, `Phone`) VALUES
(1, '1', '1', '1', '1');

-- --------------------------------------------------------

--
-- Структура таблицы `Literature`
--

CREATE TABLE `Literature` (
  `Id` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` text NOT NULL,
  `Author` varchar(255) NOT NULL,
  `ReleaseDate` date NOT NULL,
  `Publisher` varchar(255) NOT NULL,
  `Price` int NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Literature`
--

INSERT INTO `Literature` (`Id`, `Name`, `Description`, `Author`, `ReleaseDate`, `Publisher`, `Price`) VALUES
(1, '1234', '1234', '1234', '0001-01-01', '4', 1234);

-- --------------------------------------------------------

--
-- Структура таблицы `Tasks`
--

CREATE TABLE `Tasks` (
  `Id` int NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Priority` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateExecute` datetime(6) NOT NULL,
  `Comment` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Done` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Tasks`
--

INSERT INTO `Tasks` (`Id`, `Name`, `Priority`, `DateExecute`, `Comment`, `Done`) VALUES
(1, '1233', '1233', '0001-01-01 00:00:00.000000', '1233', 0),
(3, '123', '123', '2000-12-12 00:00:00.000000', '123', 1),
(4, '123', '123', '0001-01-01 00:00:00.000000', '123', 1),
(5, '123', '123', '0001-01-01 00:00:00.000000', '123', 1),
(123, '123', '123', '0001-01-01 00:00:00.000000', '123', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `Login` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Token` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO `Users` (`Id`, `Login`, `Password`, `Token`) VALUES
(3, '1234', '10000.iaFng0z9LiFR8h84oCT9iw==.Eep8bWmFdYCMSaaasbMO2HiyKHFNTKCuWpcsZq4JS3o=', 'UobfdGrDkizBXLq/LmD6ZJSdtrxEeFAPJYU+p+VYqk4='),
(4, '123', '10000.b98cvFw4QjMnhcrzqqXUIQ==.WHGtnVzucYlPsO+zpKWZ87oZJem1Yq2itjpTAdTNaT4=', 'zt6Tv8iTjhNf0xKJhi4Uol8kY+Da4OWmQija3tVa4CM='),
(5, 'asd', '10000.XK86K+WDVYMkskbGw/S7cw==.QQIZ72Zy5pKo9QBCEDPobb3+KP5dc4nUsthx0FBvA88=', '2/th5AI8lfpV6xfHklJIRYF0n3NqUMh6PuB1MtmNEoI=');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Tasks`
--
ALTER TABLE `Tasks`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Tasks`
--
ALTER TABLE `Tasks`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=125;

--
-- AUTO_INCREMENT для таблицы `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
