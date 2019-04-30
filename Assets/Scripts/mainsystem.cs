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
    private int unit_clicked;

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
      
        

        unit_clicked = 0;
        
        /*in this line have to spwan some pawns in board but now i have to testing about how to make main system of king the main unit,
         so we have to add more unit but consider about hero spawn system it will be diffrent any other units*/
    }

    // Update is called once per frame
    //유동 프레임 기기의 성능에 따라서 FPS가 변동된다. 직접적으로 화면에 상호작용하는 코드를 적으면 좋다. 
    //반면 속도와 같은 물리적 데이터를 적으면 컴퓨터 성능에 따라서 게임의 속도가 달라 질 수 있으므로 계산적인 데이터는 지양하자
    //랜더링 관련 코드.

    private void Update() 
    {
        select_unit();
        //attack.onClick.AddListener(call);
    }

    //고정 프레임, 랜더링하는 프레임과는 차이가 있으므로 게임상으로 클릭하는 것과 같은 
    //직접적 상호작용은 중복클릭과 같은 오류를 발생시킬 수 있으니 지양하도록 하자
    //물리적인 위치나 속도 계산적인 코드.

    private void FixedUpdate() 
    {
        
    }

    private void num_piece()
    {
        for(int x = 0; x < 20; x++)
        {
            p1_pawns[x].GetComponent<UnitStatus>().piece_no = x;
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
                Vector2 unit_pos = hit.collider.GetComponent<UnitStatus>().unitpos;
                button_ui(unit_pos, unit_clicked);
                unit_clicked = 1;
            }
            else
            {
                Debug.Log("no pieces");
                for (int x = 0; x < 20; x++)
                {
                    if (p1_pawns[x] == null)
                    {
                        continue;
                    }
                    p1_pawns[x].GetComponent<UnitStatus>().clicked = 0;            
                    unit_clicked = 0;
                    

                }
            }
        }
    }

    private void button_ui(Vector2 unit_position, int clicked_unit)
    {
        if (clicked_unit == 0)
        {
            attack_order = Instantiate(MainSystem_Ui[0], new Vector3(unit_position.x + 120.0f, unit_position.y + 50.0f, 0f), Quaternion.identity);
            attack_order.transform.SetParent(GameObject.Find("Canvas").transform);

            move_order = Instantiate(MainSystem_Ui[1], new Vector3(unit_position.x + 120.0f, unit_position.y + 100.0f, 0f), Quaternion.identity);
            move_order.transform.SetParent(GameObject.Find("Canvas").transform);

            //attack = attack_order.GetComponent<Button>();
            //move = move_order.GetComponent<Button>();
        }
        else
        {
            
            return;
        }

        
    }
}
