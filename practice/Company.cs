/*
1. Создайте основной namespace

2. Внутри данного namespace создайте следующие классы:

3. Класс, представляющий сотрудника. Содержит основную информацию о сотруднике,
такую как имя, фамилия, должность и заработная плата. Используйте record для представления сотрудника.

4. Класс, представляющий отдел в компании. Включает в себя список сотрудников, работающих в этом отделе.

5. Класс, представляющий саму компанию. Содержит список отделов и базовую информацию о компании.

6. Создайте несколько сотрудников, отделов и компаний, используя созданные классы.

7. Добавьте функциональность для вывода информации о сотрудниках, отделах и компании в консоль.
*/

namespace ConsoleApp1
{
    internal class Program
    {
        public record Employee
        {
            public string firstName;
            public string lastName;
            public string position;
            public decimal salary;
        };

        public class Department
        {
            public string departmentName;
            public Employee[] employees { get; set; }
        }

        public class Company
        {
            public string сompanyName;
            public short yearOfFoundation;
            public Department[] departments { get; set; }
        }

        public static void Create()
        {
            Employee employee1 = new()
            {
                firstName = "John",
                lastName = "Doe",
                position = "Manager",
                salary = 2000
            };
            
            Employee employee2 = new()
            {
                firstName = "Jane",
                lastName = "Smith",
                position = "Developer",
                salary = 4000
            };

            Employee[] employeesArray =
            {
                employee1, 
                employee2
            };

            Department department1 = new()
            {
                departmentName = "IT", 
                employees = employeesArray
            };

            Department[] departmentsArray =
            {
                department1
            };
            
            Company company = new()
            {
                сompanyName = "ABC Company", 
                departments = departmentsArray
            };

            Console.WriteLine($"Company: {company.сompanyName}");
            foreach (var department in company.departments)
            {
                Console.WriteLine($"  Department: {department.departmentName}");
                foreach (var employee in department.employees)
                {
                    Console.WriteLine(
                        $"    Employee: {employee.firstName} {employee.lastName}, {employee.position}, Salary: {employee.salary}$");
                }
            }
        }

        private static void Main(string[] args)
        {
            Create();
        }
    }
}