-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           26.10.0 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.21.0.7344
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para bandas
CREATE DATABASE IF NOT EXISTS `bandas` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bandas`;

-- Copiando estrutura para tabela bandas.bandas
CREATE TABLE IF NOT EXISTS `bandas` (
  `idbandas` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `integrantes` int DEFAULT NULL,
  `ranking` int DEFAULT NULL,
  `fk_genero` int DEFAULT NULL,
  PRIMARY KEY (`idbandas`),
  KEY `genero_idx` (`fk_genero`),
  CONSTRAINT `genero` FOREIGN KEY (`fk_genero`) REFERENCES `generos` (`idgenero`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela bandas.bandas: ~4 rows (aproximadamente)
INSERT IGNORE INTO `bandas` (`idbandas`, `nome`, `integrantes`, `ranking`, `fk_genero`) VALUES
	(1, 'Skank', 5, 1, 1),
	(2, 'Metallica', 4, 1, 1),
	(5, 'Evanescence', 7, 10, 2),
	(6, 'Coldplay', 5, 5, 6);

-- Copiando estrutura para tabela bandas.generos
CREATE TABLE IF NOT EXISTS `generos` (
  `idgenero` int NOT NULL AUTO_INCREMENT,
  `genero` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idgenero`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela bandas.generos: ~5 rows (aproximadamente)
INSERT IGNORE INTO `generos` (`idgenero`, `genero`) VALUES
	(1, 'Rock'),
	(2, 'Metal'),
	(3, 'Pagode'),
	(4, 'Gospel'),
	(5, 'Funk'),
	(6, 'Pop'),
	(7, 'Sertanejo'),
	(8, 'teste');

-- Copiando estrutura para procedure bandas.sp_alteraBanda
DELIMITER //
CREATE PROCEDURE `sp_alteraBanda`(
    idbanda int, nome varchar(45), 
    integrantes int,
    ranking int,
    genero int)
BEGIN
UPDATE `bandas` SET

`nome` = nome,
`integrantes` = integrantes,
`ranking` = ranking,
`fk_genero` = genero

WHERE `idbandas` = idbanda;
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_consultaLogin
DELIMITER //
CREATE PROCEDURE `sp_consultaLogin`(
	IN `usuario` varchar(100),
	IN `senha` varchar(100)
)
BEGIN
Select * from usuarios where usuarios.nome = usuario and usuarios.senha = senha;
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_insereBanda
DELIMITER //
CREATE PROCEDURE `sp_insereBanda`(nome varchar(45), 
                                   integrantes int, ranking int, genero int)
BEGIN
INSERT INTO `bandas`
(`nome`,
`integrantes`,
`ranking`,
`fk_genero`)
VALUES
(nome,
integrantes,
ranking,
genero);
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_insereGenero
DELIMITER //
CREATE PROCEDURE `sp_insereGenero`(
	IN `nome` varchar(45)
)
BEGIN
    INSERT INTO generos(genero) VALUES (nome);
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_listaBandas
DELIMITER //
CREATE PROCEDURE `sp_listaBandas`()
BEGIN
     SELECT 
        b.idbandas, 
        b.nome, 
        b.integrantes,
        b.ranking, 
        g.genero
    FROM bandas b
    INNER JOIN generos g 
        ON g.idgenero = b.fk_genero;
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_listaGeneros
DELIMITER //
CREATE PROCEDURE `sp_listaGeneros`()
BEGIN
   select * from generos;
END//
DELIMITER ;

-- Copiando estrutura para procedure bandas.sp_removeBanda
DELIMITER //
CREATE PROCEDURE `sp_removeBanda`(idbanda int)
BEGIN
    delete from bandas where idbandas = idbanda;
END//
DELIMITER ;

-- Copiando estrutura para tabela bandas.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `idusuarios` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bandas.usuarios: ~0 rows (aproximadamente)
INSERT IGNORE INTO `usuarios` (`idusuarios`, `nome`, `senha`) VALUES
	(1, 'root', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
