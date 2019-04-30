using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Bdhavior : MonoBehaviour
{
    private void OnCollisionStay(Collision col)
    {
        Vector2 mouse_position = Camera.main.WorldToScreenPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouse_position, Vector2.zero, 0f);

        Debug.Log("colision");

        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
