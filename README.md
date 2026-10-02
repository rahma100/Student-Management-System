EduCore – Student Management System

A simple and practical Console-based Student Management System built with C#, .NET, and Entity Framework 6 using the Database First approach.

The project demonstrates how to build a CRUD-based application that manages students, courses, departments, and enrollments while working with relational data using Entity Framework.

Features
Create new records
View existing records
Update records
Delete records
Retrieve related data using Entity Framework
Work with relationships between Students, Courses, Departments, and Enrollments
Query data using LINQ


Technologies
Technology	
C#	
.NET	
Entity Framework 6
SQL Server	
LINQ	 
Database First

Database Structure

The system is built around four main entities:

👨‍🎓 Student
📚 Course
🏢 Department
📝 Enrollment
Entity Relationships
Student
   │
   │ 1
   ▼
Enrollment
   │
   │ *
   ▼
Course
   │
   │ *
   ▼
Department

An Enrollment connects a student with a course and stores information such as the student's grade.

🔄 CRUD Operations

The project demonstrates the four fundamental database operations:

➕ Create

Add new students, courses, departments, or enrollment records.

📖 Read

Retrieve and display data from the database, including related entities.

✏️ Update

Modify existing records and save the changes to SQL Server.

🗑️ Delete

Remove records from the database.

*Learning Objectives

Through this project, I practiced:

Building CRUD operations
Working with SQL Server databases
Using Entity Framework 6
Applying the Database First approach
Writing LINQ queries
Working with Navigation Properties
Handling relationships between database entities
Retrieving related data using Include()
📌 Project Purpose

The main purpose of EduCore is to practice backend development concepts and understand how a .NET application interacts with a relational database using Entity Framework.

