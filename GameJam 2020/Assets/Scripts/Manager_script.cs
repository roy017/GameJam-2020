using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Manager_script : MonoBehaviour
{
    public bool player_Dead;
    public GameObject player;
    public Char_swap CS;
    //[SerializeField]
    public CinemachineVirtualCamera followCam;
    private bool spawned;

    [SerializeField]
    private GameObject player_pos;

    // Start is called before the first frame update
    void Start()
    {
        player_Dead = false;
        //camera = GameObject.Find("CM vcam1");
        //followCam = GetComponent<CinemachineVirtualCamera>();
        GameObject p1 = Instantiate(player, this.transform.GetChild(0).position, player.transform.rotation);
        p1.name = player.name;
        player_pos = GameObject.Find("Camera_pos");
        followCam.Follow = player_pos.transform;
        spawned = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_Dead == true)
        {
            //Instantiate(player, this.transform.GetChild(0).position, player.transform.rotation);
            //followCam.LookAt = player.transform.GetChild(0);
            //followCam.Follow = player.transform.GetChild(0);
            spawned = false;
            //player_Dead = false;
        }
        

        //Debug.Log(player_Dead);
    }
    private void FixedUpdate()
    {
        if(spawned == false)
        {
            spawned = true;
            player_Dead = false;
            GameObject p1 = Instantiate(player, this.transform.GetChild(0).position, player.transform.rotation);
            p1.name = player.name;
            player_pos = GameObject.Find("Camera_pos");
            followCam.Follow = player_pos.transform;
        }
    }
}
