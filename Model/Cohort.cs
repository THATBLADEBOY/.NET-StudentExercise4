using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Model
{
    class Cohort
    {
        public Cohort(string name, int id)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
