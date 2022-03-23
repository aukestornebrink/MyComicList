CREATE TABLE Bezit (
    Account_ID int NOT NULL,
    Comic_ID int NOT NULL,
    Status varchar(250),
    Comments varchar(1000),
    PRIMARY KEY (Account_ID, Comic_ID),
    FOREIGN KEY (Account_ID) REFERENCES Account (Account_ID),
    FOREIGN KEY (Comic_ID) REFERENCES Comic (Comic_ID)
)