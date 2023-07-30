CREATE TABLE playername (
  pid INT PRIMARY KEY,
  fname VARCHAR(50),
  lname VARCHAR(50),
  age INT,
  position VARCHAR(50),
  shirtno INT UNIQUE,
  nationality VARCHAR(50)
);

select * from playername;
INSERT INTO playername (pid, fname, lname, age, position, shirtno, nationality)
VALUES
  (1, 'Manuel', 'Neuer', 36, 'GK', 1, 'Germany'),
  (2, 'Yann', 'Sommer', 33, 'GK', 27, 'Switzerland'),
  (3, 'Sven', 'Ulreich', 29, 'GK', 26, 'Germany'),
  (4, 'Benjamin', 'Pavard', 26, 'RB', 5, 'France'),
  (5, 'Josep', 'Stanisic', 22, 'RB', 23, 'Croatia'),
  (6, 'Nousair', 'Mazzroui', 24, 'RB', 32, 'Morocco'),
  (7, 'Joao', 'Cancelo', 27, 'RB', 35, 'Portugal'),
  (8, 'Alphonso', 'Davies', 22, 'LB', 19, 'Canada'),
  (9, 'Lucas', 'Hernandez', 27, 'CB', 21, 'France'),
  (10, 'Mathjis', 'De Ligt', 23, 'CB', 4, 'Netherlands'),
  (11, 'Dayot', 'Upamecano', 22, 'CB', 2, 'France'),
  (12, 'Paul', 'Wanner', 17, 'CM', 31, 'Germany'),
  (13, 'Ryan', 'Gravenberch', 21, 'CM', 15, 'Netherlands'),
  (14, 'Joshua', 'Kimmich', 28, 'CM', 6, 'Germany'),
  (15, 'Leon', 'Goretzka', 28, 'CM', 8, 'Germany'),
  (16, 'Jamal', 'Musiala', 20, 'CAM', 42, 'Germany'),
  (17, 'Thomas', 'Muller', 33, 'CAM', 25, 'Germany'),
  (18, 'Anjon', 'Ibrahimovic', 18, 'CAM', 37, 'Germany'),
  (19, 'Leroy', 'Sane', 27, 'LW', 10, 'Germany'),
  (20, 'Sadio', 'Mane', 30, 'LW', 17, 'Senegal'),
  (21, 'King', 'Coman', 26, 'RW', 11, 'France'),
  (22, 'Serge', 'Gnabry', 28, 'RW', 7, 'Germany'),
  (23, 'Chupo', 'Moting', 32, 'ST', 9, 'Cameroon'),
  (24, 'Mathys', 'Tel', 18, 'ST', 39, 'France');

  CREATE TABLE playerstats (
  shirtno INT PRIMARY KEY REFERENCES playername(shirtno),
  goals INT,
  assists INT,
  passes INT,
  dribbles INT,
  chances INT,
  slidetackles INT,
  standtackles INT,
  duels INT,
  interceptions INT,
  saves INT
);

INSERT INTO playerstats (shirtno, goals, assists, passes, dribbles, chances, slidetackles, standtackles, duels, interceptions, saves)
VALUES
  (1, 2, 10, 15000, 90, 30, 20, 10, 120, 0, 3000),
  (27, 0, 4, 6000, 10, 2, 10, 10, 60, 0, 1000),
  (26, 0, 4, 3000, 10, 2, 10, 10, 60, 0, 300),
  (5, 30, 50, 26000, 410, 200, 610, 510, 460, 430, 0),
  (23, 10, 20, 4000, 210, 72, 210, 310, 160, 100, 0),
  (32, 23, 74, 26430, 800, 300, 130, 310, 260, 143, 0),
  (35, 60, 144, 73500, 1110, 521, 155, 140, 260, 130, 0),
  (19, 45, 97, 25746, 1400, 142, 120, 410, 260, 140, 0),
  (4, 53, 54, 26000, 130, 124, 3000, 1230, 1460, 500, 0),
  (21, 21, 34, 13000, 210, 100, 2014, 1510, 2160, 510, 0),
  (2, 15, 67, 46000, 120, 202, 1025, 1340, 1160, 415, 0),
  (31, 10, 24, 13000, 120, 62, 10, 10, 60, 40, 0),
  (15, 54, 20, 24300, 1310, 62, 110, 110, 60, 70, 0),
  (6, 120, 244, 76000, 810, 432, 510, 210, 160, 700, 0),
  (8, 210, 134, 54000, 710, 242, 710, 517, 460, 1015, 0),
  (42, 70, 64, 59424, 1510, 172, 60, 70, 130, 200, 0),
  (25, 313, 299, 112430, 710, 752, 120, 140, 460, 340, 0),
  (10, 153, 124, 26500, 2350, 545, 100, 100, 60, 153, 0),
  (17, 253, 224, 36000, 1550, 245, 100, 100, 60, 153, 0),
  (37, 53, 24, 16000, 150, 45, 100, 100, 260, 353, 0),
  (11, 125, 124, 26000, 250, 4245, 100, 100, 260, 254, 0),
  (7, 203, 154, 14527, 230, 2145, 10, 10, 20, 353, 0),
  (39, 73, 34, 17589, 150, 345, 100, 100, 260, 353, 0),
  (9, 253, 164, 16000, 350, 445, 45, 100, 260, 213, 0);

