using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float openSpeed;
    public bool openDirectionally;
    public bool openPositive;
    public Animator animator;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetBool("openPositive", openPositive);
        animator.SetFloat("openSpeed", openSpeed);

        if (!player)
            player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (openDirectionally)
        {
            //print(Vector3.Dot(transform.forward, player.transform.position - transform.position));
            animator.SetBool("openPositive", Vector3.Dot(transform.forward, player.transform.position - transform.position) < 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            animator.SetBool("near", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            animator.SetBool("near", false);
        }
    }
}
