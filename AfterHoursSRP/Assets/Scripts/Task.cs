using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObjects/Task", order = 2)]
public class Task : ScriptableObject
{
    public string taskName;
    public bool taskCompleted = false;
    public List<Action> taskObjects;

    [System.Serializable]
    public  class  Action
    {
        public GameObject interactiveObject;
        public InteractionType type;
        public Vector3 actionPos;
        public bool removeObject = false; 
        public double actionRadius; 
        public bool hasDone;

    }

}