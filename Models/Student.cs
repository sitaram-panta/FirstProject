﻿namespace FirstProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Class { get; set; }
        public int CollegeId { get; set; }
        public College College { get; set; }
    }
}
