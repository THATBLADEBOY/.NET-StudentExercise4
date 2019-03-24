using StudentExercises.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudentExercises.Data
{
    class Repository
    {

        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Server=DESKTOP-2BPE20J\\SQLEXPRESS;Database=StudentExercises;Trusted_Connection=True;";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {

                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int ExerciseNameColumnPosition = reader.GetOrdinal("Name");
                        string exerciseNameValue = reader.GetString(ExerciseNameColumnPosition);

                        int ExerciseLanguageColumnPosition = reader.GetOrdinal("Language");
                        string exerciseLanguageValue = reader.GetString(ExerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = exerciseNameValue,
                            Language = exerciseLanguageValue

                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public List<Exercise> GetExercisesByLanguage(string language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Language FROM Exercise Where Language LIKE 'JavaScript'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {

                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int ExerciseNameColumnPosition = reader.GetOrdinal("Name");
                        string exerciseNameValue = reader.GetString(ExerciseNameColumnPosition);

                        int ExerciseLanguageColumnPosition = reader.GetOrdinal("Language");
                        string exerciseLanguageValue = reader.GetString(ExerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = exerciseNameValue,
                            Language = exerciseLanguageValue

                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }

            }
        }

        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Exercise (Name, Language) Values ('{exercise.Name}', '{exercise.Language}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.Slack,c.Id AS Cohort, c.Name" +
                        " FROM Instructor i INNER JOIN Cohort c ON i.CohortId = c.id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {

                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int InstructorFirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string instructorFirstNameValue = reader.GetString(InstructorFirstNameColumnPosition);

                        int InstructorsLastNameColumnPosition = reader.GetOrdinal("LastName");
                        string instructorLastNameValue = reader.GetString(InstructorsLastNameColumnPosition);

                        int InstructorsSlackColumnPosition = reader.GetOrdinal("Slack");
                        string instructorSlackValue = reader.GetString(InstructorsSlackColumnPosition);

                        int InstructorsCohortColumnPosition = reader.GetOrdinal("Cohort");
                        int instructorCohortValue = reader.GetInt32(InstructorsCohortColumnPosition);

                        int cohortNameColumnPosition = reader.GetOrdinal("Name");
                        string cohortName = reader.GetString(cohortNameColumnPosition);

                        Cohort instructorsCohort = new Cohort(cohortName, instructorCohortValue);
                       
                        Instructor instructor = new Instructor
                        {
                            Id = idValue,
                            FirstName = instructorFirstNameValue,
                            LastName = instructorLastNameValue,
                            Slack = instructorSlackValue,
                            Cohort = instructorsCohort

                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return instructors;
                }
            }
        }

        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"INSERT INTO Instructor(FirstName,LastName,Slack,CohortId) Values(@FirstName, @LastName, @Slack, @CohortId)";

                    cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Slack", instructor.Slack));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", instructor.CohortId));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddExerciseToStudent(int student, int exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"INSERT INTO StudentExercise(Student, Exercise) Values(@student, @exercise)";
                    cmd.Parameters.Add(new SqlParameter("@student", student));
                    cmd.Parameters.Add(new SqlParameter("@exercise", exercise));

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
