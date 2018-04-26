using System;
using System.Collections.Generic;

namespace ZaklepToClientLibrary.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Localization { get; set; }
        public IEnumerable<Table> Tables { get; set; }

        public Restaurant()
        {
        }

        public Restaurant(Guid id, string name, string description, string cuisine, string localization, IEnumerable<Table> tables)
        {
            Id = id;
            Name = name;
            Description = description;
            Cuisine = cuisine;
            Localization = localization;
            Tables = tables;
        }
    }
}