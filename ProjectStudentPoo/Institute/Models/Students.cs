namespace StudentsSystem.Institute.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        List<Subjects> Subjects { get; set; }

    }
   
   
}


        
        
        
        
