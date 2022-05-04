using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XY57LW_HFT_2021221.Models;

namespace WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {

        static Random r = new Random();

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Student> Students{ get; set; }
        public RestCollection<Measurement> Measurements { get; set; }
        public RestCollection<School> Schools { get; set; }

        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        public ICommand CreateSchoolCommand { get; set; }
        public ICommand DeleteSchoolCommand { get; set; }
        public ICommand UpdateSchoolCommand { get; set; }
        public ICommand CreateMeasurementCommand { get; set; }
        public ICommand DeleteMeasurementCommand { get; set; }
        public ICommand UpdateMeasurementCommand { get; set; }

        private Student selectedStudent;

        private School selectedSchool;

        private Measurement selectedMeasurement;

        public Measurement SelectedMeasurement
        {
            get { return selectedMeasurement; }
            set
            {
                if (value != null)
                {
                    selectedMeasurement = new Measurement()
                    {
                        ID = value.ID,
                        BMI = value.BMI,
                        Pushup = value.Pushup,
                        Situp = value.Situp,
                        Jump = value.Jump,
                        Bodyfat = value.Bodyfat

                    };
                    OnPropertyChanged();
                    (DeleteMeasurementCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public School SelectedSchool 
        {
            get { return selectedSchool; }
            set
            {
                if (value != null)
                {
                    selectedSchool = new School()
                    {
                        SchID = value.SchID,
                        Name = value.Name,
                        Headmaster = value.Name,
                        Phone = value.Phone,
                        Location = value.Location
                    };
                    OnPropertyChanged();
                    (DeleteSchoolCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        StudentID = value.StudentID,
                        Name = value.Name,
                        BirthDate = value.BirthDate,
                        MothersName = value.MothersName,
                        City = value.City,
                        SchoolID = value.SchoolID,
                        NetfitID = value.NetfitID
                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }            
        }
        
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:9712/", "student", "hub");
                Measurements = new RestCollection<Measurement>("http://localhost:9712/", "measurement", "hub");
                Schools = new RestCollection<School>("http://localhost:9712/", "school", "hub");
                int last = 0;
                CreateStudentCommand = new RelayCommand(() =>
                {

                    Measurements.Add(new Measurement()
                    {
                        Pushup = r.Next(5,99),
                        Situp = r.Next(5, 99)
                    });

                    last = Measurements.Last().ID + 1;

                    Students.Add(new Student()
                    {
                        Name = SelectedStudent.Name,
                        BirthDate = SelectedStudent.BirthDate,
                        MothersName = SelectedStudent.MothersName,
                        City = SelectedStudent.City,
                        SchoolID = SelectedStudent.SchoolID,
                        NetfitID = last
                    });
                });

                UpdateStudentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Students.Update(SelectedStudent);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(SelectedStudent.StudentID);
                },
                () =>
                {
                    return SelectedStudent != null;
                });
                SelectedStudent = new Student();

                CreateSchoolCommand = new RelayCommand(() =>
                {
                    Schools.Add(new School()
                    {
                        Name = SelectedSchool.Name,
                        Headmaster = SelectedSchool.Headmaster,
                        Location = SelectedSchool.Location,
                        Phone = SelectedSchool.Phone
                    });
                });

                UpdateSchoolCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Schools.Update(SelectedSchool);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSchoolCommand = new RelayCommand(() =>
                {
                    Schools.Delete(SelectedSchool.SchID);
                },
                () =>
                {
                    return SelectedSchool != null;
                });
                SelectedSchool = new School();

                CreateMeasurementCommand = new RelayCommand(() =>
                {
                    Measurements.Add(new Measurement()
                    {
                        BMI = SelectedMeasurement.BMI,
                        Pushup = SelectedMeasurement.Pushup,
                        Situp = SelectedMeasurement.Situp,
                        Jump = SelectedMeasurement.Jump,
                        Bodyfat = SelectedMeasurement.Bodyfat
                    });
                });

                UpdateMeasurementCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Measurements.Update(SelectedMeasurement);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteMeasurementCommand = new RelayCommand(() =>
                {
                    Measurements.Delete(SelectedMeasurement.ID);
                },
                () =>
                {
                    return SelectedMeasurement != null;
                });
                SelectedMeasurement = new Measurement();
            }
        }
    }
}
