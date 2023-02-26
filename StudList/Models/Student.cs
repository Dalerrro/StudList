using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudList.Models
{
    [Serializable]
    public class Student
    {
        public string FIO = string.Empty;
        public ushort MarkFizika;
        public ushort MarkMath;
        public ushort MarkInformatick;
        public ushort MarkFizra;
        public double Average;
        public string AverageColor = string.Empty;
        public string FizikaColor = string.Empty;
        public string MathColor = string.Empty;
        public string InformatickColor = string.Empty;
        public string FizraColor = string.Empty;
        public string fio
        {
            get => FIO;
            set => FIO = value;
        }
        public ushort MarkFiz
        {
            get => MarkFizika;
            set => MarkFizika = value;
        }
        public ushort MarkMat
        {
            get => MarkMath;
            set => MarkMath = value;
        } 
        public ushort MarkInf
        {
            get => MarkInformatick; 
            set => MarkInformatick = value;
        }
        public ushort MarkFizr
        {
            get => MarkFizra; 
            set => MarkFizra = value;
        }
        public double GetAverage
        {
            get => Average;
            set => Average = (MarkFizika + MarkMath + MarkInformatick + MarkFizra) / 4.0;
        }
        public string GetAverageColor
        {
            get => AverageColor;
            set
            {
                if (GetAverage < 1)
                {
                    AverageColor = "Red";
                }
                if (GetAverage <= 1.5 && GetAverage >= 1)
                {
                    AverageColor = "Yellow";
                }
                if (GetAverage > 1.5)
                {
                    AverageColor = "Green";
                }
            }
        }
        public string GetFizikaColor
        {
            get => FizikaColor;
            set
            {
                if (MarkFizika == 0)
                {
                    FizikaColor = "Red";
                }
                if (MarkFizika == 1)
                {
                    FizikaColor = "Yellow";
                }
                if (MarkFizika == 2)
                {
                    FizikaColor = "Green";
                }
            }
        }
        public string GetMathColor
        {
            get => MathColor;
            set
            {
                if (MarkMath == 0)
                {
                    MathColor = "Red";
                }
                if (MarkMath == 1)
                {
                    MathColor = "Yellow";
                }
                if (MarkMath == 2)
                {
                    MathColor = "Green";
                }
            }
        }
        public string GetInformatickColor
        {
            get => InformatickColor;
            set
            {
                if (MarkInformatick == 0)
                {
                    InformatickColor = "Red";
                }
                if (MarkInformatick == 1)
                {
                    InformatickColor = "Yellow";
                }
                if (MarkInformatick == 2)
                {
                    InformatickColor = "Green";
                }
            }
        }
        public string GetFizraColor
        {
            get => FizraColor;
            set
            {
                if (MarkFizra == 0)
                {
                    FizraColor = "Red";
                }
                if (MarkFizra == 1)
                {
                    FizraColor = "Yellow";
                }
                if (MarkFizra == 2)
                {
                    FizraColor = "Green";
                }
            }
        }
    }
}
    

