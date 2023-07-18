# HR Management System

This Readme file provides an overview of the HR System, a web application built using ASP.NET Core 7. It outlines the features and functionalities of the system, guiding developers and users on how to use and interact with the application effectively.

## Table of Contents

1. [Introduction](#introduction)
2. [Installation](#installation)
3. [Features](#features)
4. [Technologies Used](#technologies-used)
5. [Login](#login)
6. [User Groups and Permissions](#user-groups-and-permissions)
7. [User Management](#user-management)
8. [Employee Data Entry](#employee-data-entry)
9. [General Settings](#general-settings)
10. [Public Holidays](#public-holidays)
11. [Employee Attendance Tracking](#employee-attendance-tracking)
12. [Employee Salary Reports](#employee-salary-reports)

## Introduction

The HR System is a comprehensive web application designed to streamline HR processes and improve efficiency within an organization. It provides HR users with a user-friendly interface to manage various aspects of HR operations, such as user management, employee data entry, attendance tracking, salary reporting, and more.

## Installation

To install and run the HR System on your local machine, follow these steps:

1. Clone the project repository from [GitHub](https://github.com/HR-Graduation-Project/HR_GraduationProject.git).
2. Ensure that you have ASP.NET Core 7 installed on your machine.
3. Open the project in your preferred integrated development environment (IDE), such as Visual Studio or Visual Studio Code.
4. Build the project to restore NuGet packages and compile the source code.
5. Configure the database connection string in the appsettings.json file.
6. Run the database migrations to create the required database schema.
7. Start the application, and it will launch in your default web browser.

## Features

The HR System includes the following key features:

- **Login:** Secure authentication for HR users and other system users.
- **User Groups and Permissions:** HR users can create user groups and define different permissions for each group.
- **User Management:** Add, edit, and delete user accounts, including information such as full name, username, email, password, and user group.
- **Employee Data Entry:** HR users can add personal and work-related information for each employee, including mandatory fields such as name, address, phone number, date of birth, gender, national ID, nationality, contract date, salary, attendance time, and departure time.
- **General Settings:** HR users can configure overtime and deduction rules, as well as set weekly holidays for employees.
- **Public Holidays:** HR users can add official public holidays with names and dates.
- **Employee Attendance Tracking:** HR users can view and manage employee attendance records, manually add or import attendance and departure times, search records by various criteria, and edit or delete attendance records.
- **Employee Salary Reports:** Generate detailed salary reports for HR users, including employee details, base salary, attendance and absence days, overtime hours, deduction hours, total overtime, total deduction, and net salary. HR users can print individual salary slips for employees at the end of each month.

## Technologies Used

The HR System utilizes the following technologies and frameworks:

- **ASP.NET Core 7:** Web application framework for building scalable and secure applications.
- **C#:** Modern, object-oriented programming language for the .NET ecosystem.
- **Entity Framework Core:** Object-relational mapping (ORM) framework for data access.
- **HTML5 & CSS3:** Markup and styling languages for creating a modern user interface.
- **JavaScript & jQuery:** Enhances interactivity and dynamic functionality in the user interface.
- **Bootstrap 5:** Front-end framework for responsive web design.
- **SQL Server:** Relational database management system for data storage and retrieval.
- **Git:** Version control system for source code management.
- **Visual Studio 2022:** Integrated development environment (IDE) for development and debugging.

By leveraging these technologies, the HR System delivers a professional and efficient HR management solution, empowering organizations to streamline their HR processes, enhance productivity, and improve overall efficiency.

## Login

The login feature provides secure authentication for HR users and other system users. The login page allows HR users to enter their username and password to authenticate their access. For other users, the system supports login using either a username or an email address along with a password.

## User Groups and Permissions

HR users have the ability to create user groups and define different permissions for each group. The application includes a user interface that enables HR users to enter the group name and select the associated permissions. These permissions determine the operations and screens accessible to users in a specific group.

## User Management

The user management functionality allows HR users to perform various user-related tasks. It includes features to add new users, edit existing user data, and delete user accounts. When adding a new user, the system prompts for information such as full name, username, email, password, and user group selection.

## Employee Data Entry

The employee data entry feature allows HR users to add employee information to the system. HR users can log in and input both personal and work-related data for each employee. The personal data section includes fields such as name, address, phone number, date of birth, gender, national ID, and nationality. The work-related data section includes fields such as contract date, salary, attendance time, and departure time. All employee data fields are mandatory to ensure accurate record keeping.

## General Settings

The general settings page enables HR users to configure important settings within the HR System. HR users can define overtime and deduction rules by specifying the amount to be added for each extra hour worked and the amount to be deducted for each late hour. Additionally, HR users can set the weekly holidays, specifying the days off given to employees. These settings affect attendance tracking, salary calculation, and absence reporting within the system.

## Public Holidays

The public holidays feature allows HR users to add official public holidays to the HR System. HR users can enter the name and date of each holiday for the year, ensuring accurate holiday tracking within the organization.

## Employee Attendance Tracking

The employee attendance tracking page provides HR users with a centralized view of employee attendance records. HR users can manually add attendance and departure times or import them from an Excel sheet. The system also includes search functionality, allowing HR users to find attendance records by employee name, department, specific date, or date range. HR users can edit or delete attendance records as needed.

## Employee Salary Reports

The employee salary reports feature generates detailed salary reports for HR users. The reports display comprehensive employee salary information and include filtering options to view reports for specific employees or specific months and years. The reports contain employee details such as name, department, and base salary, along with calculated attendance and absence days, overtime hours, deduction hours, total overtime, total deduction, and net salary for each employee. To facilitate record-keeping, HR users can also print individual salary slips for employees at the end of each month.

---


https://github.com/HR-Graduation-Project/HR_GraduationProject/assets/53530825/1da23c99-d7f1-4b4b-bece-3fc799a95501

