﻿using System;
using System.Collections.Generic;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnUpdate
{
    public class RestaurantOnUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Localization { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}
