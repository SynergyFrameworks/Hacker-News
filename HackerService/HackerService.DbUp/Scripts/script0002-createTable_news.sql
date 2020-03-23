CREATE TABLE IF NOT EXISTS `news` (
  `id` varchar(36) NOT NULL,
  `title` varchar(200) NOT NULL, 
  `type` tinyint(1) NOT NULL,
  `@time` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
