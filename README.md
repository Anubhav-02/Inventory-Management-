#📦 Product Inventory API (Backend Only)

This project is a backend application (no user interface yet) that helps manage products in an Inventory System.
It is built using C# and .NET Core with a lightweight database (SQLite).

You can use this backend to:

➕ Add new products

📋 View all products

🔍 Search & filter products

✏️ Update product details

❌ Delete products (soft delete)

⚠️ Check for low stock products (less than 5 items left)

🛠 What Technologies Are Used?

C# → A programming language made by Microsoft.

.NET Core → A free framework to build applications (the engine running this backend).

SQLite → A small database saved as a file (used here to store products).

Swagger → A tool that shows all available APIs in a simple webpage, so you can test them without coding.

📥 Installation Guide (Step by Step)

Follow these steps carefully (no coding knowledge required):

1. Install Required Tools

Install .NET 8 SDK (or latest) → Download here

Install Git (to download this project) → Download here

(Optional) Install Visual Studio Community (if you want to open the project in an editor) → Download here

2. Download This Project

You can get the project in two ways:

Option A: Download ZIP

Click the green Code button on GitHub → "Download ZIP"

Extract the ZIP file

Option B: Clone with Git (if Git is installed)

git clone https://github.com/Anubhav-02/Inventory-Management-.git

▶️ Running the Backend

Open a terminal (Command Prompt or PowerShell).

Go to the project folder (where ProductInventoryApi.csproj exists). Example:

cd Inventory-Management-/ProductInventoryApi


Run the project with:

dotnet run


You should see something like:

Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.


✅ This means your backend is running on http://localhost:5000

🌐 Using the API (No Coding Needed)

Open your browser and go to:
👉 http://localhost:5000/swagger

You will see a webpage like this:

POST /api/products → Add a new product

GET /api/products → View all products

GET /api/products/{id} → View product by ID

PUT /api/products/{id} → Update a product

DELETE /api/products/{id} → Soft delete (mark inactive)

GET /api/products/lowstock → Check products with stock < 5

Just click any API, enter the values, and press Execute.

Example:

To add a product → Click POST /api/products, then fill details like Name, Price, Category → Execute → ✅ Done!

📂 Database Info

The project uses a SQLite database file called products.db.

You don’t need to install anything extra. It’s already included.

If you delete products.db, a new one will be created automatically.

❓ FAQ (For Non-Coders)

Q: What is .NET?
A free framework by Microsoft that lets us build apps (like engines for running the code).

Q: Do I need to code anything?
No. You just need to run commands like dotnet run. Swagger will give you buttons to click.

Q: Where do I see my products?
Right now, only in Swagger or Postman (API testing tools). A separate frontend (website) can be built later.

👨‍💻 Author

Made by Anubhav Kushwaha
