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
    
    public static class AddProduct
    {
        [FunctionName("AddProduct")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "product")]
            HttpRequest req,
            [Sql("dbo.Products", ConnectionStringSetting = "SqlConnectionString")] out Product product)
        {

            /*
             * Expected JSON
             * 
             
                {
                    "ProductID": 2000001,
                    "Name": "Another Pizza",
                    "Cost": 10
                }
            */
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            product = JsonConvert.DeserializeObject<Product>(requestBody);

            return new CreatedResult($"/api/product", product);
        }
    }
}
