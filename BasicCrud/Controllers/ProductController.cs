using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    public class ProductsList
    {
        public static List<Product> MyList = new List<Product>();

        public ProductsList()
        {
            Product product = new Product()
                {
                    Name = "Coke",
                    Unit = "Bottle",
                    Price = 60,
                    DateOfExpiry = new DateTime(2022, 02, 02),
                    AvailableInventory = 20
                };
            MyList.Add(product);
        }
    }

    [ApiController]
    [Route("[controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public Product GetProduct(int index)
        {
            try
            {
                return ProductsList.MyList[index];
            }
            catch
            {
                return null;
            }
            
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return ProductsList.MyList;
        }


        [HttpPost(Name = "CreateProduct")]
        public IEnumerable<Product> CreateProduct(String name, String unit, double price, DateTime dateOfExpiry, int availableInventory)
        {
            Product newProduct = new Product()
            {
                Name = name,
                Unit = unit,
                Price = price,
                DateOfExpiry = dateOfExpiry,
                AvailableInventory = availableInventory
            };

            ProductsList.MyList.Add(newProduct);

            return ProductsList.MyList;
        }

        [HttpPut(Name = "UpdateProduct")]
        public IEnumerable<Product> UpdateProduct(int index, String name, String unit, double price, DateTime dateOfExpiry, int availableInventory)
        {
            ProductsList.MyList[index].Name = name;
            ProductsList.MyList[index].Unit = unit;
            ProductsList.MyList[index].Price = price;
            ProductsList.MyList[index].DateOfExpiry = dateOfExpiry;
            ProductsList.MyList[index].AvailableInventory = availableInventory;

            return ProductsList.MyList;
        }

        [HttpDelete(Name = "DeleteProduct")]
        public IEnumerable<Product> DeleteProduct(int index)
        {
            ProductsList.MyList.RemoveAt(index);

            return ProductsList.MyList;
        }

        [HttpDelete(Name = "DeleteAllProducts")]
        public IEnumerable<Product> DeleteAllProducts()
        {
            ProductsList.MyList.Clear();

            return ProductsList.MyList;
        }

    }
}