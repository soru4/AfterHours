using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public static Inventory inst;
    void Awake() => inst = this;

    GameObject cam;
    bool lookingAtObj;
    RaycastHit lookHit;

    bool[] helds;
    public List<string> HeldObjectNames { get; set; }

    public List<GameObject> physicalHeldObjects;

    public int index = 0;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
