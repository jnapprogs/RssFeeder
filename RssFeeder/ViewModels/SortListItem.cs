using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeeder.ViewModels
{
    public class SortListItem
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SortListItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
