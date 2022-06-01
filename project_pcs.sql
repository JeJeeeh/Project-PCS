-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 01, 2022 at 05:44 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project_pcs`
--
CREATE DATABASE IF NOT EXISTS `project_pcs` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `project_pcs`;

-- --------------------------------------------------------

--
-- Table structure for table `bundle`
--

CREATE TABLE `bundle` (
  `bu_id` double NOT NULL,
  `bu_name` varchar(50) NOT NULL,
  `bu_price` double NOT NULL,
  `bu_status` int(11) NOT NULL,
  `bu_description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `dtrans`
--

CREATE TABLE `dtrans` (
  `dt_id` double NOT NULL,
  `dt_ht_id` double NOT NULL,
  `dt_me_id` double NOT NULL,
  `dt_amount` double NOT NULL,
  `dt_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `htrans`
--

CREATE TABLE `htrans` (
  `ht_id` double NOT NULL,
  `ht_invoice` varchar(50) NOT NULL,
  `ht_total` double NOT NULL,
  `ht_date` date NOT NULL,
  `ht_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `ingredient`
--

CREATE TABLE `ingredient` (
  `in_id` double NOT NULL,
  `in_name` varchar(50) NOT NULL,
  `in_price` double NOT NULL,
  `in_stock` double NOT NULL,
  `in_status` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ingredient`
--

INSERT INTO `ingredient` (`in_id`, `in_name`, `in_price`, `in_stock`, `in_status`) VALUES
(1, 'Roti Bun', 12000, 2, 1),
(2, 'Keju', 5000, 13, 1),
(3, 'Selada', 4000, 2, 1),
(4, 'Beef Patty', 8000, 6, 1),
(5, 'Kentang', 4000, 8, 1),
(6, 'Chicken Patty', 6000, 5, 1),
(7, 'Cone', 2000, 13, 1),
(8, 'Es Krim', 3000, 5, 1),
(9, 'Tepung', 2000, 4, 1),
(10, 'Ayam Paha Bawah', 20000, 10, 1),
(11, 'Ayam Paha Atas', 30000, 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `menu`
--

CREATE TABLE `menu` (
  `me_id` double NOT NULL,
  `me_name` varchar(50) NOT NULL,
  `me_price` double NOT NULL,
  `me_stock` double DEFAULT NULL,
  `me_ty_id` double NOT NULL,
  `me_status` int(11) NOT NULL,
  `me_description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `menu`
--

INSERT INTO `menu` (`me_id`, `me_name`, `me_price`, `me_stock`, `me_ty_id`, `me_status`, `me_description`) VALUES
(1, 'Hamburger', 40000, 0, 1, 1, 'Hamburger enak puol claire'),
(2, 'Kentang Goreng', 10000, 0, 1, 1, 'Kentang Goreng'),
(3, 'Ice Cream Cone', 10000, 0, 3, 1, 'Es Krim bukan peju nya r'),
(4, 'Sprite', 4000, 0, 1, 1, 'Sprite pake tepung');

-- --------------------------------------------------------

--
-- Table structure for table `menu_bundle`
--

CREATE TABLE `menu_bundle` (
  `mb_id` double NOT NULL,
  `mb_me_id` double NOT NULL,
  `mb_bu_id` double NOT NULL,
  `mb_quantity` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `menu_ingredient`
--

CREATE TABLE `menu_ingredient` (
  `mi_id` double NOT NULL,
  `mi_me_id` double NOT NULL,
  `mi_in_id` double NOT NULL,
  `mi_quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `menu_ingredient`
--

INSERT INTO `menu_ingredient` (`mi_id`, `mi_me_id`, `mi_in_id`, `mi_quantity`) VALUES
(23, 1, 1, 1),
(24, 1, 2, 1),
(25, 1, 3, 1),
(26, 1, 4, 1),
(27, 3, 7, 1),
(28, 3, 8, 1),
(29, 4, 9, 1);

-- --------------------------------------------------------

--
-- Table structure for table `privilege`
--

CREATE TABLE `privilege` (
  `pr_id` double NOT NULL,
  `pr_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `privilege`
--

INSERT INTO `privilege` (`pr_id`, `pr_name`) VALUES
(1, 'admin'),
(2, 'kitchen'),
(3, 'cashier');

-- --------------------------------------------------------

--
-- Table structure for table `type`
--

CREATE TABLE `type` (
  `ty_id` double NOT NULL,
  `ty_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `type`
--

INSERT INTO `type` (`ty_id`, `ty_name`) VALUES
(1, 'food'),
(2, 'beverage'),
(3, 'dessert');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `us_id` double NOT NULL,
  `us_username` varchar(50) NOT NULL,
  `us_password` text NOT NULL,
  `us_pr_id` double NOT NULL,
  `us_name` varchar(50) DEFAULT NULL,
  `us_status` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`us_id`, `us_username`, `us_password`, `us_pr_id`, `us_name`, `us_status`) VALUES
(1, 'admin', 'admin', 1, NULL, 1),
(2, 'kitchen', 'kitchen', 2, 'kitchen', 1),
(3, 'cashier', 'cashier', 3, 'cashier', 1),
(4, 'tes', 'tes', 2, 'tes', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bundle`
--
ALTER TABLE `bundle`
  ADD PRIMARY KEY (`bu_id`);

--
-- Indexes for table `dtrans`
--
ALTER TABLE `dtrans`
  ADD PRIMARY KEY (`dt_id`);

--
-- Indexes for table `htrans`
--
ALTER TABLE `htrans`
  ADD PRIMARY KEY (`ht_id`);

--
-- Indexes for table `ingredient`
--
ALTER TABLE `ingredient`
  ADD PRIMARY KEY (`in_id`);

--
-- Indexes for table `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`me_id`),
  ADD KEY `me_ty_id` (`me_ty_id`);

--
-- Indexes for table `menu_bundle`
--
ALTER TABLE `menu_bundle`
  ADD PRIMARY KEY (`mb_id`);

--
-- Indexes for table `menu_ingredient`
--
ALTER TABLE `menu_ingredient`
  ADD PRIMARY KEY (`mi_id`);

--
-- Indexes for table `privilege`
--
ALTER TABLE `privilege`
  ADD PRIMARY KEY (`pr_id`);

--
-- Indexes for table `type`
--
ALTER TABLE `type`
  ADD PRIMARY KEY (`ty_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`us_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `menu_bundle`
--
ALTER TABLE `menu_bundle`
  MODIFY `mb_id` double NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `menu_ingredient`
--
ALTER TABLE `menu_ingredient`
  MODIFY `mi_id` double NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `privilege`
--
ALTER TABLE `privilege`
  MODIFY `pr_id` double NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `type`
--
ALTER TABLE `type`
  MODIFY `ty_id` double NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
