INSERT INTO dbo.question
(Id, Title, Description, Status, `Order`, `By`, `Date`)
VALUES('804405c4-1889-4145-9936-4de087e74496', "Personal Information", NULL, "ACTIVE", 0, "Admin", curdate());

INSERT INTO dbo.question
(Id, Title, Description, Status, `Order`, `By`, `Date`)
VALUES('cb0ea537-9100-479d-93d4-1739d80f4610', "Address", NULL, "ACTIVE", 1, "Admin", curdate());

-

INSERT INTO dbo.subquestion
(Id, QuestionId, ChoiseId, Value, Description, Status, `Order`, `Type`, `By`, `Date`)
VALUES('2cf4961d-5567-4af3-b99c-87a4ab0beed2', '804405c4-1889-4145-9936-4de087e74496', '40730c9d-181f-4c7d-b91e-60de1c6aae9c', "Title: (Mr. Ms. or Mrs.)" , NULL, "ACTIVE", 0, "CHOISE", "Admin", curdate());

INSERT INTO dbo.subquestion
(Id, QuestionId, ChoiseId, Value, Description, Status, `Order`, `Type`, `By`, `Date`)
VALUES('80f4648e-fa50-4f68-bdcc-cec0187b7f84', '804405c4-1889-4145-9936-4de087e74496', null, "First name:", NULL, "ACTIVE" , 1, "WRITTEN", "Admin", curdate());


-

INSERT INTO dbo.choise
(Id, Name, Description, Status, `By`, `Date`)
VALUES('40730c9d-181f-4c7d-b91e-60de1c6aae9c', "Gender",NULL, "ACTIVE", "Admin",  curdate());


--

INSERT INTO dbo.subchoise
(Id, ChoiseId, Title, Description, `Order`, AllowSelect)
VALUES('a610ba01-180e-4954-bf30-8b76752185a5', '40730c9d-181f-4c7d-b91e-60de1c6aae9c', "Mr.", NULL, 0, 1);

INSERT INTO dbo.subchoise
(Id, ChoiseId, Title, Description, `Order`, AllowSelect)
VALUES('65c28adf-d214-42b6-a49a-e598a2ab563c', '40730c9d-181f-4c7d-b91e-60de1c6aae9c', "Ms.", NULL, 1, 1);

INSERT INTO dbo.subchoise
(Id, ChoiseId, Title, Description, `Order`, AllowSelect)
VALUES('ba6ecc00-7990-46ae-9cd1-f83817de0df3', '40730c9d-181f-4c7d-b91e-60de1c6aae9c', "Mrs.", NULL, 2, 1);