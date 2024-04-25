using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] InteractionType type;
    [SerializeField] string name;

    private void Start()
    {
        name = gameObject.name.Replace("Held", "");
    }

    public void Interact()
    {
        int objIndex = Inventory.inst.HeldObjectNames.IndexOf(name);
        switch (type)
        {
            case InteractionType.Pickup:
                Inventory.inst.AddObject(objIndex);
                Destroy(gameObject);
                break;
            case InteractionType.Interact:

                break;
        }
    }
}

public enum InteractionType
{
    Pickup, Interact
}
