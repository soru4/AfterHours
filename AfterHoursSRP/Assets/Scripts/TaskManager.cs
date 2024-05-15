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
        foreach (Task x in listOfTasks)
        {
            x.taskCompleted = false;
        }
        OnNewDay();

    }

    // Update is called once per frame
    void Update()
    {


        clipBoardText.text = "";
        foreach (Task x in listOfTasks)
        {
            if (!x.taskCompleted)
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
                    Task.Action action =  x.taskObjects[i];
                    if (Vector3.Distance(action.actionPos, player.position) < action.actionRadius)
                    {
                        if (action.interactiveObject == null)
                            action.hasDone = true;
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
                                        if (p.name.Contains(action.interactiveObject.name))
                                        {

                                            obj = p;

                                        }
                                    }
                                    if (obj && obj.activeInHierarchy)
                                    {

                                        if (Input.GetMouseButtonDown(0))
                                        {
                                            //print(obj.name + "Has Interacted");
                                            if (action.removeObject)
                                            {
                                                Inventory.inst.RemoveObject(Inventory.inst.index);
                                            }
                                            action.hasDone = true;

                                        }

                                    }
                                    break;
                                case InteractionType.Pickup:
                                    if (Input.GetMouseButtonDown(0))
                                    {
                                        action.hasDone = true;
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



                clipBoardText.text += "\n[" + ((char)0x221A).ToString() + "] " + x.taskName ;

            }
            else
            {
                float maxDist = -1;
                foreach (Task.Action s in x.taskObjects)
                {
                    if (!s.hasDone)
                        if (Vector3.Distance(s.actionPos, player.transform.position) > maxDist)
                        {
                            maxDist = Vector3.Distance(s.actionPos, player.transform.position);
                            if (Vector3.Distance(s.actionPos, player.transform.position) < s.actionRadius)
                                maxDist = 0;
                            break;
                        }


                }
                clipBoardText.text += "\n[ ] " + x.taskName + " - " + Math.Round(maxDist,1) + "m";
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Task x in listOfTasks)
        {
            foreach (Task.Action y in x.taskObjects)
            {
                Gizmos.DrawWireSphere(y.actionPos, 1);
            }
        }
    }
    public void OnNewDay()
    {
        // Reset Tasks
        currentTasks.Clear();
        clipBoardText.text = "";
        List<int> chosen = new List<int>();
        for (int i = 0; i < 2; i++)
        {
            int addQ = UnityEngine.Random.Range(0, listOfTasks.Count );
            print(addQ);
            if (!chosen.Contains(addQ))
            {
                if (listOfTasks[addQ].taskCompleted == false)
                {
                    chosen.Add(addQ);
                    currentTasks.Add(listOfTasks[addQ]);
                }
            }

        }
        foreach (Task x in currentTasks)
        {
            clipBoardText.text += "[ ] " + x.taskName;
        }

    }
}