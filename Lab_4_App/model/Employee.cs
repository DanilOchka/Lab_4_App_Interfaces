using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_App.model
{
    public class Employee
    {
        public int EmployeeID { get; set; } // Идентификатор продукта
        public string Name { get; set; } // Название продукта
        public string Department { get; set; } // Единица измерения
        public string Position { get; set; } // Количество
        public string Phone { get; set; } // Цена

        // Конструктор без параметров (по умолчанию)
        public Employee()
        {
        }

        // Конструктор с параметрами для удобного создания объектов Product
        public Employee(int employeeID, string name, string department, string position, string phone)
        {
            EmployeeID = employeeID;
            Name = name;
            Department = department;
            Position = position;
            Phone = phone;
        }
    }
}
