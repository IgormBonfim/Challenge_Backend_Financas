CREATE TABLE `tbreceita` (
  `IdReceita` int NOT NULL AUTO_INCREMENT,
  `DescricaoReceita` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ValorReceita` decimal(6,2) NOT NULL,
  `DataReceita` date NOT NULL,
  `IdCategoria` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`IdReceita`),
  KEY `IX_TbReceita_CategoriaId` (`IdCategoria`),
  CONSTRAINT `ReceitaCategoria` FOREIGN KEY (`IdCategoria`) REFERENCES `tbcategoria` (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci