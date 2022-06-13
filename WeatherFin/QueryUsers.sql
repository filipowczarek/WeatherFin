INSERT INTO AspNetRoles(Id, Name) values (1, 'Admin')
INSERT INTO AspNetRoles(Id, Name) values (2, 'User');

SELECT * FROM AspNetUsers;
SELECT * FROM AspNetUserRoles;

INSERT INTO AspNetUserRoles(UserId,RoleId) values('ba642c05-d4d8-4f99-96f7-f981e39f911e',1);