using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1_sem_2_kurs_oop
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition.");
            }

            double[,] result = new double[a.Height, a.Width];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return new MyMatrix(result);
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
            {
                throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
            }

            double[,] result = new double[a.Height, b.Width];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Width; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return new MyMatrix(result);
        }

        private double[,] GetTransposedArray()
        {
            int height = Height;
            int width = Width;
            double[,] transposed = new double[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }

        public MyMatrix GetTransposedCopy()
        {
            double[,] transposed = GetTransposedArray();
            return new MyMatrix(transposed);
        }

        public void TransposeMe()
        {
            double[,] transposed = GetTransposedArray();
            matrix = transposed;
        }
    }
}
