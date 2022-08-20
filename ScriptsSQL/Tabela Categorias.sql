CREATE TABLE `tbcategoria` (
  `IdCategoria` int NOT NULL AUTO_INCREMENT,
  `NomeCategoria` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`IdCategoria`),
  UNIQUE KEY `nomeCategoria_UNIQUE` (`NomeCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci