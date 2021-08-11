using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer
{
    class Program
    {
        static void Main(string[] args)
        {
            var Categories = new Category[]
            {
                new Category { CategoryID = 1, CategoryName = "Laptop"},
                new Category { CategoryID = 2, CategoryName = "PC"}
            };

            var Models = new Model[]
            {
                new Model { ModelID = 1, ModelName = "Computer Laptop"},
                new Model { ModelID = 2, ModelName = "Computer Pc"},
            };

            var Products = new Product[]
           {
                new Product { ProductID = 1, ProductName = "Dell Laptop", ProductNumber = 1564, Color = "Blue", FixedPrice = 100000, CategoryID = 1, ModelID = 1},
                new Product { ProductID = 2, ProductName = "Intel Pc", ProductNumber = 1983, Color = "Gray", FixedPrice = 80000, CategoryID = 2, ModelID = 2},
                new Product { ProductID = 3, ProductName = "Samsung Laptop", ProductNumber = 1256, Color = "White", FixedPrice = 900000, CategoryID = 1, ModelID = 1},
                new Product { ProductID = 4, ProductName = "Samsung Pc", ProductNumber = 1223, Color = "Black", FixedPrice = 60000, CategoryID = 2, ModelID = 2},
                new Product { ProductID = 5, ProductName = "Dell Laptop", ProductNumber = 1636, Color = "Orange", FixedPrice = 170000, CategoryID = 1, ModelID = 1},
                new Product { ProductID = 6, ProductName = "Dell Pc", ProductNumber = 1167, Color = "Red", FixedPrice = 80000, CategoryID = 2, ModelID = 2},
                new Product { ProductID = 7, ProductName = "Asus Laptop", ProductNumber = 1941, Color = "White", FixedPrice = 50000, CategoryID = 1, ModelID = 1},
                new Product { ProductID = 8, ProductName = "Asus Pc", ProductNumber = 1042, Color = "Black", FixedPrice = 60000, CategoryID = 2, ModelID = 2}
           };

            /*=============================Joining==========================*/
            var Computer = from p in Products
                           join c in Categories
                           on p.CategoryID equals c.CategoryID
                           join m in Models
                           on p.ModelID equals m.ModelID
                           select new { Product = p.ProductID, Category = c.CategoryName, Model = m.ModelName, p.ProductName, p.Color, p.FixedPrice };

            foreach (var x in Computer)
            {
                //Console.WriteLine("Product Name : " + $"{x.ProductName}");
                //Console.WriteLine("Product Model Name  : " + $"{x.Model}");
                Console.WriteLine($"{x.ProductName}\t{x.Model}\t{x.Color}\t{x.FixedPrice}");
            }

            /*=========================Select,where======================*/
            Console.WriteLine("\n--------Select,where--------");
            var pInfo = Products
            .Where(sg => String.Equals(sg.ProductName, "Dell Laptop"))

            .Select(pd => new {
                pd.ProductID,
                pd.ProductName,
                pd.ProductNumber,
                pd.Color,
                pd.FixedPrice,
                pd.ModelID
            });
            foreach (var info in pInfo)
            {
                Console.WriteLine(info);
            }

            /*=============================Group By==========================*/
            Console.WriteLine("\n--------Group By--------");
            var groupPD = from pd in Products
                          group pd by pd.ProductName;

            foreach (var g in groupPD)
            {
                Console.WriteLine(g.Key + " = " + g.Count());
            }

            /*=============================Order By==========================*/
            Console.WriteLine("\n--------OrderBy with descending--------");
            var orderByProduct = from pd in Products
                                 orderby pd.ProductName descending
                                 select pd;

            foreach (var pds in orderByProduct)
            {
                Console.WriteLine(pds.ProductName);
            }

            Console.WriteLine("\n--------ThenBy with Descending--------");
            var product = Products
                .OrderBy(s => s.ProductName)
                .ThenByDescending(s => s.Color);

            foreach (var pd in product)
            {
                Console.WriteLine("ProductName: {0}, Color:{1}", pd.ProductName, pd.Color);
            }

            /*=============================Aggregate==========================*/
            Console.WriteLine("--------------Use of Aggregate-----------");
            //Count
            var totalProducts = Products.Count();

            Console.WriteLine("\nNumber of Total Products: {0}", totalProducts);

            Console.ReadKey();
        }
    }
}
