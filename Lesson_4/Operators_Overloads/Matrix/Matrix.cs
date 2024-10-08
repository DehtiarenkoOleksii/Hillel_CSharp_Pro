using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matrix
    {
        private int[,] data;
        public int Rows { get; }
        public int Columns { get; }

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("The values should be postive integers");

            Rows = rows;
            Columns = columns;
            data = new int[rows, columns];
        }

        public int this [int row, int column]
        {
            get => data[row, column];
            set => data[row, column] = value;
        }

        public static Matrix operator + (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new ArgumentException("Matrix sizes should be the same");
            
            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++) 
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }
        public static Matrix operator - (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new ArgumentException("Matrix sizes should be the same");

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] -  matrix2[i, j];
                }
            }
            return result;
        }
        public static Matrix operator * (Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows && matrix2.Columns != matrix1.Rows)
                throw new ArgumentException("Matrix1 Columns should be equal to the Matrix2 Rows");

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;

                }
            }
            return result;
        }

        public static Matrix operator * (Matrix matrix, int number)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }

        public static bool operator == (Matrix matrix1, Matrix matrix2) => matrix1.Equals(matrix2);
        public static bool operator != (Matrix matrix1, Matrix matrix2) => !matrix1.Equals(matrix2);

        public override bool Equals(object obj)
        {
            Matrix other = (Matrix)obj;
            if (Rows != other.Rows || Columns != other.Columns)
                return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (data[i, j] != other.data[i, j])
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Rows);
            hash.Add(Columns);
            foreach (int value in data)
            {
                hash.Add(value);
            }
            return hash.ToHashCode();
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{data[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        // Not requiered but comfortable
        public void Fill(int value)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = value;
                }
            }
        }
    }

}
