using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("PickUp", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("PickUp", false);
        }

        if (Inventory.inst.index == 0) { 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetBool("Emote", true);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                anim.SetBool("Emote", false);
            }
        }
    }
}
