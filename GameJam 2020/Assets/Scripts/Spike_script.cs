using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_script : MonoBehaviour
{
    [SerializeField]
    private GameObject Cur_PLayer;
    public Manager_script manager;
    // Start is called before the first frame update
    void Start()
    {
        Cur_PLayer = GameObject.Find("Player");
        if(Cur_PLayer == null)
        {
            Cur_PLayer = GameObject.Find("Player(Clone)");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cur_PLayer = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spikes!");
        manager.player_Dead = true;
        Destroy(Cur_PLayer);
    }
}
