using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeExhibitionManagement_SurajMadaan.Models
{
    public class ClassMaster
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public int NumberOfStudents { get; set; }

        public List<Student> Students { get; set; }
        public List<ExhibitionCoordinator> ExhibitionCoordinators { get; set; }
    }
}
