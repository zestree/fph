public class SnailSolution
{
   public static int[] Snail(int[][] array)
   {
       // Directions: RIGHT is 0, DOWN is 1, LEFT is 2, UP is 3
       int[] result = new int[array.Length*array[0].Length];
            int direction = 0;
            int topLimit = 0;
            int rightLimit = array[0].Length-1;
            int bottomLimit = array.Length-1;
            int leftLimit = 0;
            int xPos = 0;
            int yPos = 0;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[yPos][xPos];
                switch (direction)
                {
                    case 0:
                        if (xPos < rightLimit)
                        {
                            xPos++;
                        }
                        else
                        {
                            topLimit++;
                            yPos++;
                            direction = 1;
                        }
                        break;
                    case 1:
                        if (yPos < bottomLimit)
                        {
                            yPos++;
                        }
                        else
                        {
                            rightLimit--;
                            xPos--;
                            direction = 2;
                        }
                        break;
                    case 2:
                        if (xPos > leftLimit)
                        {
                            xPos--;
                        }
                        else
                        {
                            bottomLimit--;
                            yPos--;
                            direction = 3;
                        }
                        break;
                    case 3:
                        if (yPos > topLimit)
                        {
                            yPos--;
                        }
                        else
                        {
                            leftLimit++;
                            xPos++;
                            direction = 0;
                        }
                        break;
                }
            }
            return result;
        }
}