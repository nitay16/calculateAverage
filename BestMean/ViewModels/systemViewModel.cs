using BestMean.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestMean.ViewModels
{
    
    public class systemViewModel:Screen
    {
        //"_selectedStude field for the drop down list when i choose a student
        private Student _selectedStudent;
        // the next variable is a collection of students variable that needs to "binded" with our GUI window
        private BindableCollection<Student> _students = new BindableCollection<Student>();
        private double _avg;
        //variable the contains a list of the best average courses for _avg variable
        private List<string> _bestAverageCourses;

        /*In this constructior we intialize students and courses list and add them with the function of "Students"*/
        public systemViewModel()
        {

            List<Courses>  course_jonatan= new List<Courses>();
            course_jonatan.Add(new Courses { Id = "1", Course_name = "Hedva 1 ", Course_points = "4", Course_score = 89 });
            course_jonatan.Add(new Courses { Id = "2", Course_name = "Physics 1 ", Course_points = "4", Course_score = 78 });
            course_jonatan.Add(new Courses { Id = "3", Course_name = "Introduction to control ", Course_points = "2", Course_score = 90 });
            course_jonatan.Add(new Courses { Id = "4", Course_name = "Introduction to programming ", Course_points = "2", Course_score = 77 });
            course_jonatan.Add(new Courses { Id = "5", Course_name = "OOP ", Course_points = "2", Course_score = 70 });
            course_jonatan.Add(new Courses { Id = "6", Course_name = "Advanced programming ", Course_points = "3", Course_score = 74 });
            course_jonatan.Add(new Courses { Id = "7", Course_name = "table tennis", Course_points = "1", Course_score = 87 });
            //****************************************************************************************************************************8
            List<Courses> course_david = new List<Courses>();

            course_david.Add(new Courses { Id = "1", Course_name = "Hedva 1 ", Course_points = "4", Course_score = 98 });
            course_david.Add(new Courses { Id = "2", Course_name = "Physics 1 ", Course_points = "4", Course_score = 76 });
            course_david.Add(new Courses { Id = "3", Course_name = "Introduction to control ", Course_points = "2", Course_score = 90 });
            course_david.Add(new Courses { Id = "4", Course_name = "Introduction to programming ", Course_points = "2", Course_score = 100 });
            course_david.Add(new Courses { Id = "5", Course_name = "OOP ", Course_points = "2", Course_score = 70 });
            course_david.Add(new Courses { Id = "6", Course_name = "Advanced programming ", Course_points = "3", Course_score = 74 });
            course_david.Add(new Courses { Id = "7", Course_name = "table tennis", Course_points = "1", Course_score = 87 });

            Students.Add(new Student { id = "1", First_name = "Jonatan", Last_name = "Elkabethz", courses = course_jonatan });
            Students.Add(new Student { id = "2", First_name = "david", Last_name = "Elkabethz", courses = course_david });
        }
        //this function does get and sets for the _students variable
        public BindableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        //this function does get and sets for the _selected student variable

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value;
                //call to calculte average function 
                CalculateAverage();
                //change the selected student in the gui window
                NotifyOfPropertyChange(() => Students);


            }
        }
        //this function does get and sets for Mean variable

        public double bestAverageTen
        {
            get { return _avg; }
            set
            {
                //set the new average value
                _avg = value;
                //notify when there is a change for the average. changing the average in the gui window
                NotifyOfPropertyChange(() => bestAverageTen);
            }
        }
        // get best average courses
        public List<string> BestAverageCourses
        {
            get { return _bestAverageCourses; }
            set
            {
                _bestAverageCourses = value;
                NotifyOfPropertyChange(() => BestAverageCourses);
            }
        }
        // Internal function that ask from the seleted student object to calculte his best average from the ten points courses
        private void CalculateAverage()
        {
            if (SelectedStudent != null && SelectedStudent.courses.Count > 0)
            {
                bestAverageTen = SelectedStudent.CalculateBestAverageForTotalPoints();
                BestAverageCourses = SelectedStudent.GetBestAverageCourses();

            }
            else
            {
                bestAverageTen = 0;
                //initiallize empty list of courses
                BestAverageCourses = new List<string>();

            }
        }


    }
}
