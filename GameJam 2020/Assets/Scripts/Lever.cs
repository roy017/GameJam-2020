using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isOpened;
    public GameObject[] doors;

    private bool hasTriggered = false;

    public bool isRewindable;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < doors.Length; i++)
        {
            isOpened = !doors[i].GetComponent<Door>().initialState;
            doors[i].SetActive(!isOpened);
        }
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
                doors[i].SetActive(isOpened);
            }

            isOpened = !isOpened;
    }
}
