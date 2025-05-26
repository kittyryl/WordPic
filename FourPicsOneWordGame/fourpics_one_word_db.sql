-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 26, 2025 at 08:20 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fourpics_one_word_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `gamelevels`
--

CREATE TABLE `gamelevels` (
  `GameLevelId` int(11) NOT NULL,
  `CorrectWord` varchar(50) NOT NULL,
  `ImagePath1` varchar(255) NOT NULL,
  `ImagePath2` varchar(255) NOT NULL,
  `ImagePath3` varchar(255) NOT NULL,
  `ImagePath4` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `gamelevels`
--

INSERT INTO `gamelevels` (`GameLevelId`, `CorrectWord`, `ImagePath1`, `ImagePath2`, `ImagePath3`, `ImagePath4`) VALUES
(55, 'Apple', 'C:\\Users\\dhary\\Downloads\\Bitten Apple.jpg', 'C:\\Users\\dhary\\Downloads\\Bitten Apple.jpg', 'C:\\Users\\dhary\\Downloads\\Bitten Apple.jpg', 'C:\\Users\\dhary\\Downloads\\Bitten Apple.jpg'),
(56, 'Banana', 'C:\\Users\\dhary\\Downloads\\banana.png', 'C:\\Users\\dhary\\Downloads\\banana.png', 'C:\\Users\\dhary\\Downloads\\banana.png', 'C:\\Users\\dhary\\Downloads\\banana.png');

-- --------------------------------------------------------

--
-- Table structure for table `userprogresses`
--

CREATE TABLE `userprogresses` (
  `UserProgressId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `GameLevelId` int(11) NOT NULL,
  `IsCompleted` tinyint(1) NOT NULL DEFAULT 0 COMMENT '0=No, 1=Yes',
  `Score` int(11) NOT NULL DEFAULT 0,
  `HintsUsedInAttempt` int(11) NOT NULL DEFAULT 0,
  `CompletedDate` datetime DEFAULT NULL,
  `WrongGuessesInAttempt` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userprogresses`
--

INSERT INTO `userprogresses` (`UserProgressId`, `UserId`, `GameLevelId`, `IsCompleted`, `Score`, `HintsUsedInAttempt`, `CompletedDate`, `WrongGuessesInAttempt`) VALUES
(282, 2, 55, 1, 10, 0, '2025-05-26 14:01:24', 0),
(283, 5, 55, 1, 10, 0, '2025-05-26 14:02:02', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserId` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Role` int(11) NOT NULL COMMENT '0=User, 1=Admin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserId`, `Username`, `PasswordHash`, `Role`) VALUES
(2, 'fouryl', '$2a$11$8mq/sDzdy3acRqh2kOKQBe.mTqN894KM5Ez0bz.4cgw0zxzf179KS', 1),
(5, 'asd', '$2a$11$O9S7nezhbthw1PxxCNezQ.gx42ENe.3PuzcOB7YzAB05KCE4MyWdG', 1),
(11, 'qwe', '$2a$11$o2VJCCmjbvKh/dkLkZ1QQOYTmBrUT6RdYFGrlEOPWpQDP2b35uBKC', 0),
(12, 'asdasd', '$2a$11$o2hmo/J8zGbwaJ.GRP8p5uMy8n3/6WYsF8TzrSU3J7MWjv8vJOFnK', 0),
(13, 'fourivy', '$2a$11$NFDvwPkyB1LXj2lGwnhKfOyi3kvE85xj0kD28YocLDJ6E7R0N84We', 0),
(14, 'dsa', '$2a$11$4jTCGYK.BzzByVMAY58Bpez1jxeRB7n/yvnB/qpG/Y3/Z0JLIj2xa', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `gamelevels`
--
ALTER TABLE `gamelevels`
  ADD PRIMARY KEY (`GameLevelId`);

--
-- Indexes for table `userprogresses`
--
ALTER TABLE `userprogresses`
  ADD PRIMARY KEY (`UserProgressId`),
  ADD UNIQUE KEY `UQ_User_GameLevel_idx` (`UserId`,`GameLevelId`),
  ADD UNIQUE KEY `uniq_user_level` (`UserId`,`GameLevelId`),
  ADD KEY `FK_UserProgress_User_idx` (`UserId`),
  ADD KEY `FK_UserProgress_GameLevel_idx` (`GameLevelId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserId`),
  ADD UNIQUE KEY `Username_UNIQUE` (`Username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `gamelevels`
--
ALTER TABLE `gamelevels`
  MODIFY `GameLevelId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT for table `userprogresses`
--
ALTER TABLE `userprogresses`
  MODIFY `UserProgressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=284;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `userprogresses`
--
ALTER TABLE `userprogresses`
  ADD CONSTRAINT `FK_UserProgress_GameLevel` FOREIGN KEY (`GameLevelId`) REFERENCES `gamelevels` (`GameLevelId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_UserProgress_User` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
