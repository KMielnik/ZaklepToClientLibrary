using System.Collections.Generic;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnCreate
{
    public class RestaurantOnCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Localization { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}
