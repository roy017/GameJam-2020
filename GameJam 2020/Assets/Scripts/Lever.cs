using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool[] isOpened;
    public GameObject[] doors;

    private bool hasTriggered = false;

    public bool isRewindable;

    public Sprite Left;
    public Sprite Right;
    private Sprite Sprite_cur;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = new bool[doors.Length];
        for(int i = 0; i < doors.Length; i++)
        {
            isOpened[i] = !doors[i].GetComponent<Door>().initialState;
            doors[i].SetActive(!isOpened[i]);
            Debug.Log(isOpened[i]);
        }
        Sprite_cur = Left;
        this.GetComponent<SpriteRenderer>().sprite = Sprite_cur;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasTriggered = true;
        Activate();
    } 

    // Update is called once per frame
    void Update()
    {
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
                doors[i].SetActive(isOpened[i]);
                isOpened[i] = !isOpened[i];
                
            }

            if(Sprite_cur == Left)
                Sprite_cur = Right;
            else
                Sprite_cur = Left;

            this.GetComponent<SpriteRenderer>().sprite = Sprite_cur;

    }
}
