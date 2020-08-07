using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_script : MonoBehaviour
{
    public Char_swap CS;
    private Vector3 Player_Pos;

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject p = GameObject.Find("Player");
        CS = p.GetComponent<Char_swap>();
        Player_Pos = CS.cur_Pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Teleport!");
        CS.Player_Small.transform.position = this.transform.GetChild(0).position;
        CS.Player_Medium.transform.position = this.transform.GetChild(0).position;
        CS.Player_Large.transform.position = this.transform.GetChild(0).position;
    }
}
