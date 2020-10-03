using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_script : MonoBehaviour
{
    public bool isRocket = true;
    public Char_swap CS;
    private Vector3 Player_Pos;

    public Manager_script manager;

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject p = GameObject.Find("Player");
        CS = p.GetComponent<Char_swap>();

        GameObject s = GameObject.Find("GameManager");
        manager = s.GetComponent<Manager_script>();

        Player_Pos = CS.cur_Pos;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (isRocket == true)
        {
            CS.Player_Select = 3;
            CS.Player_Large.transform.position = Player_Pos;
            CS.PM_Script_L.cur_jumps = 2;
        }
        else
        {
            CS.Player_Select = 2;
            CS.Player_Medium.transform.position = Player_Pos;
            CS.PM_Script_M.cur_jumps = 1;
        }
        Destroy(this.gameObject);
    }
}
