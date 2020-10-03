using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool[] isOpened;
    public GameObject[] doors;

    private bool hasTriggered = false;

    public bool isRewindable;
    private bool canActivate;

    public Sprite Left;
    public Sprite Right;
    private Sprite Sprite_cur;

    // Start is called before the first frame update
    void Start()
    {
        canActivate = false;
        isOpened = new bool[doors.Length];

        for(int i = 0; i < doors.Length; i++)
        {
            isOpened[i] = !doors[i].GetComponent<Door>().initialState;
            doors[i].SetActive(!isOpened[i]);
        }
        Sprite_cur = Left;
        this.GetComponent<SpriteRenderer>().sprite = Sprite_cur;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hasTriggered = true;
        // Activate();
        canActivate = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // hasTriggered = true;
        // Activate();
        canActivate = false;

    }  

    // Update is called once per frame
    void Update()
    {
        if(canActivate)
        {
            if(Input.GetKeyDown("f"))
            {
                hasTriggered = true;
                Activate();
            }
        }


        if(isRewindable){
            if(Input.GetKeyDown("e"))
            {
                if(hasTriggered){
                    Activate();
                } 
            }
        }
    }

    private void Activate()
    {
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(!doors[i].activeSelf);
                // isOpened[i] = !isOpened[i];
                
            }

            if(Sprite_cur == Left)
                Sprite_cur = Right;
            else
                Sprite_cur = Left;

            this.GetComponent<SpriteRenderer>().sprite = Sprite_cur;

    }
}
