DROP TABLE borrow;
DROP TABLE book;

CREATE TABLE book
   (bno	char(10), 
   category	varchar(20),
   title	varchar(30),
   press	varchar(30),
   year	int,
   author	varchar(20),
   price	decimal(7,2),
   total	int,
   stock	int,
   primary key(bno));

CREATE TABLE card
  (cno char(7),
  name varchar(10),
  department varchar(40),
  type char(1),
  primary key(cno),
  check(type in('T','S')));

CREATE TABLE borrow
  (cno char(7),
  bno  char(8),
  borrow_date int,
  return_date int,
  primary key(cno,bno,borrow_date),
  foreign key (cno) references card(cno),
  foreign key (bno) references book(bno));