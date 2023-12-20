using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1_sem_2_kurs_oop
{
    public partial class MyMatrix
    {
        private double[,] matrix;

        public MyMatrix(MyMatrix other)
        {
            int height = other.Height;
            int width = other.Width;
            matrix = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = other[i, j];
                }
            }
        }

        public MyMatrix(double[,] data)
        {
            int height = data.GetLength(1);
            int width = data.GetLength(0);
            matrix = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = data[i, j];
                }
            }
        }
        //
        public MyMatrix(double[][] jaggedArray)
        {
            int height = jaggedArray.Length;
            int width = 0;

            for (int i = 0; i < height; i++)
            {
                int rowWidth = jaggedArray[i].Length;
                if (rowWidth > width)
                {
                    width = rowWidth;
                }
            }

            matrix = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j < jaggedArray[i].Length)
                    {
                        matrix[i, j] = jaggedArray[i][j];
                    }
                    else
                    {
                        matrix[i, j] = 0.0; // Якщо рядок коротший, заповнюємо нулями.
                    }
                }
            }
        }
        //
        public MyMatrix(string[] stringData)
        {
            int height = stringData.Length;
            int width = 0;
            for (int i = 0; i < height; i++)
            {
                string[] row = stringData[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (row.Length > width)
                {
                    width = row.Length;
                }
            }

            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] row = stringData[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < width; j++)
                {
                    if (j < row.Length)
                    {
                        matrix[i, j] = double.Parse(row[j]);
                    }
                    else
                    {
                        matrix[i, j] = 0.0;
                    }
                }
            }
        }
        //
        public MyMatrix(string matrixString)
        {
            string[] rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int height = rows.Length;
            int width = 0; 

            for (int i = 0; i < height; i++)
            {
                string[] row = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (row.Length > width)
                {
                    width = row.Length;
                }
            }

            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] row = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < width; j++)
                {
                    if (j < row.Length)
                    {
                        matrix[i, j] = double.Parse(row[j]);
                    }
                    else
                    {
                        matrix[i, j] = 0.0; 
                    }
                }
            }
        }
        public int Height => matrix.GetLength(0);
        public int Width => matrix.GetLength(1);

        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }

        public double getValueAt(int row, int col)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
            {
                throw new IndexOutOfRangeException("Invalid row or column index.");
            }

            return matrix[row, col];
        }

        public void setValueAt(int row, int col, double value)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
            {
                throw new IndexOutOfRangeException("Invalid row or column index.");
            }

            matrix[row, col] = value;
        }

        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, GetMatrixRows());
        }

        private string[] GetMatrixRows()
        {
            string[] rows = new string[Height];
            for (int i = 0; i < Height; i++)
            {
                string[] row = new string[Width];
                for (int j = 0; j < Width; j++)
                {
                    row[j] = matrix[i, j].ToString();
                }
                rows[i] = string.Join("\t", row); // " "
            }
            return rows;
        }
    }
}
