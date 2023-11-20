using System.Globalization;

namespace ConsoleApp1
{
    public delegate void Notification(int salary);
    class Employee
    {
        public Notification notification;
        public string Name { get; set; }
        public int PayForHour { get; set; }
        public void CalculateSalary(int hour)
        {
            int res = PayForHour * hour;
            notification?.Invoke(res);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { Name = "Vasya", PayForHour = 34 };
            employee.notification = s => Console.WriteLine($"Sms about salary {s}");
            employee.notification += s => Console.WriteLine($"Bank notification about salary {s}");
            employee.CalculateSalary(100);
        }
    }
}