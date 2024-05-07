using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
        
=======
    public List<Action> taskObjects;
    
    [System.Serializable]
    public struct Action
    {
        public GameObject interactiveObject;
        public InteractionType type;
        public bool hasDone ; 
>>>>>>> Stashed changes
    }
}
