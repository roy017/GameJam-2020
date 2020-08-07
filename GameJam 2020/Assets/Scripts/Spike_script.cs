using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_script : MonoBehaviour
{
    [SerializeField]
    private GameObject Cur_PLayer;
    public Manager_script manager;
    public Char_swap CS;

    private void Start()
    {
        //manager = GetComponent<Manager_script>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Cur_PLayer = GameObject.Find("Player");
        CS = Cur_PLayer.GetComponent<Char_swap>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spikes!");
        manager.player_Dead = true;
        Destroy(Cur_PLayer);
    }
}
