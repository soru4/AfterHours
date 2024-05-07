using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System; 
using UnityEngine;
using TMPro;


public class TaskManager : MonoBehaviour
{
    public List<Task> listOfTasks;
    public TMP_Text clipBoardText;
    public List<Task> currentTasks; 
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Task x in listOfTasks)
        {
            x.taskCompleted = false;
        }
        OnNewDay();

    }

    // Update is called once per frame
    void Update()
    {
/*

        clipBoardText.text = "";
        foreach (Task x in listOfTasks)
        {
            if (!x.taskCompleted)
            {
                if (Vector3.Distance(x.taskPosition, player.position) < 10f)
                {
                    int z = 0;
                    foreach (Task.Action action in x.taskObjects)
                    {
                        if (!action.hasDone)
                            z++;
                    }
                    if (z == 0)
                    {
                        x.taskCompleted = true;
                    }
                    for (int i = 0; i < x.taskObjects.Count; i++)
                    {
                        Task.Action action = x.taskObjects[i];
                        if (action.hasDone)
                            continue;
                        else
                        {
                            switch (action.type)
                            {
                                case InteractionType.Interact:
                                    GameObject obj = null;
                                    foreach (GameObject p in Inventory.inst.physicalHeldObjects)
                                    {
                                        if (p.name == action.interactiveObject.name)
                                        {

                                            obj = p;
                                          
                                        }
                                    }
                                    if (obj.activeInHierarchy)
                                    {

                                        if (Input.GetMouseButtonDown(0))
                                        {
                                            print(obj.name + "Has Interacted");
                                            action.hasDone = true;
                                            if(x.taskObjects.Count() == 1)
                                            {
                                                x.taskCompleted = true;
                                            }
                                        }

                                    }
                                    break;
                                case InteractionType.Pickup:
                                    if (Input.GetMouseButtonDown(0))
                                    {

                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        foreach (Task x in currentTasks)
        {
            if (x.taskCompleted)
            {



                clipBoardText.text += "[" + ((char)0x221A).ToString() + "] " + x.taskName;

            }
            else
            {
                clipBoardText.text += "[ ] " + x.taskName;
            }
        }

        */
    }
 
    private void OnDrawGizmos()
    {
        foreach(Task x in listOfTasks)
        {
            Gizmos.DrawWireSphere(x.taskPosition, 5);
        }
    }
    public void OnNewDay()
    {
        // Reset Tasks
        currentTasks.Clear();
        clipBoardText.text = "";
        List<int> chosen = new List<int>();
        for(int i = 0; i < 2; i++)
        {
            int addQ = UnityEngine.Random.Range(0, listOfTasks.Count -1);
            print(addQ);
            if (!chosen.Contains(addQ)) {
                if(listOfTasks[addQ].taskCompleted == false)
                {
                    chosen.Add(addQ);
                    currentTasks.Add(listOfTasks[addQ]);
                }
            }

        }
        foreach(Task x in currentTasks)
        {
            clipBoardText.text += "[ ] " + x.taskName;
        }

    }
}
