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
        private Student _selectedStudent;
        private BindableCollection<Student> _students = new BindableCollection<Student>();
        private double _mean;

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
            //******************************************************************************************************************
            List<Courses> course_david = new List<Courses>();

            course_david.Add(new Courses { Id = "1", Course_name = "Hedva 1 ", Course_points = "4", Course_score = 98 });
            course_david.Add(new Courses { Id = "2", Course_name = "Physics 1 ", Course_points = "4", Course_score = 76 });
            course_david.Add(new Courses { Id = "3", Course_name = "Introduction to control ", Course_points = "2", Course_score = 90 });
            course_david.Add(new Courses { Id = "4", Course_name = "Introduction to programming ", Course_points = "2", Course_score = 77 });
            course_david.Add(new Courses { Id = "5", Course_name = "OOP ", Course_points = "2", Course_score = 70 });
            course_david.Add(new Courses { Id = "6", Course_name = "Advanced programming ", Course_points = "3", Course_score = 74 });
            course_david.Add(new Courses { Id = "7", Course_name = "table tennis", Course_points = "1", Course_score = 87 });

            Students.Add(new Student { id = "1", First_name = "Jonatan", Last_name = "Elkabethz", cources = course_jonatan });
            Students.Add(new Student { id = "2", First_name = "david", Last_name = "Elkabethz", cources = course_david });

            
        }
        public BindableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
       

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value;
                CalculateMean();
                NotifyOfPropertyChange(() => Students);


            }
        }
        public double Mean
        {
            get { return _mean; }
            set
            {
                _mean = value;
                NotifyOfPropertyChange(() => Mean);
            }
        }
        
        private void CalculateMean()
        {
            if (SelectedStudent != null && SelectedStudent.cources.Count > 0)
            {
                Mean = SelectedStudent.CalculateBestAverageForTotalPoints();
            }
            else
            {
                Mean = 0;
            }
        }


    }
}
