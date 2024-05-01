using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public GameObject player;
    public List<Quest> quests = new List<Quest>();



    // Start is called before the first frame update
    void Start()
    {
        foreach (Quest q in quests)
        {
            foreach (string z in q.questDialouges)
            {
                q.questQueue.Enqueue(z);
            }
        }
        InvokeRepeating("QuestCheck", 0.7f, 4f);
    }




    public void QuestCheck()
    {
        foreach (Quest q in quests)
        {
            if (Vector3.Distance(player.transform.position, q.questStartPos) <= q.questRadius * 3 && Vector3.Distance(player.transform.position, q.questStartPos) >= q.questRadius)
            {
                Invoke("QuestCheck", 0.2f);
            }
            if (Vector3.Distance(player.transform.position, q.questStartPos) <= q.questRadius)
            {
                // add current quest to the active quests
                if (q.questQueue.Count <= 0)
                {
                    questText.text = "";

                }

                string x = q.questQueue.Dequeue();
                questText.text = (x == null) ? "" : x;


            }
        }
    }



    private void OnDrawGizmos()
    {
        foreach (Quest q in quests)
        {
            Gizmos.DrawWireSphere(q.questStartPos, q.questRadius);

        }
    }
}