﻿using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Services
{
    public interface IStudentService
    {
        Task<int> AddAsync(Student student);
        Task<List<Student>> GetAllAsync();
    }
}