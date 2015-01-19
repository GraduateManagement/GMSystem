using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduateManagement.Models
{
    public class AcademyStudentViewModel
    {
        public int stuID { get; set; }
        public string stuname { get; set; }
        public string progressName { get; set; }
        public int progress { get; set; }
        public List<replies> replyScores { get; set; }
    }

    public class replies
    {
        public string teachername { get; set; }
        public double score { get; set; }
    }
    public class AllocViewModel
    {
        public AllocViewModel() { }
        public AllocViewModel(int stuID, string stuname, List<teacher> teachers)
        {
            this.stuID = stuID;
            this.stuname = stuname;
        }
        public int stuID { get; set; }
        public string stuname { get; set; }
        public List<teacher> teachers { get; set; }
    }

    public class teacher
    {
        public int teacherID { get; set; }
        public string teachername { get; set; }

    }
}