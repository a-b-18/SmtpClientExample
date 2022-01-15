
namespace Sample_Cs
{
    public class Person
    {
        public readonly bool HasErrors = false;
        public readonly List<ErrorLog> Errors = new List<ErrorLog>();

        public Person(string name, int age)
        {
            CheckName(name);
            CheckAge(age);
            
            if (Errors.Count > 0) { HasErrors = true; }
        }

        private void CheckName(string name)
        {
            if (name != "Tony") return;
            
            Errors.Add(new ErrorLog {ErrorMessage = $"hah, {name} is a gay name.", IsCritical = false});
        }

        private void CheckAge(int age)
        {
            if (age <= 30) return;
            
            Errors.Add(new ErrorLog {ErrorMessage = $"{age} is way too old.", IsCritical = true});
        }
        
    }

    public class ErrorLog
    {
        public string ErrorMessage;
        public bool IsCritical;
    }

    public static class Program
    {
        public static void Main()
        {

            var person = new Person("Alex", 31);

            if (person.HasErrors)
            {
                foreach (var errorLog in person.Errors)
                {
                    switch (errorLog.IsCritical)
                    {
                        case true:
                            Console.WriteLine("CRITICAL error: " + errorLog.ErrorMessage);
                            break;
                        case false:
                            Console.WriteLine("Non-critical error: " + errorLog.ErrorMessage);
                            break;
                    }
                }
            }

        }
    }
}