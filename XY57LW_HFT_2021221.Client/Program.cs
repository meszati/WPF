using ConsoleTools;
using System;
using System.Collections.Generic;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:9712");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(10000);

            var schoolMenu = new ConsoleMenu(args, level: 1)
                            .Add("List Schools", () => List<School>("school"))
                            .Add("Add School", () => AddSchool())
                            .Add("Update School", () => UpdateSchool())
                            .Add("Delete School", () => Delete<School>("school"))
                            .Add("Exit", ConsoleMenu.Close);

            var studentMenu = new ConsoleMenu(args, level: 1)
                            .Add("List Students", () => List<Student>("student"))
                            .Add("Add Student", () => AddStudent())
                            .Add("Update Student", () => UpdateStudent())
                            .Add("Delete Student", () => Delete<Student>("student"))
                            .Add("Exit", ConsoleMenu.Close);

            var measurementMenu = new ConsoleMenu(args, level: 1)
                            .Add("List the measurements of students", () => List<Measurement>("measurement"))
                            .Add("Add a measurement to a student", () => AddMeasurement())
                            .Add("Update a students measurement", () => UpdateMeasurement())
                            .Add("Delete a students measurement", () => Delete<Measurement>("measurement"))
                            .Add("Exit", ConsoleMenu.Close);

            var noncrudMenu = new ConsoleMenu(args, level: 1)
                .Add("ShowStudentsCountBySchool", () => StudentsCountBySchool())
                .Add("ShowStudentsBySchool", () => StudentsBySchool())
                .Add("ShowStudentsOver10PushUps", () => StudentsOver10PushUps())
                .Add("ShowAVGPushUpBySchools", () => AVGPushUpBySchools())
                .Add("ShowMostSitUps", () => MostSitUps())
                .Add("ShowBiggestBMI", () => BiggestBMI())
                .Add("ShowLeastBodyfat", () => LeastBodyfat())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                                       .Add("School", schoolMenu.Show)
                                       .Add("Students", studentMenu.Show)
                                       .Add("Measurements", measurementMenu.Show)
                                       .Add("Noncruds", noncrudMenu.Show)
                                       .Add("Exit", () => Environment.Exit(0)) //kilepes
              .Configure(config =>
              {
                  config.Selector = ">> ";
                  config.EnableFilter = false;
                  config.ClearConsole = true;
                  config.Title = "Main menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = false;
              });

            menu.Show();
        }

        static void List<T>(string path)
        {
            MenuLayout("List");
            var List = rest.Get<T>(path);
            foreach (var item in List)
            {
                Console.WriteLine(item + "\n");
            }
            Console.ReadLine();
        }

        static void AddSchool()
        {
            MenuLayout("Add School");
            Console.WriteLine("School name: ");
            string schoolName = Console.ReadLine();
            Console.WriteLine("Headmaster: ");
            string hm = Console.ReadLine();
            rest.Post<School>(new School { Name = schoolName, Headmaster = hm }, "school");
            Console.WriteLine("School has been added.");
            Console.ReadLine();
        }

        static void AddStudent()
        {
            MenuLayout("Add student");
            Console.WriteLine("Student name: ");
            string name = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Date of birth: ");
            DateTime birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Mothers name: ");
            string mothersName = Console.ReadLine();
            Console.WriteLine("School id: ");
            int schoolId = int.Parse(Console.ReadLine());
            Console.WriteLine("Netfit id: ");
            int netfitId = int.Parse(Console.ReadLine());
            rest.Post<Student>(new Student { Name = name, City = city, BirthDate = birth, MothersName = mothersName, SchoolID = schoolId, NetfitID = netfitId }, "student");
            Console.WriteLine("Student has been added.");
            Console.ReadLine();
        }

        static void AddMeasurement()
        {
            MenuLayout("Add measurement");
            Console.WriteLine("BMI: ");
            double bmi = double.Parse(Console.ReadLine());
            Console.WriteLine("Pushup: ");
            int pushup = int.Parse(Console.ReadLine());
            Console.WriteLine("Situp: ");
            int situp = int.Parse(Console.ReadLine());
            Console.WriteLine("Jump: ");
            int jump = int.Parse(Console.ReadLine());
            Console.WriteLine("Bodyfat: ");
            double boddyfat = double.Parse(Console.ReadLine());
            rest.Post<Measurement>(new Measurement { BMI = bmi, Pushup = pushup, Situp = situp, Jump = jump, Bodyfat = boddyfat }, "measurement");
            Console.WriteLine("Measurement has been added.");
            Console.ReadLine();
        }

        static void UpdateSchool()
        {
            MenuLayout("Update School");
            Console.Write("Enter the Id: ");
            int id = int.Parse(Console.ReadLine());
            var school = rest.Get<School>("school");
            var newSchool = new School();
            foreach (var item in school)
            {
                if (item.SchID == id)
                {
                    newSchool = item;
                    break;
                }
            }
            if (newSchool.SchID == id)
            {
                Console.WriteLine("School name: ");
                string schoolName = Console.ReadLine();
                Console.WriteLine("Headmaster: ");
                string hm = Console.ReadLine();
                newSchool.Name = schoolName;
                newSchool.Headmaster = hm;
                rest.Put<School>(newSchool, "school");
            }
            else
            {
                throw new IndexOutOfRangeException($"There is no {id} in the School database!");
            }
        }

        static void UpdateStudent()
        {
            MenuLayout("Update Student");
            Console.Write("Enter the Id: ");
            int id = int.Parse(Console.ReadLine());
            var student = rest.Get<Student>("car");
            var newStudent = new Student();
            foreach (var item in student)
            {
                if (item.StudentID == id)
                {
                    newStudent = item;
                    break;
                }
            }
            if (newStudent.StudentID == id)
            {
                Console.Clear();
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("City: ");
                string city = Console.ReadLine();
                Console.WriteLine("Date of birth: ");
                DateTime birthdate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Mothers name: ");
                string mothersName = Console.ReadLine();
                Console.WriteLine("School id:");
                int schoolId = int.Parse(Console.ReadLine());
                Console.WriteLine("Netfit id:");
                int netfitId = int.Parse(Console.ReadLine());
                newStudent.Name = name;
                newStudent.City = city;
                newStudent.BirthDate = birthdate;
                newStudent.MothersName = mothersName;
                newStudent.SchoolID = schoolId;
                newStudent.NetfitID = netfitId;
                rest.Put<Student>(newStudent, "student");
            }
            else
            {
                throw new IndexOutOfRangeException($"There is no {id} in the Cars database!");
            }
        }

        static void UpdateMeasurement()
        {
            MenuLayout("Update measurement");
            Console.Write("Enter the Id: ");
            int id = int.Parse(Console.ReadLine());
            var measurement = rest.Get<Measurement>("measurement");
            var newMeasurement = new Measurement();
            foreach (var item in measurement)
            {
                if (item.ID == id)
                {
                    newMeasurement = item;
                    break;
                }
            }
            if (newMeasurement.ID == id)
            {
                Console.Clear();
                Console.WriteLine("BMI: ");
                double bmi = double.Parse(Console.ReadLine());
                Console.WriteLine("Pushup: ");
                int pushup = int.Parse(Console.ReadLine());
                Console.WriteLine("Situp: ");
                int situp = int.Parse(Console.ReadLine());
                Console.WriteLine("Jump: ");
                int jump = int.Parse(Console.ReadLine());
                Console.WriteLine("Bodyfat: ");
                double bodyfat = double.Parse(Console.ReadLine());
                newMeasurement.BMI = bmi;
                newMeasurement.Pushup = pushup;
                newMeasurement.Situp = situp;
                newMeasurement.Jump = jump;
                newMeasurement.Bodyfat = bodyfat;
                rest.Put<Measurement>(newMeasurement, "measurement");
            }
            else
            {
                throw new IndexOutOfRangeException($"There is no {id} in the Stocks database!");
            }
        }

        static void Delete<T>(string path)
        {
            MenuLayout("Delete");
            Console.WriteLine("Enter the id please: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, path);
        }

        static void StudentsCountBySchool()
        {
            Console.Clear();
            Console.WriteLine("StudentsCountBySchool");
            var List = rest.Get<KeyValuePair<string, int>>("stat/StudentsCountBySchool");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>School: " + item.Key + "\n\tCount: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void StudentsOver10PushUps()
        {
            Console.Clear();
            Console.WriteLine("StudentsOver10PushUps");
            var List = rest.Get<KeyValuePair<string, int>>("stat/StudentsOver10PushUps");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>School: " + item.Key + "\n\tCount: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void StudentsBySchool()
        {
            Console.Clear();
            Console.WriteLine("StudentsBySchool");
            var List = rest.Get<KeyValuePair<string, int>>("stat/StudentsBySchool");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>Brand: " + item.Key + "\n\tCount: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void AVGPushUpBySchools()
        {
            Console.Clear();
            Console.WriteLine("AVGPushUpBySchools");
            var List = rest.Get<KeyValuePair<string, int>>("stat/AVGPushUpBySchools");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>School: " + item.Key + "\n\tAVG Pushups: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void BiggestBMI()
        {
            Console.Clear();
            Console.WriteLine("BiggestBMI");
            var List = rest.Get<KeyValuePair<string, double>>("stat/BiggestBMI");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>Student: " + item.Key + "\n\tBMI: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void MostSitUps()
        {
            Console.Clear();
            Console.WriteLine("MostSitUps");
            var List = rest.Get<KeyValuePair<string, int>>("stat/MostSitUps");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>Student: " + item.Key + "\n\tSitups: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void LeastBodyfat()
        {
            Console.Clear();
            Console.WriteLine("LeastBodyfat");
            var List = rest.Get<KeyValuePair<string, double>>("stat/LeastBodyfat");
            foreach (var item in List)
            {
                Console.WriteLine("\t>>Student: " + item.Key + "\n\tBodyfat: " + item.Value + "\n");
            }
            Console.ReadLine();
        }

        static void MenuLayout(string menutype)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth + menutype.Length) / 2, Console.CursorTop);
            Console.WriteLine(menutype + "\n");
        }
    }
}