CREATE TABLE playercontact (
    pid INT PRIMARY KEY,
    agency_name VARCHAR(255),
    contact VARCHAR(255),
    address VARCHAR(255),
    contract INT,
    FOREIGN KEY (pid) REFERENCES playername(pid)
);

INSERT INTO playercontact (pid, agency_name, contact, address, contract)
VALUES
  (1, 'Neuer Sports Agency', 'Peter Neuer', 'Lindenstrasse 10, Berlin', 2),
  (2, 'Sommer Management', 'Maria Sommer', 'Bahnhofstrasse 12, Zurich', 3),
  (3, 'Ulreich Agency', 'Markus Ulreich', 'Kaiserplatz 5, Munich', 1),
  (4, 'Pavard Sports', 'Stephane Pavard', 'Rue de la Paix 20, Paris', 2),
  (5, 'Stanisic Management', 'Ivan Stanisic', 'Trg Bana Jelacica 3, Zagreb', 3),
  (6, 'Mazzroui Sports', 'Youssef Mazzroui', 'Avenue Mohammed V, Casablanca', 1),
  (7, 'Cancelo Agency', 'Ana Cancelo', 'Rua de Santa Catarina 10, Porto', 2),
  (8, 'Davies Management', 'Alphonso Davies Sr.', 'Oak Street 23, Edmonton', 4),
  (9, 'Hernandez Sports', 'Lucas Hernandez', 'Avenue des Champs-Elysees 15, Paris', 5),
  (10, 'De Ligt Management', 'Mino Raiola', 'Via Montenapoleone 8, Milan', 2),
  (11, 'Upamecano Sports', 'Dayot Upamecano', 'Rue du Faubourg Saint-Honore 12, Paris', 3),
  (12, 'Wanner Agency', 'Franz Wanner', 'Karlstrasse 20, Munich', 1),
  (13, 'Gravenberch Sports', 'Nigel de Jong', 'Keizersgracht 20, Amsterdam', 3),
  (14, 'Kimmich Management', 'Raimond Aumann', 'Muenchner Strasse 8, Munich', 4),
  (15, 'Goretzka Sports', 'Matthias Goretzka', 'Bergstrasse 1, Bochum', 2),
  (16, 'Musiala Agency', 'Giovanni Branchini', 'Via Cappello 10, Bologna', 3),
  (17, 'Muller Management', 'Gerhard Muller', 'Brienner Strasse 8, Munich', 5),
  (18, 'Ibrahimovic Sports', 'Zlatan Ibrahimovic', 'Ostermalmstorg 1, Stockholm', 2),
  (19, 'Sane Agency', 'Jamel Sane', 'Kaiser-Friedrich-Ring 12, Cologne', 3),
  (20, 'Mane Sports', 'Sadio Mane', 'Avenue Cheikh Anta Diop, Dakar', 4),
  (21, 'Coman Management', 'Giovanni Branchini', 'Via Monte Napoleone 12, Milan', 5),
  (22, 'Gnabry Sports', 'Serge Gnabry Sr.', 'Theodor-Heuss-Strasse 10, Stuttgart', 2),
  (23, 'Moting Agency', 'Eric Maxim Choupo-Moting', 'Rue de l\Ecole de Medecine 5, Paris', 3),
  (24, 'Residencia franco','Francois Tel','Rue de l\Ecole de Medecine 7, Paris',4);

   CREATE TABLE playerfinancial (
  pid INT PRIMARY KEY,
  tvalue int,
  wages int
);
INSERT INTO playerfinancial (pid, tvalue, wages)
VALUES
  (1, 70, 15),
  (2, 8, 3),
  (3, 2, 1),
  (4, 50, 5),
  (5, 0.2, 0.1),
  (6, 1.5, 0.5),
  (7, 60, 8),
  (8, 80, 10),
  (9, 50, 9),
  (10, 75, 12),
  (11, 60, 6),
  (12, 0.05, 0.01),
  (13, 30, 2),
  (14, 85, 15),
  (15, 65, 12),
  (16, 20, 1),
  (17, 50, 10),
  (18, 0.1, 0.05),
  (19, 70, 12),
  (20, 90, 15),
  (21, 60, 10),
  (22, 50, 8),
  (23, 2.5, 1),
  (24, 0.2, 0.05);

 
 CREATE TABLE wishplayer (
  wpid INT PRIMARY KEY,
  fname VARCHAR(50),
  lname VARCHAR(50),
  age INT,
  position VARCHAR(50),
  shirtno INT UNIQUE,
  nationality VARCHAR(50)
);
INSERT INTO wishplayer (wpid, fname, lname, age, position, shirtno, nationality)
VALUES
  (1, 'Kylian', 'Mbappe', 23, 'ST', 51, 'France'),
  (2, 'Erling', 'Haaland', 21, 'ST', 52, 'Norway'),
  (3, 'Jadon', 'Sancho', 21, 'RW', 53, 'England'),
  (4, 'Phil', 'Foden', 20, 'CAM', 54, 'England'),
  (5, 'Frenkie', 'De jong', 24, 'CM', 55, 'Netherlands'),
  (6, 'Sergio', 'Ramos', 36, 'CB', 56, 'Spain');

    CREATE TABLE wishplayerstats (
  shirtno INT PRIMARY KEY REFERENCES wishplayer(shirtno),
  goals INT,
  assists INT,
  passes INT,
  dribbles INT,
  chances INT,
  slidetackles INT,
  standtackles INT,
  duels INT,
  interceptions INT,
  saves INT
);
INSERT INTO wishplayerstats (shirtno, goals, assists, passes, dribbles, chances, slidetackles, standtackles, duels, interceptions, saves)
VALUES
  (51, 430, 134, 15000, 290, 4530, 20, 10, 120, 10, 0),
  (52, 350, 124, 16000, 210, 1222, 10, 10, 60, 120, 1000),
  (53, 130, 4, 3000, 10, 2, 10, 10, 60, 0, 0),
  (54, 30, 50, 26000, 410, 200, 610, 510, 460, 430, 0),
  (55, 10, 20, 4000, 210, 72, 210, 310, 160, 100, 0),
  (56, 23, 74, 26430, 800, 300, 130, 310, 260, 143, 0);

  CREATE TABLE wishplayercontact (
    wpid INT PRIMARY KEY,
    agency_name VARCHAR(255),
    contact VARCHAR(255),
    address VARCHAR(255),
    contract INT,
    FOREIGN KEY (wpid) REFERENCES wishplayer(wpid)
);

