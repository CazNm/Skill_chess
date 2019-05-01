using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class mainsystem : MonoBehaviour
{

    public GameObject[] MainSystem_Ui;
    public GameObject[] Units;
    public GameObject[] EnemyUnits;
    public GameObject[] p1_pawns = new GameObject[20]; // this list is to management my pieces in board.

    private int my_turn; // if my turn then this int will be 0, oppenent turn this will be 1
    public int unit_clicked;

    public GameObject[] Save_ui = new GameObject[2];
    public GameObject p1_king;
    public GameObject p1_hero;

    GameObject Move_button;
    GameObject My_king;
    GameObject King_R;
    GameObject pawn;
    GameObject Hero;

    GameObject attack_order;
    GameObject move_order;

    Button attack;
    Button move;
    public UnityAction call;

    void Start()
    {
        My_king = Units[0];
        pawn = Units[1];
        Hero = Units[2];

        King_R = Instantiate(My_king, new Vector3(0f, 0f, 0f), Quaternion.identity);
        p1_king = King_R;
        unit_clicked = 0;
        
        /*in this line have to spwan some pawns in board but now i have to testing about how to make main system of king the main unit,
         so we have to add more unit but consider about hero spawn system it will be diffrent any other units*/
    }

    private void Update()
    {
        select_unit();
        //attack.onClick.AddListener(call);
    }

    private void num_piece()
    {
        for(int x = 0; x < 20; x++)
        {
            p1_pawns[x].GetComponent<UnitStatus>().piece_no = x;
        }
        
    }

    private bool select_unit()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // this one get the position of mousepointer in screen 1920*1080
        RaycastHit2D hit = Physics2D.Raycast(mouse_pos, Vector2.zero, 0f); //this one shoot ray for find the object which one collided with Ray

        if (Input.GetMouseButtonDown(0))//0 is left click 1 is right click 2 is mouse button 3
        {
            //if (hit.collider.tag.Equals("Ord_button")) { unit_clicked = 2; }
            
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<UnitStatus>().clicked == 1) unit_clicked = 2;
                hit.collider.GetComponent<UnitStatus>().clicked = 1;
                Debug.Log("unit_clicked"); // i have to setting movement and attack system by other script
                Vector2 unit_pos = hit.collider.GetComponent<UnitStatus>().unitpos;
                button_ui(unit_pos, unit_clicked);
                unit_clicked = 1;
                return true;
            }
            else
            {
                Debug.Log("no pieces");
                button_ui(Vector2.zero, 1);
                p1_king.GetComponent<UnitStatus>().clicked = 0;
                for (int x = 0; x < 20; x++)
                {
                    if (p1_pawns[x] == null)
                    {
                        continue;
                    }
                    p1_pawns[x].GetComponent<UnitStatus>().clicked = 0;
                    unit_clicked = 0;

                }
                unit_clicked = 0;
                return false;
            }
        }
        else return false;
    }

    private void button_ui(Vector2 unit_position, int clicked_unit)
    {
        if (clicked_unit == 0)
        {
            Debug.Log("ui setting");
            attack_order = Instantiate(MainSystem_Ui[0], new Vector3(unit_position.x + 120.0f, unit_position.y + 50.0f, 0f), Quaternion.identity);
            attack_order.transform.SetParent(GameObject.Find("Canvas").transform);
            Save_ui[0] = attack_order;

            move_order = Instantiate(MainSystem_Ui[1], new Vector3(unit_position.x + 120.0f, unit_position.y + 110.0f, 0f), Quaternion.identity);
            move_order.transform.SetParent(GameObject.Find("Canvas").transform);
            Save_ui[1] = move_order;

        }
        else if (clicked_unit == 2) return;
        else
        {
            Destroy(Save_ui[0]);
            Destroy(Save_ui[1]);
            Save_ui[0] = null;
            Save_ui[1] = null;
        }

        
    }
}
