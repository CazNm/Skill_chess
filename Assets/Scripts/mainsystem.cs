using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainsystem : MonoBehaviour
{

    public GameObject[] MainSystem_Ui;
    public GameObject[] Units;
    public GameObject[] EnemyUnits;
    public GameObject[] myBoard_unit = new GameObject[20]; // this list is to management my pieces in board.

    private int my_turn; // if my turn then this int will be 0, oppenent turn this will be 1

    GameObject Move_button;
    GameObject My_king;
    GameObject King_R;
    GameObject pawn;
    GameObject Hero;

    void Start()
    {
        My_king = Units[0];
        pawn = Units[1];
        Hero = Units[2];

        King_R = Instantiate(My_king, new Vector3(0f, 0f, 0f), Quaternion.identity);
        myBoard_unit[0] = King_R;
        
        /*in this line have to spwan some pawns in board but now i have to testing about how to make main system of king the main unit,
         so we have to add more unit but consider about hero spawn system it will be diffrent any other units*/
    }

    // Update is called once per frame
    private void Update()
    {
        select_unit();
    }

    private void FixedUpdate()
    {
        
    }

    private void num_piece()
    {
        for(int x = 0; x < 20; x++)
        {
            myBoard_unit[x].GetComponent<UnitStatus>().piece_no = x;
        }
        
    }

    private void select_unit()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // this one get the position of mousepointer in screen 1920*1080
        RaycastHit2D hit = Physics2D.Raycast(mouse_pos, Vector2.zero, 0f); //this one shoot ray for find the object which one collided with Ray

        if (Input.GetMouseButtonDown(0))//0 is left click 1 is right click 2 is mouse button 3
        {
            //Collider2D colider_name = King_R.GetComponent<Collider2D>(); // don't need this code any more
            //Debug.Log(colider_name.gameObject.name);

            if (hit.collider != null)
            {
                hit.collider.GetComponent<UnitStatus>().clicked = 1;
                Debug.Log("unit_clicked"); // i have to setting movement and attack system by other script
            }
            else
            {
                Debug.Log("no pieces");
                for (int x = 0; x < 20; x++)
                {
                    if (myBoard_unit[x] == null)
                    {
                        continue;
                    }
                    myBoard_unit[x].GetComponent<UnitStatus>().clicked = 0;
                }
            }
        }
    }
}
