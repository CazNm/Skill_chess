using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : MonoBehaviour
{

    public int M_health;
    public int C_health;
    public int C_shield;
    public int attack;
    public int attack_mode;
    public int movement;
    public int movement_mode;
    public int hand_limit;
    public int piece_no;
    public int clicked; // if this unit clicked 1 or not 0
    public GameObject[] stat_ui_list;

    private int render_int;
    private float test_position;
    private Transform Health;
    Transform King_position;

    Vector3 s_position;
    Vector2 King_vector;
    
    GameObject Health_bar;
    GameObject Health_bar_R;
    GameObject Health_contents;
    GameObject Health_contents_R;

    // Start is called before the first frame update
    void Start()
    {
        //We have to input data that in deck which player selected, But we have to make interface first so this time use inspector input data

        King_position = transform;
        King_vector = King_position.position;
        test_position = 0;

        s_position = new Vector3 (0f, 0f, 0f);

        render_int = 0;

        Health_bar = stat_ui_list[0];
        Health_contents = stat_ui_list[1];


    }

    void Health_condition(int mode)
    {
        Health_bar = stat_ui_list[0];

        if (mode == 0) // if mode = 0 then render Health_bar prefeb
        {
            GameObject render_health_bar = Instantiate(Health_bar, new Vector3(King_vector.x, King_vector.y, 0f), Quaternion.identity);
        }


    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        King_vector = new Vector2 (0f, 0f);
        
        transform.position = new Vector3(King_vector.x, King_vector.y, 0f);
        if (render_int == 0)
        {
            Health_bar_R = Instantiate(Health_bar, new Vector3(King_vector.x, King_vector.y + 1.27f, 0f), Quaternion.identity);
            Health = new GameObject("health").transform;
            s_position = Health_bar_R.transform.position;

            Debug.Log(Health_bar_R.transform.position.x);

            for (int x = 0; x < 100; x++)
            {
                Health_contents_R = Instantiate(Health_contents, new Vector3(King_vector.x - 1.87f + (x * 0.0377f), King_vector.y, 0f), Quaternion.identity);
                Health_contents_R.transform.SetParent(Health);
            }


            //Health_bar_R.transform.position = new Vector3(King_vector.x, King_vector.y + 1.27f, 0f);

            render_int = 1;
        }
        

        //Debug.Log(King_vector.y - s_position[1]);
        Health_bar_R.transform.position = new Vector3(King_vector.x, King_vector.y + 1.27f, 0f);
        Health.transform.position = new Vector3 ( King_vector.x - s_position.x , King_vector.y - s_position.y + 2.54f);


        //test_position += 0.001f;
        
    }
}

