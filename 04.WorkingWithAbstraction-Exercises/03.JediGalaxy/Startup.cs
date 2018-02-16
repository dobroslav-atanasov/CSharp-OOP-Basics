namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = FillMatrix(row, col);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoPosition = command.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilPosition = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilPosition[0];
                int evilCol = evilPosition[1];
                ClearEvilPosition(matrix, evilRow, evilCol);


                int ivoRow = ivoPosition[0];
                int ivoCol = ivoPosition[1];
                sum += CalculateIvoPoints(matrix, ivoRow, ivoCol);
                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static long CalculateIvoPoints(int[,] matrix, int ivoRow, int ivoCol)
        {
            long sum = 0;
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
            return sum;
        }

        private static void ClearEvilPosition(int[,] matrix, int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static int[,] FillMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            int value = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}