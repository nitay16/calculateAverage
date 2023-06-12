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
        public List<Courses>? courses { get; set; }
        // get Full Name of student
        public string FullName => $"{First_name} {Last_name}";
        /*In this function i want to get of combination of cources that each combination the sum of the courses points is 10*/
        public List<List<Courses>> GetCourseCombinationsWithTotalPoints()
        {
            //initiate empty list of lists of courses
            var validCombinations = new List<List<Courses>>();
            var temp_courses = courses;
            // call to recursive function that return all valid combinations
            GenerateCourseCombinations(temp_courses, 10, new List<Courses>(), validCombinations,0);
            return validCombinations;
        }
        private void GenerateCourseCombinations(List<Courses> courses, int targetPoints, List<Courses> currentCombination, List<List<Courses>> validCombinations,int start_index)
        {
            //calculte the sum of the cuurent combination
            int currentPoints = currentCombination.Sum(c => int.Parse(c.Course_points));
            if (currentPoints == targetPoints)
            {
                // if the current points is equal to the target points so add it to the valid combinations
                validCombinations.Add(new List<Courses>(currentCombination));
                return;
            }

            if (currentPoints > targetPoints)
            {
                return;
            }
            
            for (int i = start_index; i < courses.Count; i++)
            {
                // take course for courses in index i
                var course = courses[i];
                //add this course to the current combination
                currentCombination.Add(course);
                //do recursive call from the next index so we will not do the same adding the same element next time
                GenerateCourseCombinations(courses, targetPoints, currentCombination, validCombinations,i+1);
                //delete the last candidate from the current combination
                currentCombination.RemoveAt(currentCombination.Count - 1);

            }
        }
        /*this function calcultes each average of each combination the takes the best average*/
        public double CalculateBestAverageForTotalPoints()
        {
            var validCombinations = GetCourseCombinationsWithTotalPoints();
            // if there is no combination with sum of course points that equal to 10 so return 0 - there is no such average
            if (validCombinations.Count == 0)
            {
                return 0;
            }
            // initiate max_average to be the most minimum value
            double maxAverage = double.MinValue;
            foreach (var combination in validCombinations)
            {
                double average = CalculateAverage(combination);
                if (average > maxAverage)
                {
                    maxAverage = average;
                }
            }
            //return the best average by round to 2 points after point
            double roundedNum = Math.Round(maxAverage, 2);

            return roundedNum;
        }
        //this function calcultes simple average
        private double CalculateAverage(List<Courses> combination)
        {
            if (combination.Count == 0)
            {
                return 0;
            }

            int totalScore = combination.Sum(c => c.Course_score);
            return (double)totalScore / combination.Count;
        }
        // get list of the best courses that with them we calculated the best average with the functions above
        public List<string> GetBestAverageCourses()
        {
            var validCombinations = GetCourseCombinationsWithTotalPoints();
            if (validCombinations.Count == 0)
            {
                return new List<string>();
            }

            var bestCombination = validCombinations.OrderByDescending(c => CalculateAverage(c)).First();
            var courseNames = bestCombination.Select(c => c.Course_name).ToList();
            return courseNames;
        }
    }



}

