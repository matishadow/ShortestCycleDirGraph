namespace ShortestCycleDirGraph.Core
{
    public class Matrix<T>
    {
        public static T[,] Transpose(T[,] m)
        {
            int rows = m.GetLength(0);
            int columns = m.GetLength(1);

            var transposed = new T[columns,rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    transposed[j, i] = m[i, j];
                }
            }

            return transposed;
        }

        public static bool checkValidIncMatrix(sbyte[,] m)
        {
            bool valid = true;
            bool posOne = false, negOne = false;

            for (int i = 0; i < m.GetLength(0); i++)
            {
                if (m[i, 0] == 1) posOne = !posOne;
                if (m[i, 0] == -1) negOne = !negOne;
            }


            valid = posOne && negOne;
            return valid;
        }
    }
}