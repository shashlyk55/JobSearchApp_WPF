using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApp.Model
{
    public class IndustryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IndustryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
