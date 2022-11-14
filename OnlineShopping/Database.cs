using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineShopping
{
    internal class Database
    {
        static string connectionString;

        static Database()
        {
            ConnectionSql();

        }
        static void ConnectionSql()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "OnlineShopping";
            builder.DataSource = @"localhost";
            builder.IntegratedSecurity = true;
            connectionString = builder.ConnectionString;
        }
        internal static string LoginUser(string username, string password)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            string query = "selectUser";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            var read = command.ExecuteReader();
            read.Read();
            string mesazhi = read[0].ToString();

            return mesazhi;
        }
        internal static void RegisterUser(string username,string password)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "regUser";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            
            command.ExecuteNonQuery();

        }
        public static List<UserT> Users()
        {
            var list = new List<UserT>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "users";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserT users = new UserT();
                users.Username = reader["Username"].ToString();
               
               

                list.Add(users);

            }

            return list;

        }

        public static List<Product> Products()
        {
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectProduct";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
       
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static List<Product> Products(string name,string category) 
        { 
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "ListaEProduct";
            SqlCommand command = new SqlCommand(query,sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name",name);
            command.Parameters.AddWithValue("@category", category);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static void AddProduct(string name,string category,string description, decimal price) 
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "addProduct";
            SqlCommand command = new SqlCommand(query,sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name",name);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@price", price);

            command.ExecuteNonQuery();
            

        }
        public static void EditProduct(int id,string name, string category, string description, decimal price)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "editProduct";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@price", price);


            command.ExecuteNonQuery();
            


        }
        public static void DeleteProduct(int id) {

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "deleteProduct";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            

            command.ExecuteNonQuery();

        }
        public static List<Category> Categories() 
        {
            var list = new List<Category>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectCategory";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            var reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                Category category = new Category();
                category.Id = int.Parse(reader["Id"].ToString());
                category.CategoryName = reader["CategoryName"].ToString();
                list.Add(category);
            }

            return list;
        }
        public static void Order(string username,string email,string nrphone,string address,string name,string category, DateTimePicker date,decimal price)
        {

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "orderProduct";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@nrphone", nrphone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@date", date.Value);
            command.Parameters.AddWithValue("@price", price);

            command.ExecuteNonQuery();

        }
        public static List<Orders> showOrder()
        {
            var list = new List<Orders>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "select Category , Sum(Price) as Totali from Orders group by Category";
            SqlCommand command = new SqlCommand(query, sql);
            //command.CommandType = CommandType.StoredProcedure;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Orders category = new Orders();


              
                category.Category=  reader["Category"].ToString();
               category.Price = decimal.Parse(reader["Totali"].ToString());
                list.Add(category);
            }

            return list;


        }
        public static void ShtoCategory(string category) {

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "shtoCategory";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
           
            command.Parameters.AddWithValue("@categoryname", category);
            
            command.ExecuteNonQuery();


        }
        public static void EditCategory(int id,string category)
        {

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "editCategory";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@categoryname", category);

            command.ExecuteNonQuery();


        }
        public static void DeleteCategory(int id)
        {

            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "deleteCategory";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();


        }
        public static List<Product> ProductsComputer()
        {
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectProductComputer";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static List<Product> ProductsLaptop()
        {
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectProductLaptop";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static List<Product> ProductsTv()
        {
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectProductTv";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static List<Product> ProductsAccessories()
        {
            var list = new List<Product>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "selectProductAccessories";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = int.Parse(reader["Id"].ToString());
                product.Name = reader["Name"].ToString();
                product.Category = new Category();
                product.Category.CategoryName = reader["Category"].ToString();
                product.Description = reader["Description"].ToString();
                product.Price = decimal.Parse(reader["Price"].ToString());

                list.Add(product);

            }

            return list;

        }
        public static List<Orders> showOrderAll()
        {
            var list = new List<Orders>();
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            var query = "orderSelect";
            SqlCommand command = new SqlCommand(query, sql);
            command.CommandType = CommandType.StoredProcedure;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Orders order = new Orders();
                //order.Id = Convert.ToInt32(reader["Id"].ToString());
                order.Username = reader["Username"].ToString();
                order.Email = reader["Email"].ToString();
                order.NrPhone = reader["NrPhone"].ToString();
                order.Address = reader["Address"].ToString();
                order.Name = reader["Name"].ToString();
                order.Category = reader["Category"].ToString();
                
                order.Price = decimal.Parse(reader["Price"].ToString());
                list.Add(order);
            }

            return list;


        }


    }
}
