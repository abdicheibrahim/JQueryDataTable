# ASP.NET Core DataTables (Server-Side Processing)

This project demonstrates how to integrate **jQuery DataTables** with **ASP.NET Core (Web API)** using **Server-Side Processing (SSR)**.  
It includes searching, sorting, and pagination directly from the server using **Entity Framework Core**.

---

## 🚀 Features
- ASP.NET Core 8 Web API  
- Entity Framework Core  
- Clean architecture with **Service Layer**  
- Server-Side Processing (Search, Sort, Pagination)  
- Bootstrap 5 + DataTables integration  
- Example CRUD actions (Delete button included in table)  

---

## 🛠️ Technologies Used
- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server / LocalDB** (configurable in `appsettings.json`)
- **jQuery DataTables** (v1.13)
- **Bootstrap 5**

---

## ⚙️ How to Run

### 1. Clone the repository
```bash
git clone https://github.com/<your-username>/<your-repo-name>.git
cd <your-repo-name>
2. Configure Database
Update the connection string inside appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DataTableDemo;Trusted_Connection=True;MultipleActiveResultSets=true"
}
3. Apply Migrations
bash
Copy
Edit
dotnet ef database update
4. Run the Application
bash
Copy
Edit
dotnet run
Then open in browser: http://localhost:5000

📸 Screenshots
DataTable with Server-Side Processing

🔮 Future Improvements
Add Create/Edit/Delete functionality with AJAX

Implement Custom ModelBinder for DataTables request binding

Add more advanced filters (e.g., date range, status)

🤝 Contributing
Pull requests are welcome! If you want to improve this project, feel free to fork and submit changes.

📜 License
This project is licensed under the MIT License - see the LICENSE file for details.
