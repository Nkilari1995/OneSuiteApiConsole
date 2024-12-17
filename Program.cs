using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneSuiteApiConsole.Models;
using RestSharp;
using Serilog;
using Serilog.Core;
using System;
using static OneSuiteApiConsole.Models.Clients;
using static OneSuiteApiConsole.Models.Company;
using static OneSuiteApiConsole.Models.Industries;
using static OneSuiteApiConsole.Models.Invoices;
using static OneSuiteApiConsole.Models.Leads;
using static OneSuiteApiConsole.Models.Projects;

class Program
{
    private static IConfiguration Configuration;
    private static ILogger<Program> logger;
    public static async Task Main(string[] args)
    {
        // Setup Logging and Configuration
        var serviceProvider = ConfigureServices();
        logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        Configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var configuration = new ConfigurationBuilder()
          .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true)
           .Build();
        // Base API URL
        string baseUrl = configuration["BusinessRules:BaseUrl"];
        string apiKey = configuration["BusinessRules:ApiKey"];
        var apiEndpoints = configuration.GetSection("BusinessRules:OneSuiteAPI").Get<List<string>>();

        try
        {
            logger.LogInformation("Starting OneSuiteApi process.");
            var options = new RestClientOptions(baseUrl)
            {
                Timeout = TimeSpan.FromMilliseconds(-1) // Infinite timeout
            };
            var client = new RestClient(options);
            foreach (var endpoint in apiEndpoints)
            {
                logger.LogInformation($"Processing endpoint: {endpoint}");
                // Get data from endpoint
                var getRequest = new RestRequest(endpoint, Method.Get);
                getRequest.AddHeader("Authorization", $"{apiKey}");
                getRequest.AddHeader("Content-Type", "application/json");
               
                var getResponse = await client.ExecuteAsync<dynamic>(getRequest);
               
                if (!getResponse.IsSuccessful)
                {
                    logger.LogError($"Failed to get data from {endpoint}: {getResponse.ErrorMessage}");
                   // Console.WriteLine($"Failed to get data from {endpoint}: {getResponse.ErrorMessage}");
                    continue;
                }

                string trimmedEndpoint = endpoint.Substring(4);
                if (trimmedEndpoint.ToLower() == "leads")
                {
                    logger.LogInformation($"Started Deserializing leads data");
                    Root leadjsonResponse = JsonConvert.DeserializeObject<Root>(getResponse.Content);
                    logger.LogInformation($"Completed Deserializing leads data");
                    if (leadjsonResponse!=null)
                    {
                        logger.LogInformation($"Deleting Leads data started");
                        foreach (var item in leadjsonResponse.leads)
                        {
                            string id = item.id.ToString(); // Adjust key based on actual response structure
                            logger.LogInformation($"Deleting item with ID: {id}");

                            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                            if (deleteResponse.IsSuccessful)
                            {
                                logger.LogInformation($"Successfully deleted item with ID: {id}");
                            }
                            else
                            {
                                logger.LogError($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                            }
                        }
                        logger.LogInformation($"Deleting leads data completed");
                    }
                }
                if (trimmedEndpoint.ToLower() == "leads/industries")
                {
                    logger.LogInformation($"started Deserializing industries data");
                    Indusrties leadjsonResponse = JsonConvert.DeserializeObject<Indusrties>(getResponse.Content);
                    logger.LogInformation($"completed Deserializing industries data");
                    if (leadjsonResponse != null)
                    {
                        logger.LogInformation($"deleting industries data started");
                        foreach (var item in leadjsonResponse.data)
                        {
                            string id = item.id.ToString(); // Adjust key based on actual response structure
                            logger.LogInformation($"Deleting item with ID: {id}");

                            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                            if (deleteResponse.IsSuccessful)
                            {
                                logger.LogInformation($"Successfully deleted item with ID: {id}");
                            }
                            else
                            {
                                logger.LogError($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                            }
                        }
                        logger.LogInformation($"deleting industries data completed");
                    }
                }
                if (trimmedEndpoint.ToLower() == "leads/companies")
                {
                    Companys leadjsonResponse = JsonConvert.DeserializeObject<Companys>(getResponse.Content);
                    if (leadjsonResponse != null)
                    {
                        logger.LogInformation("started deleting companies data");
                        foreach (var item in leadjsonResponse.companies)
                        {
                            string id = item.id.ToString(); // Adjust key based on actual response structure
                            logger.LogInformation($"Deleting item with ID: {id}");

                            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                            if (deleteResponse.IsSuccessful)
                            {
                                logger.LogInformation($"Successfully deleted item with ID: {id}");
                            }
                            else
                            {
                                logger.LogError($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                            }
                        }
                        logger.LogInformation("completed deleting companies data");
                    }
                }
                //if (trimmedEndpoint.ToLower() == "clients")
                //{
                //    Clientss leadjsonResponse = JsonConvert.DeserializeObject<Clientss>(getResponse.Content);
                //    if (leadjsonResponse != null)
                //    {
                //        foreach (var item in leadjsonResponse.clients)
                //        {
                //            string id = item.id.ToString(); // Adjust key based on actual response structure
                //            Console.WriteLine($"Deleting item with ID: {id}");

                //            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                //            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                //            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                //            if (deleteResponse.IsSuccessful)
                //            {
                //                Console.WriteLine($"Successfully deleted item with ID: {id}");
                //            }
                //            else
                //            {
                //                Console.WriteLine($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                //            }
                //        }
                //    }
                //}
                //if (trimmedEndpoint.ToLower() == "projects")
                //{
                //    Projectt leadjsonResponse = JsonConvert.DeserializeObject<Projectt>(getResponse.Content);
                //    if (leadjsonResponse != null)
                //    {
                //        foreach (var item in leadjsonResponse.projects)
                //        {
                //            string id = item.id.ToString(); // Adjust key based on actual response structure
                //            Console.WriteLine($"Deleting item with ID: {id}");

                //            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                //            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                //            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                //            if (deleteResponse.IsSuccessful)
                //            {
                //                Console.WriteLine($"Successfully deleted item with ID: {id}");
                //            }
                //            else
                //            {
                //                Console.WriteLine($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                //            }
                //        }
                //    }
                //}
                //if (trimmedEndpoint.ToLower() == "invoices")
                //{
                //    Invoicess leadjsonResponse = JsonConvert.DeserializeObject<Invoicess>(getResponse.Content);
                //    if (leadjsonResponse != null)
                //    {
                //        foreach (var item in leadjsonResponse.invoices)
                //        {
                //            string id = item.id.ToString(); // Adjust key based on actual response structure
                //            Console.WriteLine($"Deleting item with ID: {id}");

                //            var deleteRequest = new RestRequest($"{endpoint}/{id}", Method.Delete);
                //            deleteRequest.AddHeader("Authorization", $"{apiKey}");

                //            var deleteResponse = await client.ExecuteAsync(deleteRequest);
                //            if (deleteResponse.IsSuccessful)
                //            {
                //                Console.WriteLine($"Successfully deleted item with ID: {id}");
                //            }
                //            else
                //            {
                //                Console.WriteLine($"Failed to delete item with ID: {id}: {deleteResponse.ErrorMessage}");
                //            }
                //        }
                //    }
                //}

            }
            
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred in process.");
        }

        // Ensure Serilog is properly flushed
        Log.CloseAndFlush();
    }
    private static ServiceProvider ConfigureServices()
    {
        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console() // Log to console
            .WriteTo.File("logs/onesuite-.log", rollingInterval: RollingInterval.Day) // Log to a file
            .MinimumLevel.Information() // Set the minimum log level
            .CreateLogger();

        // Create a service collection
        var serviceCollection = new ServiceCollection();

        // Add Serilog to logging
        serviceCollection.AddLogging(builder =>
        {
            builder.ClearProviders(); // Remove default providers
            builder.AddSerilog();    // Use Serilog
        });

        // Add configuration
        serviceCollection.AddSingleton<IConfiguration>(provider =>
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        });

        return serviceCollection.BuildServiceProvider();
    }
}