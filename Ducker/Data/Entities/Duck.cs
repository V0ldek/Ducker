using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Ducker.Data.Entities
{
    public class Duck
    {
        public string Name { get; set; }
        public int TimesSqueaked { get; set; }
        public Color Color { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
