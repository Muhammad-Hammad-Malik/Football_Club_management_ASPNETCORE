
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
