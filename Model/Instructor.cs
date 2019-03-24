using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Model
{
    class Instructor
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }



        public void AssignExercise(Student studentname, Exercise excercisename)
        {
            studentname.Exercises.Add(excercisename);

        }
    }
}
