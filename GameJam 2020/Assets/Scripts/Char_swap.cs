using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_swap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player_Small, Player_Medium, Player_Large, Camera_pos;
    public int Player_Select;
    private Vector3 Player_Pos;
    private Quaternion Player_Rot;
    public Vector3 cur_Pos;

    public Player_movement PM_Script_S;
    public Player_movement_Medium PM_Script_M;
    public Player_movement_Medium PM_Script_L;

    void Start()
    {
        Player_Select = 1;
        Player_Small = GameObject.Find("Player_Small");
        Player_Medium = GameObject.Find("Player_Medium");
        Player_Large = GameObject.Find("Player_Large");
        Camera_pos = GameObject.Find("Camera_pos");
        Player_Pos = Player_Small.transform.position; // should be spawn location
        Player_Rot = Player_Small.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera_pos.transform.position = Player_Pos;
        if(Input.GetKeyDown(KeyCode.T))// for testing;
        {
            if (Player_Select == 1)
            {
                Player_Select = 3;
                Player_Large.transform.position = Player_Pos;
                Player_Large.transform.rotation = Player_Rot;
                PM_Script_L.cur_jumps = 2;
            }
                
            else if (Player_Select == 2)
            {
                Player_Select = 1;
                Player_Small.transform.position = Player_Pos;
                Player_Small.transform.rotation = Player_Rot;
            }
            else if (Player_Select == 3)
            {
                Player_Select = 2;
                Player_Medium.transform.position = Player_Pos;
                Player_Medium.transform.rotation = Player_Rot;
                PM_Script_M.cur_jumps = 1;

            }

        }

        if (Input.GetKeyDown(KeyCode.R))// for the real game
        {
            /*
            if (Player_Select == 1)
            {
                Player_Select = 3;
                Player_Large.transform.position = Player_Pos;
                Player_Large.transform.rotation = Player_Rot;
                PM_Script_L.cur_jumps = 2;
            }
            */
            if (Player_Select == 2)
            {
                Player_Select = 1;
                Player_Small.transform.position = Player_Pos;
                Player_Small.transform.rotation = Player_Rot;
            }
            else if (Player_Select == 3)
            {
                Player_Select = 2;
                Player_Medium.transform.position = Player_Pos;
                Player_Medium.transform.rotation = Player_Rot;
                PM_Script_M.cur_jumps = 1;

            }

        }


        if (Player_Select == 1)
        {
            
            Player_Small.SetActive(true);
            Player_Medium.SetActive(false);
            Player_Large.SetActive(false);
            Player_Pos = Player_Small.transform.position;
            Player_Rot = Player_Small.transform.rotation;
        }
        else if (Player_Select == 2)
        {
            
            Player_Small.SetActive(false);
            Player_Medium.SetActive(true);
            Player_Large.SetActive(false);
            Player_Pos = Player_Medium.transform.position;
            Player_Rot = Player_Medium.transform.rotation;
        }
        else if (Player_Select == 3)
        {

            Player_Small.SetActive(false);
            Player_Medium.SetActive(false);
            Player_Large.SetActive(true);
            Player_Pos = Player_Large.transform.position;
            Player_Rot = Player_Large.transform.rotation;
        }
        cur_Pos = Player_Pos;

    }
    private void FixedUpdate()
    {
        Camera_pos.transform.position = Player_Pos + new Vector3(0f,.5f,0f);
    }
    
}
