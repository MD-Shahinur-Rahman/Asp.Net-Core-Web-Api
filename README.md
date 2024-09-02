# Asp.Net Core Web Api Master Detail Crud
## Overview Shortly
### This Employee Management System is using ASP.NET Core Api Master Details Crud , And This is Code First approach. The system provides a seamless interface for managing Employee related data, including Employee, Experience


### Features
#### Employee Management: Create, update, delete, and Assign Employees  details is Experience efficiently.
#### Image Handling: Upload and manage images for employee  user profiles.

Technologies Used
ASP.NET Core Api .Net 8: For creating a scalable and maintainable web Api.
SQL Server: As the database solution to store and manage api data Use Local Database.
### System Overview in Images
<span>Below are some screenshots of the system:
</span>
## This is Post Image
![post](https://github.com/user-attachments/assets/11abdcc9-88bd-4f9e-b766-31977da198c7)

## This is Get Image
![get](https://github.com/user-attachments/assets/5b753be0-0c66-44c2-a994-43bc7413231e)

## This is DELETE Image



## Here Is GET, POST, PUT , DELETE COMMAND
GET all
http://localhost:5108/api/Employees

POST
http://localhost:5108/api/Employees
---------------------------------------------------------------------------------
[
       {
      
        "EmployeeName": "Shisir"
        "IsActive": false,
        "Email": "shsir@gmail.com",
        "JoinDate": "2020-01-11",
        "ImageName": "shishir.jpg",
        "ImgFile": "/Upload/shishir.jpg",   Select image
        "Experiences": [
            {
                "ExperienceId": 0,
                "EmployeeId": 0,
                "Title": "Software Developer",
                "Duration": 24
            },
            {
                "ExperienceId": 0,
                "EmployeeId": 0,
                "Title": "Senior Developer",
                "Duration": 12
            }
        ]
    },
]
-----------------------------------------------------------------------------------

GET by Id
http://localhost:5108/api/Employees/1


PUT by Id
http://localhost:5108/api/Employees/1
----------------------------------------------------------------------------------
[
    {
      
        "EmployeeName": "Shisir ahamed"
        "IsActive": false,
        "Email": "shishir@gmail.com",
        "JoinDate": "2020-01-11",
        "ImageName": "shishir.jpg",
        "ImgFile": "/Upload/shishir.jpg",   (Select Image)
        "Experiences": [
            {
                "ExperienceId": 0,
                "EmployeeId": 0,
                "Title": "Software Developer",
                "Duration": 30
            },
            {
                "ExperienceId": 0,
                "EmployeeId": 0,
                "Title": "junior developer",
                "Duration": 40
            }
        ]
    },
]

-----------------------------------------------------------------------

DELETE By id
http://localhost:5108/api/Employees/1


