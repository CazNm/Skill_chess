using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainsystem : MonoBehaviour
{

    public GameObject[] MainSystem_Ui;
    public GameObject[] Units;
    // Start is called before the first frame updateGam

    GameObject Move_button;
    GameObject My_king;
    GameObject pawn;
    GameObject Hero;

    void Start()
    {
        My_king = Units[0];
        pawn = Units[1];
        Hero = Units[2];

        GameObject King_R = Instantiate(My_king, new Vector3(0f, 0f, 0f), Quaternion.identity);
        /*in this line have to spwan some pawns in board but now i have to testing about how to make main system of king the main unit,
         so we have to add more unit but consider about hero spawn system it will be diffrent any other units*/
    }

    // Update is called once per frame
    private void Update()
    {
        select_unit(0);
    }

    private void FixedUpdate()
    {
        
    }

    private void select_unit(int unit_type)
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouse_pos, Vector2.zero, 0f);
        GameObject selected_unit = Units[unit_type];

        if (Input.GetMouseButtonDown(0))//0 is left click 1 is right click 2 is mouse button 3
        {
            Collider2D col;

            Debug.Log(hit.collider);
            if (hit.collider != null)
            {

            }
        }
    }
}
