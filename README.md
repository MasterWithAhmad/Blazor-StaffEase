# Blazor StaffEase  

[![Blazor](https://img.shields.io/badge/Blazor-.NET%20WebAssembly-blueviolet)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)  


## Overview  
Blazor StaffEase is a modern web application built using Blazor WebAssembly. It provides an efficient platform for managing employee records, including:  
- **CRUD Operations**: Create, read, update, and delete employees.  
- **Search Functionality**: Easily search employees by name, email, or department.  
- **Department Management**: Supports displaying associated departments for employees.  

This project demonstrates clean code practices, service-oriented architecture, and reusable components in Blazor.  

## Features  
- **QuickGrid Integration** for rendering data in a tabular format.  
- **Dependency Injection** for managing services and data.  
- **EF Core** for database interactions.  
- **Responsive Design** with Tailwind CSS for styling.  

## Technologies Used  
- **Blazor WebAssembly**  
- **.NET 8.0**  
- **Entity Framework Core**  
- **Microsoft SQL Server**  
- **Tailwind CSS**  

## Getting Started  

### Prerequisites  
- Install [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).  
- Install [Visual Studio 2022](https://visualstudio.microsoft.com/) with Blazor and EF Core workloads.  
- Install SQL Server and create a database.  

### Running the Application  
1. Clone the repository:  
   ```bash  
   git clone https://github.com/MasterWithAhmad/Blazor-StaffEase.git
   ```

2. Navigate to the project directory:
```
cd StaffEase
```

3. Restore the dependencies:
```
dotnet restore
```

4. Apply migrations and update the database:
```
dotnet ef database update
```

5. Run the application:
```
dotnet run
```

6. Open your browser and navigate to https://localhost:7132.



## Contributing

Contributions are welcome! Please fork this repository and create a pull request with your proposed changes.

## License

This project is licensed under the MIT License.

## Author

Ahmed Ibrahim Ahmed

For questions, reach out via the repository's issue tracker.
