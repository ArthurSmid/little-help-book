using System;
using System.Collections.Generic;
using AirtableApiClient;
using Newtonsoft.Json;

namespace LittleHelpBook.Shared.Data
{
    // Places, Categories, Cuisines, Delivery Services, Order Delivery Links

    /// <summary>
    /// interface for hoisting Airtable IDs into data objests
    /// </summary>
    public interface IAirtable
    {
        public string Id { get; set; }
    }

    /// <summary>
    /// most tables have an Order field for sorting
    /// </summary>
    public interface IOrder
    {
        public int Order { get; set; }
    }

    /// <summary>
    /// Name, Category, Phone, URL, Address, Notes, Order Delivery Links, Menu,
    /// </summary>
    public class Place : IAirtable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("Category")]
        public List<string> Categories { get; set; }
        public List<Category> CategoryList { get; set; } = new List<Category>();
        public List<string> Cuisines { get; set; }
        public List<string> Tags { get; set; }

        public List<Cuisine> CuisineList { get; set; } = new List<Cuisine>();
        public List<Tag> TagList { get; set; } = new List<Tag>();
        [Obsolete]
        public string CuisineDisplay { get; set; }
        [Obsolete]
        public string Pickup { get; set; }

        [JsonProperty("Ordering Services")]
        public List<string> OrderingServices { get; set; }
        public List<OrderingService> OrderingServiceList { get; set; } = new List<OrderingService>();
        public string DeliveryOptionsDisplay { get; set; }
        public string Phone { get; set; }
        public string URL { get; set; }
        public string Address { get; set; }
        public string Specials { get; set; }
        public string Notes { get; set; }
        public List<AirtableAttachment> Menu { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }

    /// <summary>
    /// Category, Places, 
    /// </summary>
    public class Category : IAirtable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<string> Places { get; set; }
        public string Order { get; set; }
    }

    public class Cuisine : IAirtable
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class OrderingService : IAirtable
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<string> OrderDeliveryLinks { get; set; }
        [JsonProperty("Delivery Methods")]
        public List<string> DeliveryMethods { get; set; }

        //remove offending junk like  spaces and dashes and '
        public string ImageName => String.Join("", Name.Split(' ', '-', '\'')).ToLower();
        public int Order { get; set; }
    }

    public class Tag : IAirtable
    {
        public string Id { get; set; }
        public string Name { get; set; }


    }

    public class OrderingServiceLink
    {
        public string Id { get; set; }
        public string URL { get; set; }
        [JsonIgnore]
        public List<String> Places { get; set; }
        [JsonIgnore]
        public List<String> OrderingServices { get; set; }
    }
}
