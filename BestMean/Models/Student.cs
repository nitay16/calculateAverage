using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestMean.Models
{
    public class Student
    {
        // get or set id of student
       public String? id { get; set; }
        // get or set First name of student 
        public String? First_name { get; set; }
        // get or set last name name of student 
        public String? Last_name { get; set; }
        // get or set list of cources
        public List<Courses>? cources { get; set; }
        // get Full Name of student
        public string FullName => $"{First_name} {Last_name}";

        public List<List<Courses>> GetCourseCombinationsWithTotalPoints()
        {
            var validCombinations = new List<List<Courses>>();
            var temp_coursces = cources;
            var coursesWithPositivePoints = cources.Where(c => int.TryParse(c.Course_points, out int points) && points > 0).ToList();
            GenerateCourseCombinations(temp_coursces, 10, new List<Courses>(), validCombinations);
            return validCombinations;
        }
        private void GenerateCourseCombinations(List<Courses> courses, int targetPoints, List<Courses> currentCombination, List<List<Courses>> validCombinations,int start_index=0)
        {
            int currentPoints = currentCombination.Sum(c => int.Parse(c.Course_points));
            if (currentPoints == 10)
            {
                validCombinations.Add(new List<Courses>(currentCombination));
                return;
            }

            if (currentPoints > targetPoints)
            {
                return;
            }

            for (int i = start_index; i < courses.Count; i++)
            {
                var course = courses[i];
                currentCombination.Add(course);
                GenerateCourseCombinations(courses, targetPoints, currentCombination, validCombinations,i+1);
                /*currentCombination.Remove(course);*/
                currentCombination.RemoveAt(currentCombination.Count - 1);

            }
        }
        public double CalculateBestAverageForTotalPoints()
        {
            var validCombinations = GetCourseCombinationsWithTotalPoints();
            if (validCombinations.Count == 0)
            {
                return 0;
            }

            double maxAverage = double.MinValue;
            foreach (var combination in validCombinations)
            {
                double average = CalculateAverage(combination);
                if (average > maxAverage)
                {
                    maxAverage = average;
                }
            }
            double roundedNum = Math.Round(maxAverage, 2);

            return roundedNum;
        }
        private double CalculateAverage(List<Courses> combination)
        {
            if (combination.Count == 0)
            {
                return 0;
            }

            int totalScore = combination.Sum(c => c.Course_score);
            return (double)totalScore / combination.Count;
        }
    }



}

