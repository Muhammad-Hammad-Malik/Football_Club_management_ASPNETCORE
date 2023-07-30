CREATE TABLE playerimagevideo
(
    ShirtNo INT,
    ImageData VARBINARY(MAX),
    VideoData VARBINARY(MAX),
    CONSTRAINT PK_playerimagevideo PRIMARY KEY (ShirtNo),
    CONSTRAINT FK_playerimagevideo_playername FOREIGN KEY (ShirtNo) REFERENCES PlayerName(shirtno)
);