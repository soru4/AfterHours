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

        OnNewDay();
        InvokeRepeating("TaskCheck", 0, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TaskCheck()
    {


        clipBoardText.text = "";
        foreach (Task x in listOfTasks)
        {
            if(Vector3.Distance(x.taskPosition, player.position) < 10f)
            {
                x.taskCompleted = true; 
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
                clipBoardText.text += "[] " + x.taskName;
            }
        }
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
            clipBoardText.text += "[] " + x.taskName;
        }

    }
}
