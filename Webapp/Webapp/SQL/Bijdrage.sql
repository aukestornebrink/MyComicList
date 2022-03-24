Create table Bijdrage (
	Comic_ID INTEGER,
    Contributer_ID INTEGER,
    Functie VARCHAR(100),
	PRIMARY KEY (Comic_ID, Contributer_ID),
    FOREIGN KEY (Comic_ID) REFERENCES Comic(Comic_ID),
    FOREIGN KEY (Contributer_ID) REFERENCES Contributor(Contributor_ID)
)