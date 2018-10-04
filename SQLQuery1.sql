create table Cliente(
IdCliente       integer           identity(1,1),
Nome            nvarchar(50)      not null,
Email           nvarchar(50)      not null,
primary key(IdCliente))

go