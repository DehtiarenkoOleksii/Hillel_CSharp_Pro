namespace Matrix
{
    #region Task_4
    //Створiть та опишiть клас «Матриця».
    //Виконайте перевантаження

    //+ (для додавання матриць),
    //– (для віднімання матриць).
    //* (множення матриць одна на одну, множення матриці на число),
    //== (перевірка матриць на рівність),
    //!= і Equals.

    //Використовуйте механізм властивостей полів класу і механізм індексаторів.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 3);
            Matrix matrix2 = new Matrix(3, 3);
            Matrix matrix3 = new Matrix(2, 3);
            Matrix matrix4 = new Matrix(3, 3);

            matrix1.Fill(1);
            matrix2.Fill(2);
            matrix3.Fill(3);
            matrix4.Fill(1);

            Matrix matrixAdd = matrix1 + matrix2;
            Console.WriteLine("\n Adding");
            matrixAdd.Print();

            Matrix matrixSubtract = matrix1 - matrix2;
            Console.WriteLine("\n Subtract");
            matrixSubtract.Print();

            Matrix matrixesMultiply = matrix3 * matrix1;
            Console.WriteLine("\n matrixesMultiply");
            matrixesMultiply.Print();

            Matrix matrixMultiplyNumber = matrix1 * 2;
            Console.WriteLine("\n matrixMultiplyNumber");
            matrixMultiplyNumber.Print();

            
            Console.WriteLine($"Are matrix1 and matrix1 equal ? - {matrix1.Equals(matrix2)}");
            Console.WriteLine($"Are matrix1 and matrix1 equal ? - {matrix1.Equals(matrix4)}");
        }
    }
}
