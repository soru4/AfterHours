using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObjects/Task", order = 2)]
public class Task : ScriptableObject
{
    public string taskName;

    public bool taskCompleted = false;

    public Vector3 taskPosition;

}
