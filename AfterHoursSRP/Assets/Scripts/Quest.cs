using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]

public class Quest : ScriptableObject
{
    public string questName = string.Empty;
    public Vector3 questStartPos = Vector3.zero;
    public float questRadius = 5;
    public List<string> questDialouges = new List<string>();
    public Queue<string> questQueue = new Queue<string>();   
}
