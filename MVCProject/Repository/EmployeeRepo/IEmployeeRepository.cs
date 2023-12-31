﻿using System.Collections.Generic;
using MVCProject.Models;

namespace MVCProject.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id, bool includeRelatedEntities = true);
        void Create(Employee employee);
        void Edit(Employee employee);
        void Delete(int id);
        void Save();
    }
}
