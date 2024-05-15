using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inst;
    void Awake() => inst = this;

    GameObject cam;
    bool lookingAtObj;
    RaycastHit lookHit;

    bool[] helds;
    public List<string> HeldObjectNames { get; set; }

    public List<GameObject> physicalHeldObjects;

    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.allCameras[0].gameObject;
        HeldObjectNames = new List<string>();
        foreach (GameObject obj in physicalHeldObjects)
        {
            obj.SetActive(false);
            HeldObjectNames.Add(obj.name.Replace("Held", ""));
        }
        helds = new bool[HeldObjectNames.Count];
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        GetLookingInfo();
        if (lookingAtObj && Input.GetKeyDown(KeyCode.E))
        {
            print(lookHit.collider.gameObject.name);
            InteractiveObject iObj = lookHit.collider.GetComponent<InteractiveObject>();
            if (iObj)
                iObj.Interact();
        }

        if (Input.mouseScrollDelta.y != 0)
            Scroll(Mathf.Sign(Input.mouseScrollDelta.y));

    }

    void InitializeInventory()
    {
        // clipboard
        helds[0] = true;

        ChangeActiveObject();
    }

    void Scroll(float scroll)
    {

        bool anyObjectsActive = false;
        foreach(bool real in helds)
            if(real) { anyObjectsActive = true; break; }

        if (!anyObjectsActive)
            return;
        int original = index;


        int iter = 0;
        do
        {
            iter++;
            index += (int)scroll;
            index = mod(index, helds.Length);
            //print(index);
        } while (!helds[index] && iter < 10);
        //print("__" + index);

        if (index != original)
            ChangeActiveObject();

        int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }

    void ChangeActiveObject()
    {
        foreach (GameObject obj in physicalHeldObjects)
            obj.SetActive(false);
        physicalHeldObjects[index].SetActive(true);
    }

    void GetLookingInfo()
    {
        lookingAtObj = Physics.Raycast(cam.transform.position, cam.transform.forward, out lookHit, 50f, LayerMask.GetMask("Interactible"));
    }

    public void AddObject(int i)
    {
        if (i < 0 || i > helds.Length)
            return;
        print("add " + i);
        helds[i] = true;
        index = i;
        ChangeActiveObject();
    }

    public void RemoveObject(int i)
    {
        if (i < 0 || i > helds.Length)
            return;
        print("remove " + i);
        helds[i] = false;
        if (index == i) Scroll(1);
        ChangeActiveObject();
    }


}
