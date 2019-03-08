using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ducker.Models
{
    public class DuckViewModel
    {
        public string Name { get; }
        public string UserName { get; }

        public DuckViewModel(string name, string userName)
        {
            Name = name;
            UserName = userName;
        }
    }
}
