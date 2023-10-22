using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    

        public class ProjectData :  IComparable<ProjectData>
        {
            public ProjectData(string name)
            {
                Name = name;
            }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public int CompareTo(ProjectData other)
            {
                if (Object.ReferenceEquals(other, null))
                {
                    return 1;
                }
                return Name.CompareTo(other.Name);
            }

           
            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
            public override string ToString()
            {
                return "name = " + Name;
            }
        }
    
}
