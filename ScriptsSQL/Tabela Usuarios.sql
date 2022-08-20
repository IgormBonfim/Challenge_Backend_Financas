CREATE TABLE `tbusuario` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `emailUsuario` varchar(50)  NOT NULL,
  `senhaUsuario` varchar(50) NOT NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `emailUsuario_UNIQUE` (`emailUsuario`)
);