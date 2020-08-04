using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_swap : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player_Small, Player_Medium, Camera_pos;
    private int Player_Select;
    private Vector3 Player_Pos;

    void Start()
    {
        Player_Select = 1;
        Player_Small = GameObject.Find("Player_Small");
        Player_Medium = GameObject.Find("Player_Medium");
        Camera_pos = GameObject.Find("Camera_pos");
        Player_Pos = Player_Small.transform.position; // should be spawn location
    }

    // Update is called once per frame
    void Update()
    {
        //Camera_pos.transform.position = Player_Pos;
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (Player_Select == 1)
            {
                Player_Select = 2;
                Player_Medium.transform.position = Player_Pos;
            }
                
            else if (Player_Select == 2)
            {
                Player_Select = 1;
                Player_Small.transform.position = Player_Pos;
            }
                
        }
        if(Player_Select == 1)
        {
            
            Player_Small.SetActive(true);
            Player_Medium.SetActive(false);
            Player_Pos = Player_Small.transform.position;
        }
        else if (Player_Select == 2)
        {
            
            Player_Small.SetActive(false);
            Player_Medium.SetActive(true);
            Player_Pos = Player_Medium.transform.position;
        }

    }
    private void FixedUpdate()
    {
        Camera_pos.transform.position = Player_Pos;
    }
}
