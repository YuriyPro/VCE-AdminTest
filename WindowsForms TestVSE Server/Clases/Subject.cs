using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_TestVSE_Server.Clases
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /////////////////Test
        public ICollection<Test> Tests { get; set; }
    }
}
