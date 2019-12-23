create database ContactDetails

use ContactDetails

create table Contacts(
Id int not null primary key,
FirstName varchar(30),
LastName varchar(30),
Email varchar(60),
PhoneNumber varchar(10),
ContactStatus varchar(10))

insert into Contacts values(1,'Shalu','Priya','shalupriya059@gmail.com','8668525993','Active')
insert into Contacts values(2,'Abhishek','Anand','abhishekanand@gmail.com','8662545796','Active')
insert into Contacts values(3,'Rashmi','Gupta','rashmigupta059@gmail.com','7668512398','Inactive')
insert into Contacts values(4,'Nikhil','Ingale','nikhilingale059@gmail.com','9558525856','Active')

select * from Contacts