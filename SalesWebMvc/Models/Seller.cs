using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSals(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime inicialDate, DateTime finalDate)
        {
            return Sales.Where(x => x.Date >= inicialDate && x.Date <= finalDate) //filtra pela data
                .Sum(x => x.Amount); //faz o somatório da lista já filtrada
        }
    }
}
