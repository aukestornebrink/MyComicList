CREATE TABLE Comic (
    Comic_ID int NOT NULL AUTO_INCREMENT,
    Name varchar(250) NOT NULL,
    Series varchar(250),
    Release_date date NOT NULL,
    Print int NOT NULL,
    Language varchar(30) NOT NULL,
    Summary varchar(1000),
    Photo_front varchar(100),
    Genre varchar(30) NOT NULL,
    PRIMARY KEY (Comic_ID)
)