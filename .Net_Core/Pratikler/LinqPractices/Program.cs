using LinqPractices;
using LinqPractices.DbOperations;

internal class Program
{
    private static void Main(string[] args)
    {
        DataGenerator.Initialize();
        LinqDbContext _context = new LinqDbContext();
        var students = _context.Students.ToList<Student>();

        //Find()
        Console.WriteLine("**** Find ****");
        var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
        student = _context.Students.Find(2);
        Console.WriteLine(student.Name);

        //FirstOrDefault()
        Console.WriteLine("\n**** FirstOrDefault ****");
        student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
        Console.WriteLine(student.Name);

        student = _context.Students.FirstOrDefault(x=> x.Surname == "Arda");
        Console.WriteLine(student.Name);

        //SingleOrDefault()
        Console.WriteLine("\n**** SingleOrDefault ****");
        student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");
        Console.WriteLine(student.Surname);

        //ToList()
        Console.WriteLine("\n**** ToList ****");
        var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
        Console.WriteLine(studentList.Count);

        //OrderBy()
        Console.WriteLine("\n**** OrderBy ****");
        students = _context.Students.OrderBy(x => x.StudentId).ToList();
        foreach (var st in students)
        {
            Console.WriteLine(st.StudentId + " - " + st.Name + " "+ st.Surname);
        }

        //OrderByDescending()
        Console.WriteLine("\n**** OrderByDescending ****");
        students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
        foreach (var st in students)
        {
            Console.WriteLine(st.StudentId + " - " + st.Name + " "+ st.Surname);
        }

        //Anonymous Object Result
        Console.WriteLine("\n**** Anonymous Object Result ****");

        var anonymousObject = _context.Students
                            .Where(x => x.ClassId == 2)
                            .Select(x => new {
                                Id = x.StudentId,
                                FullName = x.Name + " " + x.Surname
                            });
        foreach (var obj in anonymousObject)
        {
            Console.WriteLine(obj.Id + " - " + obj.FullName);
        }
    }
}