namespace _18_10_25_part_1_HW
{
    internal class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j], 3} ");
                }
                Console.WriteLine();
            }
        }

        static void Task4()
        {
            int[,] matrix = new int[5,5];
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(-100, 101);
                }
            }

            int minVal = matrix[0, 0];
            int maxVal = matrix[0, 0];
            int minElI = 0, minElJ = 0;
            int maxElI = 0, maxElJ = 0;

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minElI = i;
                        minElJ = j;
                    }
                    if( matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxElI = i;
                        maxElJ = j;
                    }
                }
            }
            int startI, startJ, endI, endJ;
            if (minElI < maxElI || (minElI == maxElI && minElJ < maxElJ))
            {
                startI = minElI;
                startJ = minElJ;
                endI = maxElI;
                endJ = maxElJ;
            }
            else
            {
                startI = maxElI;
                startJ = maxElJ;
                endI = minElI;
                endJ = minElJ;
            }

            int answSum = 0;
            for (int i = startI; i <= endI; ++i)
            {
                for (int j = (i == startI ? startJ : 0); j <= (i == endI ? endJ : matrix.GetLength(1)-1); ++j)
                {
                    answSum += matrix[i, j];
                }
            }
            PrintMatrix(matrix);
            Console.WriteLine($"Sum between [{startI},{startJ}] and [{endI},{endJ}]: {answSum}");

        }


        static void Task5()
        {
            int[,] matrix = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(-100, 101);
                }
            }


            int minEl = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minEl)
                        minEl = matrix[i, j];
                }
            }

            int countDif5 = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (MathF.Abs(matrix[i, j] - minEl) >= 5)
                        countDif5++;
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine($"Count elements that diferent for 5 from min element {minEl} is: {countDif5}");

        }

        static void Main(string[] args)
        {
            Task4();
            Task5();
        }
    }
}
