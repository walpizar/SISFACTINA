﻿using System;
using System.Collections.Generic;

namespace AppFacturadorApi.Entities.Model
{
    public partial class Roles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
