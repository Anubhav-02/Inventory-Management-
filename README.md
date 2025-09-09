# 📦 Product Inventory API (Backend Only)

This project is a **backend application** (no user interface yet) that helps manage products in an **Inventory System**.  
It is built using **C#** and **.NET Core** with a lightweight database (**SQLite**).  

You can use this backend to:  
- ➕ Add new products  
- 📋 View all products  
- 🔍 Search & filter products  
- ✏️ Update product details  
- ❌ Delete products
- ⚠️ Check for **low stock products** (less than or equal to 5 items left)  

---

## 🛠 What Technologies Are Used?

- **C#** → A programming language made by Microsoft.  
- **.NET Core** → A free framework to build applications (the engine running this backend).  
- **SQLite** → A small database saved as a file (used here to store products).  
- **Postman** → A tool that shows all available APIs in a simple webpage, so you can test them without coding.  

---

## 📥 Installation Guide (Step by Step)

Follow these steps carefully (**no coding knowledge required**):

### 1. Install Required Tools
- Install **.NET 8 SDK (or latest)** → [Download here](https://dotnet.microsoft.com/en-us/download)  
- Install **Git** (to download this project) → [Download here](https://git-scm.com/downloads)  
- *(Optional)* Install **Visual Studio Community** (to open and explore the project) → [Download here](https://visualstudio.microsoft.com/vs/community/)  

---

### 2. Download This Project

You can get the project in two ways:  

**Option A: Download ZIP**  
- Click the green **Code** button on GitHub → "Download ZIP"  
- Extract the ZIP file  

**Option B: Clone with Git** (if Git is installed)  
```bash
git clone https://github.com/Anubhav-02/Inventory-Management-.git
```

---

## ▶️ Running the Backend

1. Open a terminal (**Command Prompt** or **PowerShell**).  
2. Navigate to the project folder (where `ProductInventoryApi.csproj` exists). Example:  
   ```bash
   cd Inventory-Management-/ProductInventoryApi
   ```
3. Run the project with:  
   ```bash
   dotnet run
   ```
4. You should see something like:  
   ```
   Now listening on: http://localhost:5000
   Application started. Press Ctrl+C to shut down.
   ```

✅ This means your backend is running on **http://localhost:5000**

---

## 🌐 Collection of APIs (Postman) 
[Postamn Collection URL](https://.postman.co/workspace/My-Workspace~9106ab3a-a3d7-4634-8f0d-d107dbaed5b7/request/42616923-e4a60cf9-e549-444e-a176-a4f54cf72a04?action=share&creator=42616923&ctx=documentation&active-environment=42616923-5c257926-88ba-411f-ae2f-d1886a17c557)
You will see a webpage with the following APIs:  
   - **POST /api/products** → Add a new product  
   - **GET /api/products** → View all products  
   - **GET /api/products/{id}** → View product by ID  
   - **PUT /api/products/{id}** → Update a product  
   - **DELETE /api/products/{id}** → Soft delete (mark inactive)  
   - **GET /api/products/lowstock** → Check products with stock < 5  

3. Just click any API, enter the values, and press **Execute**.  

💡 Example:  
- To add a product → Click **POST /api/products**, then fill details like `Name`, `Price`, `Category` → Execute → ✅ Done!  

---

## 📂 Database Info

- The project uses a **SQLite database file** called `products.db`.  
- You don’t need to install anything extra. It’s already included.  
- If you delete `products.db`, a new one will be created automatically.  

---

## ❓ FAQ (For Non-Coders)

**Q: What is .NET?**  
A free framework by Microsoft that lets us build apps (like the engine that runs this project).  

**Q: Do I need to code anything?**  
No. You just need to run commands like `dotnet run`. Swagger will give you buttons to click.  

**Q: Where do I see my products?**  
Right now, only in **Swagger** or **Postman** (API testing tools). A separate frontend (website) can be built later.  

---

## 👨‍💻 Author
Made by **Anubhav Kushwaha**