INSERT INTO wishplayercontact (wpid, agency_name, contact, address, contract)
VALUES
  (1, 'Neuer Sports Agency', 'Peter Neuer', 'Lindenstrasse 10, Berlin', 2),
  (2, 'Sommer Management', 'Maria Sommer', 'Bahnhofstrasse 12, Zurich', 3),
  (3, 'Ulreich Agency', 'Markus Ulreich', 'Kaiserplatz 5, Munich', 1),
  (4, 'Pavard Sports', 'Stephane Pavard', 'Rue de la Paix 20, Paris', 2),
  (5, 'Stanisic Management', 'Ivan Stanisic', 'Trg Bana Jelacica 3, Zagreb', 3),
  (6, 'Mazzroui Sports', 'Youssef Mazzroui', 'Avenue Mohammed V, Casablanca', 1);

 CREATE TABLE wishplayerfinancial (
  wpid INT PRIMARY KEY,
  tvalue int,
  wages int
);

INSERT INTO wishplayerfinancial (wpid, tvalue, wages)
VALUES
  (1, 200, 50),
  (2, 150, 40),
  (3, 100, 30),
  (4, 80 ,25),
  (5, 120, 35),
  (6, 50, 20);

create table coaches(
cid int primary key,
fname varchar(50),
lname varchar(50),
role varchar(50));

INSERT INTO coaches (cid, fname, lname, role)
VALUES 
  (1, 'Julian', 'Nagelsmann', 'Head Coach'),
  (2, 'Danny', 'Rohl', 'Assistant Coach'),
  (3, 'Dino', 'Toppmoller', 'Assistant Coach'),
  (4, 'Xaver', 'Zembrod', 'Assistant Coach'),
  (5, 'Miroslav', 'Klose', 'Striker Coach'),
  (6, 'Holger', 'Broich', 'Fitness Coach'),
  (7, 'Toni', 'Tapalovic', 'Goalkeeper Coach');


  CREATE TABLE injury (
  pid INT,
  incid INT,
  type VARCHAR(50),
  duration INT,
  PRIMARY KEY (pid, incid),
  FOREIGN KEY (pid) REFERENCES playername(pid)
);

