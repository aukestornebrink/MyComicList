CREATE TABLE Account (
    Account_ID int NOT NULL AUTO_INCREMENT,
    Nickname varchar(100) NOT NULL,
    Role varchar(20) NOT NULL,
    Password varchar(100) NOT NULL,
    Email varchar(200) NOT NULL,
    PRIMARY KEY (Account_ID)
)