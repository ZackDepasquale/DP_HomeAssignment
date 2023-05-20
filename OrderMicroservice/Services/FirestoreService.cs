using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderMicroservice.Models;
using ProductCatalogueMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderMicroservice.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly HttpClient _httpClient;

        public FirestoreService(HttpClient httpClient, IConfiguration configuration)
        {
            _firestoreDb = FirestoreDb.Create("distributedprogramming-386215");
            _httpClient = httpClient;
        }

        public async Task AddOrder(Order order)
        {
            CollectionReference ordersRef = _firestoreDb.Collection("Orders");

            foreach (var product in order.Products)
            {
                var response = await _httpClient.GetAsync($"https://productcataloguemicroservice-mvug6bkbra-uc.a.run.app/product/{product.Id}"); // TODO: Update the URL according to your ProductCatalogueMicroservice URI

                if (response.IsSuccessStatusCode)
                {
                    var productDetails = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
                    product.Title = productDetails.Title;
                    product.Description = productDetails.Description;
                    product.Price = productDetails.Price;
                    product.Category = productDetails.Category;
                    product.Image = productDetails.Image;
                }
            }

            Dictionary<string, object> orderData = new Dictionary<string, object>
            {
                { "Id", order.Id },
                { "UserId", order.UserId },
                { "OrderDate", order.OrderDate },
                { "Status", order.Status },
                { "Products", JsonConvert.SerializeObject(order.Products) }
            };

            await ordersRef.AddAsync(orderData);
        }

        public async Task<List<Order>> GetOrders()
        {
            Query ordersQuery = _firestoreDb.Collection("Orders");
            QuerySnapshot ordersSnapshot = await ordersQuery.GetSnapshotAsync();

            List<Order> orders = new List<Order>();
            foreach (DocumentSnapshot documentSnapshot in ordersSnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> orderData = documentSnapshot.ToDictionary();

                    Order order = new Order();

                    if (orderData.ContainsKey("Id"))
                    {
                        order.Id = orderData["Id"].ToString();
                    }

                    if (orderData.ContainsKey("UserId"))
                    {
                        order.UserId = orderData["UserId"].ToString();
                    }

                    if (orderData.ContainsKey("Products"))
                    {
                        var productsJson = orderData["Products"].ToString();
                        order.Products = JArray.Parse(productsJson).ToObject<List<Product>>();
                    }

                    if (orderData.ContainsKey("OrderDate") && orderData["OrderDate"] is Timestamp orderDateTimestamp)
                    {
                        order.OrderDate = orderDateTimestamp.ToDateTime();
                    }

                    if (orderData.ContainsKey("Status"))
                    {
                        order.Status = orderData["Status"].ToString();
                    }

                    orders.Add(order);
                }
            }

            return orders;
        }

        public async Task<Order> GetOrder(string orderId)
        {
            // Get the collection reference
            CollectionReference ordersRef = _firestoreDb.Collection("Orders");

            // Build a query against the collection for documents where the 'Id' field equals orderId
            Query query = ordersRef.WhereEqualTo("Id", orderId);

            // Get the snapshot of the query result
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // If no documents matched the query, return null
            if (querySnapshot.Count == 0)
            {
                return null;
            }

            // Get the first (and should be the only) document from the query result
            DocumentSnapshot orderSnapshot = querySnapshot.Documents[0];

            // Proceed as before...
            Dictionary<string, object> orderData = orderSnapshot.ToDictionary();

            Order order = new Order
            {
                Id = orderData["Id"].ToString(),
                UserId = orderData["UserId"].ToString(),
                OrderDate = orderData.ContainsKey("OrderDate") && orderData["OrderDate"] is Timestamp orderDateTimestamp
                    ? orderDateTimestamp.ToDateTime()
                    : default,
                Status = orderData["Status"].ToString(),
                Products = orderData.ContainsKey("Products")
                    ? JsonConvert.DeserializeObject<List<Product>>(orderData["Products"].ToString())
                    : new List<Product>()
            };

            if (orderData.ContainsKey("Products") && orderData["Products"] is List<object> productDataList)
            {
                foreach (var productData in productDataList)
                {
                    if (productData is Dictionary<string, object> productDictionary)
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToInt32(productDictionary["Id"]),
                            Title = productDictionary["Title"].ToString(),
                            Description = productDictionary["Description"].ToString(),
                            Price = double.Parse(productDictionary["Price"].ToString()),
                            Category = productDictionary["Category"].ToString(),
                            Image = productDictionary["Image"].ToString()
                        };

                        order.Products.Add(product);
                    }
                }
            }

            return order;
        }


    }
}