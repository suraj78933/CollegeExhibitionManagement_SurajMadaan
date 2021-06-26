using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeExhibitionManagement_SurajMadaan.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassMasterID { get; set; }

        public ClassMaster ClassMaster { get; set; }
    }
}