INSERT INTO injury (incid, pid, type, duration) 
VALUES 
  (1, 1, 'broken leg', 5),
  (2, 9, 'acl tear', 4),
  (3, 11, 'Hamstring strain', 1);

create table income(
iid int primary key,
iname varchar(50),
itype varchar(50),
amount int);

INSERT INTO income (iid, iname, itype, amount)
VALUES
  (1, 'Ticket Sales', 'Matchday Revenue', 25),
  (2, 'Broadcasting Rights', 'Media Revenue', 150),
  (3, 'Sponsorship', 'Commercial Revenue', 100),
  (4, 'Merchandise', 'Commercial Revenue', 20),
  (5, 'Player Transfers', 'Transfer Revenue', 50),
  (6, 'Stadium Rentals', 'Other Revenue', 5);

  create table expenditures(
  exid int primary key,
  ename varchar(50),
  etype varchar(50),
  amount int);

  INSERT INTO expenditures (exid, ename, etype, amount)
VALUES
  (1, 'Player Wages', 'Salary', 100),
  (2, 'Transfer Fees', 'Transfer', 50),
  (3, 'Stadium Maintenance', 'Infrastructure', 20),
  (4, 'Travel Expenses', 'Logistics', 10),
  (5, 'Marketing', 'Advertisement', 5),
  (6, 'Staff Salaries', 'Salary', 15);

  create table schedule(
  matchday int primary key,
  result varchar(10),
  opponents varchar(50),
  scoreline varchar(50),
  mdate date);

  INSERT INTO schedule (matchday, result, opponents, scoreline, mdate) VALUES
(1, 'W', 'Borussia Dortmund', '3-1', '2023-08-12'),
(2, 'D', 'RB Leipzig', '2-2', '2023-08-20'),
(3, 'W', 'VfL Wolfsburg', '4-0', '2023-08-27'),
(4, 'L', 'Borussia Mönchengladbach', '1-2', '2023-09-02'),
(5, 'W', 'Eintracht Frankfurt', '2-0', '2023-09-09'),
(6, 'W', 'Bayer 04 Leverkusen', '3-2', '2023-09-16'),
(7, 'D', '1. FC Köln', '1-1', '2023-09-23'),
(8, 'W', 'FC Augsburg', '2-0', '2023-10-01'),
(9, 'L', 'SV Werder Bremen', '0-1', '2023-10-14'),
(10, 'W', 'SC Freiburg', '4-1', '2023-10-21'),
(11, 'W', 'FC Schalke 04', '3-0', '2023-10-28'),
(12, 'D', '1. FSV Mainz 05', '2-2', '2023-11-04'),
(13, 'L', 'TSG 1899 Hoffenheim', '0-2', '2023-11-18'),
(14, 'W', 'Hertha BSC', '2-1', '2023-11-25'),
(15, 'W', 'Arminia Bielefeld', '3-0', '2023-12-02'),
(16, 'W', 'VfB Stuttgart', '2-0', '2023-12-09'),
(17, 'D', 'Hannover 96', '1-1', '2023-12-16'),
(18, '', 'FC Nürnberg', '', '2024-01-06');
create table playersell(
psid INT IDENTITY(1,1) PRIMARY KEY,
pid int,
fname varchar(50),
lname varchar(50),
amount INT,
created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);
create table playersigning(
psid INT IDENTITY(1,1) PRIMARY KEY,
pid int REFERENCES playername(pid),
fname varchar(50),
lname varchar(50),
amount INT,
created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);
CREATE TABLE executive (
  username VARCHAR(50) primary key not null,
  password VARCHAR(50) not null
);
CREATE TABLE analyst (
  username VARCHAR(50) primary key not null,
  password VARCHAR(50) not null
);
insert into  executive values ('abdulsamad','imrankhan');
insert into  executive values ('hammad','imrankhan');
insert into  analyst values ('abdullah','imrankhan');
insert into  analyst values ('raheem','imrankhan');



go
CREATE PROCEDURE loginanal
@id varchar(50),
@pass varchar(50),
@flag BIT OUT
AS
BEGIN
SET @flag = (SELECT COUNT(1) FROM analyst WHERE username = @id AND password=@pass)
end
