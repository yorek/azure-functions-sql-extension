// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;

using static SqlExtensionSamples.ProductUtilities;

namespace SqlExtensionSamples
{
    public static class AddProductsArray
    {
        [FunctionName("AddProductsArray")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "products")]
            HttpRequest req,
            [Sql("dbo.Products", ConnectionStringSetting = "SqlConnectionString")] out Product[] products)
        {

            // Suppose that the ProductID column is the primary key in the Products table, and the 
            // table already contains a row with ProductID = 1. In that case, the row will be updated
            // instead of inserted to have values Name = "Cup" and Cost = 2. 

            /*
             * Expected JSON
             * 
             
                [{
                    "ProductID": 1,
                    "Name": "Cup",
                    "Cost": 2
                },
                {
                    "ProductID": 2,
                    "Name": "Glasses",
                    "Cost": 12
                }]
            */

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            products = JsonConvert.DeserializeObject<Product[]>(requestBody);

            return new CreatedResult($"/api/products", products);
        }
    }
}
