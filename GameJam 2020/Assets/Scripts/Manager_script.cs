using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    public GameObject Rocket_Item;
    public GameObject Helmet_Item;
    public GameObject[] RI_Pos;
    public GameObject[] HI_Pos;
    public GameObject[] items1;
    public GameObject[] items2;



    // Start is called before the first frame update
    void Start()
    {
        player_Dead = false;

        GameObject p1 = Instantiate(player, this.transform.GetChild(0).position, player.transform.rotation);
        p1.name = player.name;
        player_pos = GameObject.Find("Camera_pos");
        followCam.Follow = player_pos.transform;
        spawned = true;
        Item_placer();
    }

    void Item_placer()
    {
        
        for (int i = 0; i < RI_Pos.Length; i++)
        {
            GameObject I1 = Instantiate(Rocket_Item, RI_Pos[i].transform.position, Rocket_Item.transform.rotation);
            I1.name = Rocket_Item.name;
            items1[i]= I1;
        }
        
        for (int i = 0; i < HI_Pos.Length; i++)
        {
            GameObject H1 = Instantiate(Helmet_Item, HI_Pos[i].transform.position, Helmet_Item.transform.rotation);
            H1.name = Helmet_Item.name;
            items2[i] = H1;

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(player_Dead == true)
        {
            spawned = false;
        }

        if(Input.GetKeyDown(KeyCode.Tab)){
            Reset();
        }

    }
    private void FixedUpdate()
    {
        if(spawned == false)
        {
            // spawned = true;
            // player_Dead = false;
            // GameObject p1 = Instantiate(player, this.transform.GetChild(0).position, player.transform.rotation);
            // p1.name = player.name;
            // player_pos = GameObject.Find("Camera_pos");
            // followCam.Follow = player_pos.transform;

            // Item_destroyer();
            // Item_placer();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Reset();
        }

        
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Item_destroyer()
    {
        for (int i = 0; i < items1.Length; i++)
        {
            Destroy(items1[i]);
        }
        for (int i = 0; i < items2.Length; i++)
        {
            Destroy(items2[i]);
        }
    }
}
