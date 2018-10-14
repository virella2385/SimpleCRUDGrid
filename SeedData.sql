insert into customers values ('Coca Cola'), ('Wawa'), ('7-Eleven'), ('Taco Bell')
go
insert into projects values ('web portal', 1), ('POS system', 2), ('POS system redesign', 3), ('mobile ordering feature', 4)
go
insert into expenses values ('dev tools', getdate(), 2000.89, 'Visual Studio licenses', 1), ('dev hiring', getdate(), 50000.99, 'New devs for project', 2),
('dev tools', getdate(), 3867.88, 'Visual studio, sql server licenses', 3)