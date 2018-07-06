drop database if exists EventDB;

create database if not exists EventDB char set 'utf8';

use EventDB;



create table if not exists UserDB(
    user_name varchar(50) primary key not null,
    user_password varchar(50) not null,
    name_user varchar(100) not null,
    age int not null,
    type_account int,
    job varchar(50),
    address varchar(100),
    email varchar(50),
    phone_number int	
);

create table if not exists EventDB(
	event_id varchar(50) primary key,
    event_name varchar(100) not null,
    description varchar(100),
    address varchar(100),			
    item datetime
);

	

create table if not exists EventDetailsDB(
	username varchar(50) not null,
    event_id varchar(50) not null,
    statusEvent varchar(50) not null,
    constraint pk_EventDetails primary key(username, event_id),
    constraint fk_EventDetails_Users foreign key(username) references UserDB(user_name),
    constraint fk_EventDetails_Events foreign key(event_id) references EventDB(event_id)
    
);
delimiter $$
create procedure sp_createEvent(IN event_Name varchar(100), IN Address varchar(200), OUT eventId int)
begin
	insert into EventDB(event_name, address) values (event_Name, Address); 
    select max(event_id) into eventId from EventDB;
end $$
delimiter ;

drop user if exists 'EventUser'@'localhost';
create user if not exists 'EventUser'@'localhost' identified by '123456789';
    grant all on UserDB to 'EventUser'@'localhost';
    grant all on EventDB to 'EventUser'@'localhost';
    grant all on EventDetailsDB to 'EventUser'@'localhost';
    
