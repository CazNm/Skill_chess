using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardpos : MonoBehaviour
{

    public Vector2[ , ] board_world_pos = new Vector2 [5,5];

    private void Start()
    {
        float plusX = 2.9f;
        float plusY = 2.2f;
        for(int y = 0; y < 5; y++)
        {
            for(int x = 0; x < 5; x++)
            {
                board_world_pos[x, y] = new Vector2(-5.75f + (x * 2.90f), 5.15f - (y * 2.20f));
            }
        }

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Debug.Log(board_world_pos[x, y]);
            }
        }

    }

    
}
