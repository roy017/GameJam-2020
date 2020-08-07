using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_script : MonoBehaviour
{
    public bool isRocket = true;
    public Char_swap CS;
    private Vector3 Player_Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
