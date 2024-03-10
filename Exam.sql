create table Tasks
(
	TaskID serial primary key,
	ProjectID int references Projects(ProjectID),
	Title varchar,
	Description varchar,
	AssignedTo int references Employees(EmployeeID),
	DueDate date,
	Status varchar
);

create table Projects
(
	ProjectID serial primary key,
	Name varchar,
	Description varchar,
	StartDate date,
	EndDate date
);

create table Employees
(
	EmployeeID serial primary key,
	Name varchar,
	Department varchar
);

select p.ProjectID,p.Name, p.Description, p.StartDate, p.EndDate, Sum(t.TaskID) from Tasks as t
join Projects as p on t.ProjectID = p.ProjectID
group by p.ProjectID


select e.EmployeeID,e.Name,e.Department from Tasks as t
join Employees as e on t.AssignedTo = e.EmployeeID
join Projects as p on t.ProjectID = p.ProjectID
where p.ProjectID = 1

select * from Tasks 
where ProjectID = @projectId






