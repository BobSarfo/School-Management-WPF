create table users(
 Id UniqueIdentifier primary key default newid(),
 username nvarchar(50) unique not null,
 [password] nvarchar(50) unique not null,
 firstname nvarchar(50) unique not null,
 lastname nvarchar(50) unique not null,
 email nvarchar(50) unique not null,
)

insert into [users] values (NEWID(),'bob','bob','Bob','Sagoe','robertsarfo@gmail.com')
insert into users values (NEWID(),'kweku','kweku','Kweku','Mensah','kwekumensah@gmail.com')
insert into users values (NEWID(),'kwame','kwame','Kwame','Kese','kwamekese@gmail.com')

select * from users