using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedStoreContext
    {
        public static async Task SeedData(StoreContext context, ILoggerFactory loggerFactory)
        {
            try 
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(path + @"Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();

                }
                if(!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(path + @"Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();

                }
                if(!context.Products.Any())
                {
                    var productData = File.ReadAllText(path + @"Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach(var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if(!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText(path + @"Data/SeedData/delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach(var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();

                }
                
            }
            catch(Exception ex)
            {
               
            }
        }
    }
}