using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGroundQueue 
{
    private Queue<GroundBase> gameQueue = null;

        public RandomGroundQueue(GameMaze gameMaze)
        {
            GroundBase[] groundBase = gameMaze.CreateArray();

            Randomize(groundBase);

            gameQueue = new Queue<GroundBase>(groundBase);
        }

        public GroundBase GetNextGroundBase()
        {
            return(gameQueue.Dequeue());
        }

        public void ReturnGroundBase(GroundBase groundBase)
        {
            gameQueue.Enqueue(groundBase);
        }

        private void Randomize(GroundBase[] groundBase) 
        {
            int size = groundBase.Length;

            for (int count = 0; count < size; count++)
            {
                int index1 = UnityEngine.Random.Range(0, size);
                int index2 = UnityEngine.Random.Range(0, size);

                if (index1 != index2) 
                {
                    GroundBase temp = groundBase[index1];
                    groundBase[index1] = groundBase[index2];
                    groundBase[index2] = temp;
                }
            }
        }
}
