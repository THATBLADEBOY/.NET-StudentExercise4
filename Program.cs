using StudentExercises.Data;
using StudentExercises.Model;
using System;
using System.Collections.Generic;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();
            PrintStuff("All Exercises", exercises);
            Pause();

            exercises = repository.GetExercisesByLanguage("JavaScript");
            PrintStuff("JavaScript Exercises", exercises);
            Pause();

            Exercise jumpingjacks = new Exercise
            {
                Name = "Jumping Jacks",
                Language = "Not the right kind of exercise bro.."
            };

            repository.AddExercise(jumpingjacks);

            exercises = repository.GetAllExercises();
            PrintStuff("All Exercises After Adding an Exercise", exercises);
            Pause();

            List<Instructor> instructors = new List<Instructor>();
            instructors = repository.GetAllInstructors();
            PrintInstructors("All instructors", instructors);
            Pause();

            Instructor Madi = new Instructor
            {
                FirstName = "Super",
                LastName = "Man",
                Slack = "@Clark",
                CohortId = 1
            };

            repository.AddInstructor(Madi);

            instructors = repository.GetAllInstructors();
            PrintInstructors("All instructors after adding new instructor", instructors);
            Pause();

            repository.AddExerciseToStudent(1, 4);


        }

        public static void PrintStuff(string title, List<Exercise> exercises)
        {
            Console.WriteLine(title);
            foreach(Exercise ex in exercises)
            {
                Console.WriteLine($"{ex.Id}. {ex.Name} Language: {ex.Language}");
            }
 
        }

        public static void PrintInstructors(string title, List<Instructor> instructors)
        {
            Console.WriteLine(title);
            foreach (Instructor inst in instructors)
            {
                Console.WriteLine($"{inst.Id}. {inst.FirstName} {inst.LastName} Cohort: {inst.Cohort.Name}");
            }

        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
