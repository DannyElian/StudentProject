using StudentsSystem.Institute.Models;


namespace StudentsSystem.Institute.Services
{
    public class StudentService
    {
        List<Students> _students = new List<Students>();
        List<Subjects> _subject = new List<Subjects>();

        public StudentService()
        {
            CreateStudents();
            
            
        }
     
        private List<Students> CreateStudents() {


            var students = new List<Students>();
           
            Subjects studentsSubject = new Subjects
            {
                SubjectId = 1,
                Name = "Ingles",
            };
            Students studentOne = new Students
            {
                StudentId = 1,
                Name = "Danny",
                LastName = "Medina Cuello",
               
                

            };

            Students studentTwo = new Students
            {
                StudentId = 2,
                Name = "Dariel",
                LastName = "Medina Cuello"

            };

            Students studentThree = new Students
            {
                StudentId = 3,
                Name = "Daniel",
                LastName = "Medina"

            };

            students.Add(studentOne);
            students.Add(studentTwo);
            students.Add(studentThree);

            _students = students;
            return _students;

        }

        public List<Students> GetAll()
        {
            return _students;
        }

        public Students GetByID(int id)
        {
            var student = _students.Find(x => x.StudentId == id);

            return student;
        }

        public List<Students> GetByName(string name)
        {
            var student = _students.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();

            return student;
        }

        public List<Students> GetByLastName(string lastName)
        {
            var student = _students.Where(x => x.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();

            return student;
        }
    }
}
