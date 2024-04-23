using StudentsSystem.Institute.Models;
using System.Xml.Linq;

namespace StudentsSystem.Institute.Services
{
    public class SubjectService
    {
        List<Subjects> _subjects = new List<Subjects>();

        public SubjectService()
        {
            CreateSubjects();
        }
        private List<Subjects> CreateSubjects()
        {
            

            var subjects = new List<Subjects>();

            Subjects subjectOne = new Subjects
            {
                SubjectId = 1,
                Name = "Ingles"

            };

            Subjects subjectTwo = new Subjects
            {
                SubjectId = 2,
                Name = "Matematica",
               

            };

            Subjects subjectThree = new Subjects
            {
                SubjectId = 3,
                Name = "Redaccion Castellana"

            };

            subjects.Add(subjectOne);
            subjects.Add(subjectTwo);
            subjects.Add(subjectThree);


            _subjects = subjects;
            return _subjects;

        }

        public List<Subjects> GetAll()
        {
            return _subjects;
        }

        public Subjects GetByID(int id)
        {
            var subjects = _subjects.Find(x => x.SubjectId == id);

            return subjects;
        }

        public List<Subjects> GetByName(string name)
        {
            var subjects = _subjects.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList() ; 

            return subjects;
        }
        public Subjects DeleteSubjectById(int id)
        {
            var subjects = _subjects.Find(x => x.SubjectId == id);
            if (id == 1)
            {
                subjects.Name = "Ingles";
            }else if (id == 2)
            {
                subjects.Name = "Matematica";

            }else if(id == 3)
            {
                subjects.Name = "Redaccion castellana";
            }

            return subjects;
        }

        public Subjects DeleteSubjectStudent(int id)
        {
            var subjects = _subjects.Find(x => x.SubjectId == id);
            if (id == 1)
            {
                subjects.Name = "";
            }
            else if (id == 2)
            {
                subjects.Name = "";

            }
            else if (id == 3)
            {
                subjects.Name = "";
            }

            return subjects;
        }

    }
}
