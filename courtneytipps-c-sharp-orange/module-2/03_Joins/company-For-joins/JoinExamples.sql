-- firstname, lastname and title of all employees with a position

SELECT Employee.firstname, Employee.lastname, Position.title
FROM Employee
JOIN Position ON employee.position = position.id

-- title and department name of all positions assigned to an department

SELECT Position.title, Department.name
FROM Position 
JOIN Department ON Position.id = Department.id


-- firstname, lastname, title, and department name of all assigned employees

SELECT Employee.firstname, Employee.lastname, Department.name department
FROM Employee
JOIN Position ON employee.position = position.id
JOIN Department ON position.department = Department.id

-- firstname and lastname of all employees (assigned or not), include title for those that are assigned

SELECT Employee.firstname, Employee.lastname, Position.title
FROM Employee
LEFT JOIN Position ON employee.position = position.id


-- all position titles (assigned or not) and all employees assigned to a position (firstname and lastname)

SELECT Position.title, Employee.firstname, Employee.lastname
FROM Employee
RIGHT JOIN Position ON employee.position = position.id

-- above, with the opposite outer join (left or right)

SELECT Position.title, Employee.firstname, Employee.lastname
FROM Employee
LEFT JOIN Position ON employee.position = position.id


-- show all employees, asigned or not (firstname and lastname) and all position titles, 
-- asigned or not. Show matches where they exist (FULL OUTER JOIN)

SELECT Employee.firstname, Employee.lastname, Position.title
FROM Employee
FULL JOIN Position ON employee.position = position.id


-- show all possible combinations of employees (firstname and lastname) and position titles, 
-- whether the combinations exist or not (CROSS JOIN)
SELECT Employee.firstname, Employee.lastname, Position.title
FROM Employee
CROSS JOIN Position




--
--
--








SELECT e.firstname, e.lastname, p.title
FROM employee e
INNER JOIN position p on e.position = p.id
-- JOIN position p on e.position = p.id

SELECT p.title, d.name
FROM position p 
INNER JOIN department d on p.department = d.id

SELECT e.firstname, e.lastname, p.title, d.name
FROM employee e
INNER JOIN position p on e.position = p.id
INNER JOIN department d on p.department = d.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
LEFT OUTER JOIN position p on e.position = p.id
--LEFT JOIN position p on e.position = p.id

SELECT e.firstname, e.lastname, p.title
FROM employee e
RIGHT OUTER JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM position p 
LEFT OUTER JOIN employee e on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
FULL OUTER JOIN position p on e.position = p.id
--FULL JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
CROSS JOIN position p 



