namespace DIDemo2.Models
{
    public class Collection_Crud_Employee : IEmployRepository
    {
        static List<Employee> li = new List<Employee>();

        static Collection_Crud_Employee()
        {
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.Name = "Alekya";
            emp1.Department = "Dev";
            emp1.Salary = 10000;

            Employee emp2 = new Employee();
            emp2.Id = 2;
            emp2.Name = "Ram";
            emp2.Department = "UI";
            emp2.Salary = 20000;

            Employee emp3 = new Employee();
            emp3.Id= 3;
            emp3.Name = "surya";
            emp3.Department = "HR";
            emp3.Salary = 21000;

            Employee emp4 = new Employee();
            emp4.Id = 4;
            emp4.Name = "chandra";
            emp4.Department = "UI";
            emp4.Salary = 11900;

            li.Add(emp1);
            li.Add(emp2);
            li.Add(emp3);
            li.Add(emp4);

        }
        public int AddEmployee(Employee emp)
        {
            
            li.Add(emp);
            return 1; 
        }

        public void DeleteEmployee(int id)
        {
            
            li.RemoveAll(s => s.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return li;
        }

        public Employee GetEmployeeById(int id)
        {
            return li.FirstOrDefault(s=>s.Id==id);
        }

        public void UpdateEmployee(Employee emp)
        {
            var index = li.FindIndex(s => s.Id == emp.Id);
          
                var empl = li[index];
                empl.Name = emp.Name;
            empl.Department = emp.Department;

            empl.Salary = emp.Salary;
                li[index] = empl;
              


            
        }
    }
}
