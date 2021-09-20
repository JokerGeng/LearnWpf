using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDatabase
{
    public class StoreDB
    {
        public Product GetProduct(int id)
        {
            DataSet ds = StoreDbDataSet.ReadDataSet();
            DataRow row = ds.Tables["Products"].Select("ProductID = " + id.ToString())[0];
            Product product = new Product((string)row["ModelNumber"],
                    (string)row["ModelName"], (decimal)row["UnitCost"],
                    (string)row["Description"], (int)row["CategoryID"],
                    (string)row["CategoryName"], (string)row["ProductImage"]);
            return product;
        }

        public ICollection<Product> GetProducts()
        {
            DataSet ds = StoreDbDataSet.ReadDataSet();

            ObservableCollection<Product> products = new ObservableCollection<Product>();
            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                Product product = new Product((string)row["ModelNumber"],
                   (string)row["ModelName"], (decimal)row["UnitCost"],
                   (string)row["Description"], (int)row["CategoryID"],
                   (string)row["CategoryName"], (string)row["ProductImage"]);
                products.Add(product);
            }
            return products;
        }

        public ICollection<Category> GetCategories()
        {
            DataSet ds = StoreDbDataSet.ReadDataSet();

            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (DataRow categoryRow in ds.Tables["Categories"].Rows)
            {
                categories.Add(new Category(categoryRow["CategoryName"].ToString(), (int)categoryRow["CategoryID"]));
            }
            return categories;
        }
    }
}
