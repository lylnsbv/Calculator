using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operators
    {
        public static int Add(int n1, int n2)
        {
            return n1 + n2;
        }
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static int Sub(int n1, int n2)
        {
            return n1 - n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static int Mult(int n1, int n2)
        {
            return n1 * n2;
        }
        public static double Mult(double n1, double n2)
        {
            return n1 * n2;
        }

        public static int Div(int n1, int n2)
        {
            return n1 / n2;
        }
        public static double Div(double n1, double n2)
        {
            return n1 / n2;
        }

        public static Double sqrt(int n1)
        {
            return Math.Sqrt(n1);
        }
        public static double sqrt(double n1)
        {
            return Math.Sqrt(n1);
        }

    }
}
