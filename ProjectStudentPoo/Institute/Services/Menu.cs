using StudentsSystem.Institute.Models;

namespace StudentsSystem.Institute.Services

{
    public class Menu
    {
        private readonly StudentService _studentService;
        private readonly SubjectService _subjectService;
           
        
        public Menu()
        {
            _studentService = new StudentService();
            _subjectService = new SubjectService();
        }
       
        public string? ShowMenu()
        {
            Console.WriteLine("Sistema de instituto");
            Console.WriteLine("");
            Console.WriteLine("**********Menu principal*************");
            Console.WriteLine("");
            Console.WriteLine("Menu de estudiante / Elija una opcion");
            Console.WriteLine("");
            Console.WriteLine("1. Mostrar todos los estudiantes.");
            Console.WriteLine("2. Motrar estudiantes por id.");
            Console.WriteLine("3. Mostrar estudiantes por nombre.");
            Console.WriteLine("4. Motrar estudiantes por apellido.");
            Console.WriteLine("5. Asignar materias estudiante.");
            Console.WriteLine("6. Eliminar materias por id.");
            Console.WriteLine("7. Elminar materia estudiante");
            Console.WriteLine("");
            Console.WriteLine("Menu materias / Elija una opcion");
            Console.WriteLine();
            Console.WriteLine("8.Mostrar todas las materias");
            Console.WriteLine("9.Motrar materias por id");
            Console.WriteLine("10.Mostrar materias por nombre");
            Console.WriteLine("11.Eliminar materia por id");
            Console.WriteLine();
            Console.WriteLine("Elija una opcion/Salir (S)");


            string? option = Console.ReadLine().ToUpper();
            if (option == "S".ToUpper())
            {
                Console.WriteLine();
                Console.WriteLine("Ha salido exitosamente");
            }
            return option;

           

        }
        public void SelectedOption(string option) {
            
            var students = new List<Students>();
            var subjects = new List<Subjects>();
            
            switch (option.ToUpper())
            {

                case "1":
                    Console.WriteLine("Mostrar todos estudiantes");
                    Console.WriteLine("");
                    Console.WriteLine("Digite el id del estudiante");
                    Console.WriteLine("");
                    students = _studentService.GetAll();
                    ShowStudents(students);
                    ReturnToMenu();
                    break;
                case "2":
                

                   
                    Console.WriteLine("Digite el id del estudiante");
                    Console.WriteLine("");
                    bool result = int.TryParse(Console.ReadLine(), out int studentId);
                    Console.WriteLine("Mostrar estudiante por id");
                    Console.WriteLine("");

                    if (result)
                    {
                        var student = _studentService.GetByID(studentId);
                        if (student == null)
                        {
                            ShowNotFoundMessageStudent();
                        }
                        else
                        {
                            ShowStudents(student);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageStudent();
                    }
                    ReturnToMenu();
                    
                    break;
                case "3":
                 
                  
                    Console.WriteLine("Digite el nombre del estudiante");
                    Console.WriteLine("");
                   
                    string name = Console.ReadLine();
                    Console.WriteLine("Mostrar estudiante por nombre");
                    Console.WriteLine("");
                    if (string.IsNullOrEmpty(name))
                    {
                        ShowNotFoundMessageStudent();
                    }
                    else
                    {
                        students = _studentService.GetByName(name);
                        ShowStudents(students);
                    }
                 ReturnToMenu();
                    break;
                case "4":

                    Console.WriteLine("Digite el apellido del estudiante");
                    Console.WriteLine("");

                    string lastName = Console.ReadLine();
                    Console.WriteLine("Mostrar estudiante por apellido");
                    Console.WriteLine("");
                    if (string.IsNullOrEmpty(lastName))
                    {
                        ShowNotFoundMessageStudent();
                    }
                    else
                    {
                        students = _studentService.GetByLastName(lastName);
                        ShowStudents(students);
                    }
                    ReturnToMenu();
                    break;
                case "5":


                    Console.WriteLine("Digite el id de la materia a asignar");
                    Console.WriteLine("");
                    result = int.TryParse(Console.ReadLine(), out int assigneSubjectId);

                    Console.WriteLine("Digite el id del estudiante a asignar");
                    Console.WriteLine("");
                    bool resultTwo = int.TryParse(Console.ReadLine(), out int assignedStudentId);
                    Console.WriteLine();
                    Console.WriteLine("Mostrar materia asignada al estudiante");
                    Console.WriteLine("");

                    if (result)
                    {
                        var subject = _subjectService.GetByID(assigneSubjectId);
                        var student = _studentService.GetByID(assignedStudentId);
                      
                        if (subject == null)
                        {
                            ShowNotFoundMessageSubject();
                        }
                        else
                        {

                            ShowSubjectAssigned(subject, student);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageSubject();
                    }
                    ReturnToMenu();

                    break;
                case "6":
                    Console.WriteLine("Digite el id de la materia a eliminar");
                    Console.WriteLine("");

                    bool subjectIdDeleted = int.TryParse(Console.ReadLine(), out int deleteSubject);
                    Console.WriteLine("Mostrar materia eliminada");
                    Console.WriteLine("");

                    if (subjectIdDeleted)
                    {
                        var subject = _subjectService.DeleteSubjectById(deleteSubject);
                        if (subject == null)
                        {
                            ShowNotFoundMessageSubject();
                        }
                        else
                        {
                            ShowSubjectsDeleted(subject);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageStudent();
                    }
                    ReturnToMenu();

                    break;
                case "7":
                    Console.WriteLine("Digite el id de la materia a eliminar");
                    Console.WriteLine("");
                    result = int.TryParse(Console.ReadLine(), out  assigneSubjectId);

                    Console.WriteLine("Digite el id del estudiante a de la materia a eliminar");
                    Console.WriteLine("");
                     resultTwo = int.TryParse(Console.ReadLine(), out  assignedStudentId);
                    Console.WriteLine();
                    Console.WriteLine("Mostrar materia eliminada al estudiante");
                    Console.WriteLine("");

                    if (result)
                    {
                        var subject = _subjectService.DeleteSubjectById(assigneSubjectId);
                        var student = _studentService.GetByID(assignedStudentId);

                        if (subject == null)
                        {
                            ShowNotFoundMessageSubject();
                        }
                        else
                        {

                            ShowSubjectStudentDeleted(subject, student);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageSubject();
                    }
                    ReturnToMenu();


                    break;
                case "8":
                    Console.WriteLine("Mostrar todas las materias");
                    Console.WriteLine("");

                 
                    subjects = _subjectService.GetAll();
                    ShowSubjects(subjects);
                    ReturnToMenu();

                    break;
                case "9":
                    Console.WriteLine("Digite el id de la materia");
                    Console.WriteLine("");
                     result = int.TryParse(Console.ReadLine(), out int subjectId);
                    Console.WriteLine("Mostrar materia por id");
                    Console.WriteLine("");

                    if (result)
                    {
                        var subject = _subjectService.GetByID(subjectId);
                        if (subject == null)
                        {
                            ShowNotFoundMessageSubject();
                        }
                        else
                        {
                            ShowSubjects(subject);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageSubject();
                    }
                    ReturnToMenu();

                    break;
                case "10":
                    Console.WriteLine("Digite el nombre de la materia");
                    Console.WriteLine("");

                    string subjectName = Console.ReadLine();
                    Console.WriteLine("Mostrar materia por nombre");
                    Console.WriteLine("");
                    if (string.IsNullOrEmpty(subjectName))
                    {
                        ShowNotFoundMessageSubject();
                    }
                    else
                    {
                        subjects = _subjectService.GetByName(subjectName);
                        ShowSubjects(subjects);
                    }
                    ReturnToMenu();
                    break;

                case "11":
                    Console.WriteLine("Digite el id de la materia a eliminar");
                    Console.WriteLine("");

                     subjectIdDeleted = int.TryParse(Console.ReadLine(), out  deleteSubject);
                    Console.WriteLine("Mostrar materia eliminada");
                    Console.WriteLine("");

                    if (subjectIdDeleted)
                    {
                        var subject = _subjectService.DeleteSubjectById(deleteSubject);
                        if (subject == null)
                        {
                            ShowNotFoundMessageSubject();
                        }
                        else
                        {
                            ShowSubjectsDeleted(subject);
                        }
                    }
                    else
                    {
                        ShowNotFoundMessageStudent();
                    }
                    ReturnToMenu();

                    break;
                default:
                    break;

            }
        
        }
        public void ReturnToMenu() { 
            
            Console.WriteLine("Desea elegir otra opcion/Salir");
            Console.WriteLine("");
            string? answer = Console.ReadLine().ToUpper();

            if (answer == "SI".ToUpper())
            {
                string? option = ShowMenu();
                SelectedOption(option);
                
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ha salido exitosamente");
            }
        
        }

        private void ShowStudents(List<Students> students) 
        {
            Console.WriteLine($"ID:           Nombre:            Apellido");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.StudentId}             {item.Name}            {item.LastName}");
            }
        }
        private void ShowStudents(Students student)
        {
            Console.WriteLine($"ID:           Nombre:            Apellido");
            
              Console.WriteLine($"{student.StudentId}             {student.Name}            {student.LastName}");

        
      

        }
       
        private void ShowSubjects(List<Subjects> subjects)
        {
            Console.WriteLine($"ID:           Nombre:");
            foreach (var item in subjects)
            {
                Console.WriteLine($"{item.SubjectId}             {item.Name}   ");
            }
        }
        private void ShowSubjects(Subjects subjects)
        {
            Console.WriteLine($"ID:           Nombre:");
            
                Console.WriteLine($"{subjects.SubjectId}             {subjects.Name}   ");
            
        }
        private void ShowSubjectsDeleted(Subjects subjects)
        {
            Console.WriteLine($"ID:           Nombre:");

            Console.WriteLine($"{subjects.SubjectId}             {subjects.Name}   ");
        }
        private void ShowSubjectAssigned(Subjects subjects, Students students)
        {
            Console.WriteLine($"ID estudiante: {students.StudentId}           Nombre estudiante: {students.Name}");
            
            Console.WriteLine($"Materia asignada: {subjects.Name}");
           
        }
        private void ShowSubjectStudentDeleted(Subjects subjects, Students student)
        {
            Console.WriteLine($"ID: {student.StudentId}           Nombre: {student.Name}");

            Console.WriteLine($"Materia eliminada: {subjects.Name}");
        }
        private void ShowNotFoundMessageStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Esudiante no encontrado");
            Console.WriteLine();
        }
        private void ShowNotFoundMessageSubject()
        {
            Console.WriteLine();
            Console.WriteLine("Materia no encontrada");
            Console.WriteLine();
        }
    }
}
