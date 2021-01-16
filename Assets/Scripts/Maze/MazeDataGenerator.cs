using System.Collections.Generic;
using UnityEngine;


//this class doesn't inherit from MonoBehaviour. It won't be directly used as a componen
public class MazeDataGenerator
{
    public float placementThreshold;    //  will be used by the data generation algorithm to determine whether a space is empty

    public MazeDataGenerator()
    {
        placementThreshold = .1f;                               
    }

    public int[,] FromDimensions(int sizeRows, int sizeCols)    // called 
    {
        int[,] maze = new int[sizeRows, sizeCols];

        // 
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = 0; i <= rMax; i++)
        {
            for (int j = 0; j <= cMax; j++)
            {
                //wall in the borders
                if (i == 0 || j == 0 || i == rMax || j == cMax)
                {
                    maze[i, j] = 1;
                }


                else if (i % 2 == 0 && j % 2 == 0)
                {
                    if (Random.value > placementThreshold)
                    {
                        //  assigns 1 to both the current cell and a randomly chosen adjacent cel
                        maze[i, j] = 1;
                         
                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        maze[i + a, j + b] = 1;
                    }
                }
            }
        }


        return maze;
    }
}
