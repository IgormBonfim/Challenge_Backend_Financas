CREATE TABLE `tbdespesa` (
  `IdDespesa` int NOT NULL AUTO_INCREMENT,
  `DescricaoDespesa` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ValorDespesa` decimal(6,2) NOT NULL,
  `DataDespesa` date NOT NULL,
  `IdCategoria` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`IdDespesa`),
  KEY `IX_TbDespesa_CategoriaId` (`IdCategoria`),
  CONSTRAINT `IdCategoria` FOREIGN KEY (`IdCategoria`) REFERENCES `tbcategoria` (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci