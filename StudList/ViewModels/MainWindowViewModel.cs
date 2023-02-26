using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using StudList.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Reactive;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static FileWork;

namespace StudList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public int count = 0;
        public string StudentFio = string.Empty;
        public ushort MarkFizika = 0;
        public ushort MarkMath = 0;
        public ushort MarkInformatick = 0;
        public ushort MarkFizra = 0;
        public Student[] Students { get => students; set => this.RaiseAndSetIfChanged(ref students, value); }
        private Student[] students;
        public string GetName { get => StudentFio; set { this.RaiseAndSetIfChanged(ref StudentFio, value); } }
        public ushort GetMarkFizika { get => MarkFizika; set { this.RaiseAndSetIfChanged(ref MarkFizika, value); } }
        public ushort GetMarkMath { get => MarkMath; set { this.RaiseAndSetIfChanged(ref MarkMath, value); } }
        public ushort GetMarkInformatick { get => MarkInformatick; set { this.RaiseAndSetIfChanged(ref MarkInformatick, value); } }
        public ushort GetMarkFizra { get => MarkFizra; set { this.RaiseAndSetIfChanged(ref MarkFizra, value); } }
        public double GetAverageFiz { get => AverageScore[0]; set { this.RaiseAndSetIfChanged(ref AverageScore[0], value); } }
        public double GetAverageMat { get => AverageScore[1]; set { this.RaiseAndSetIfChanged(ref AverageScore[1], value); } }
        public double GetAverageInf { get => AverageScore[2]; set { this.RaiseAndSetIfChanged(ref AverageScore[2], value); } }
        public double GetAverageFizr { get => AverageScore[3]; set { this.RaiseAndSetIfChanged(ref AverageScore[3], value); } }
        public string GetAverageColorFiz { get => AverageColor[0]; set { this.RaiseAndSetIfChanged(ref AverageColor[0], value); } }
        public string GetAverageColorMat { get => AverageColor[1]; set { this.RaiseAndSetIfChanged(ref AverageColor[1], value); } }
        public string GetAverageColorInf { get => AverageColor[2]; set { this.RaiseAndSetIfChanged(ref AverageColor[2], value); } }
        public string GetAverageColorFizr { get => AverageColor[3]; set { this.RaiseAndSetIfChanged(ref AverageColor[3], value); } }
        public string GetAverageAverageColor { get => AverageColor[4]; set { this.RaiseAndSetIfChanged(ref AverageColor[4], value); } }
        public double GeTLeg { get => AverageScore[4]; set { this.RaiseAndSetIfChanged(ref AverageScore[4], value); } }
        public double[] AverageScore = { 0, 0 , 0, 0, 0};
        public string[] AverageColor = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty};
        
        
        public MainWindowViewModel()
        {
            AddStudent = ReactiveCommand.Create(() =>
            {
                Student[] temp = students;
                count++;
                Array.Resize(ref temp, count);
                temp[temp.Length - 1] = new Student { fio = StudentFio, MarkFiz = MarkFizika, MarkInf = MarkInformatick, MarkMat = MarkMath, MarkFizr = MarkFizra, GetAverage = 0, GetAverageColor = string.Empty, GetFizikaColor = string.Empty, GetMathColor = string.Empty, GetInformatickColor = string.Empty, GetFizraColor = string.Empty };
                Students = temp;
                AllAverage(students);
            });
            DeliteStudent = ReactiveCommand.Create(() =>
            {
                Student[] temp = students;
                int how = -1;
                for( int i = 0; i < temp.Length; i++ )
                {
                    if(temp[i].FIO == StudentFio)
                    {
                        how = i;
                        break;
                    }
                }
                if (how != -1)
                {
                    for (int i = how; i < temp.Length - 1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    count--;
                    Array.Resize(ref temp, count);
                    Students = temp;
                    AllAverage(students);
                }
            });
            SaveStudent = ReactiveCommand.Create(() =>
            {
                if (students.Length != 0)
                {
                    BinFile<Student[]>.SaveInBinaryFormat(students, "Data.dat");
                }
            });
            LoadStudent = ReactiveCommand.Create(() =>
            {
                Students = BinFile<Student[]>.LoadFromBinaryFile("Data.dat");
                count = students.Length;
                AllAverage(students);
            });
        }
        public void AllAverage(Student[] students)
        {
            if (students.Length != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    AverageScore[i] = 0;
                }
                for (int j = 0; j < students.Length; j++)
                {
                    GetAverageFiz += students[j].MarkFizika;
                    GetAverageMat += students[j].MarkMath;
                    GetAverageInf += students[j].MarkInformatick;
                    GetAverageFizr += students[j].MarkFizra;
                }
                GetAverageFiz /= students.Length;
                GetAverageColorFiz = setColor(GetAverageFiz);
                GetAverageMat /= students.Length;
                GetAverageColorMat = setColor(GetAverageMat);
                GetAverageInf /= students.Length;
                GetAverageColorInf = setColor(GetAverageInf);
                GetAverageFizr /= students.Length;
                GetAverageColorFizr = setColor(GetAverageFizr);
                GeTLeg = (GetAverageFizr + GetAverageInf + GetAverageMat + GetAverageFiz) / 4.0;
                GetAverageAverageColor = setColor(GeTLeg);
            }
            else
            {
                GetAverageFiz = 0;
                GetAverageMat = 0;
                GetAverageInf = 0;
                GetAverageFizr = 0;
                GeTLeg = 0;
                GetAverageColorFiz = setColor(GetAverageFiz);
                GetAverageColorMat = setColor(GetAverageMat);
                GetAverageColorInf = setColor(GetAverageInf);
                GetAverageColorFizr = setColor(GetAverageFizr);
                GetAverageAverageColor = setColor(GeTLeg);
            }
        }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit, Unit> LoadStudent { get; }
        public ReactiveCommand<Unit, Unit> DeliteStudent { get; }
        public ReactiveCommand<Unit, Unit> SaveStudent { get; }
        public string setColor(double Num)
        {
            string res = string.Empty;
            if (Num < 1)
            {
                res = "Red";
            }
            if (Num >= 1 && Num <= 1.5)
            {
                res = "Yellow";
            }
            if (Num > 1.5)
            {
                res = "Green";
            }
            return res;
        }
    }
}
