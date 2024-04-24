using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public bool HasQuestStarted;
    public bool QuestFinished;
    public int PanulaanQuestCount;
    public int PagsuyoQuestCount;
    public int HayopQuestCount;
    public int LupaQuestCount;
    public int TanimQuestCount;
    public int QuestCount;

    public DialogueManagement dialogueScript;


    private void Update()
    {
        if (PagsuyoQuestCount >= 5)
        {
            QuestCount++;
            PagsuyoQuestCount = 0;
            QuestFinished = true;

            dialogueScript = GameObject.Find("Pagsuyo").GetComponentInChildren<DialogueManagement>();
            Debug.Log("Found");
            dialogueScript.TextTwo = false;
            dialogueScript.TextThree = true;
        }

        if (PanulaanQuestCount >= 10)
        {
            QuestCount++;
            PanulaanQuestCount = 0;
            QuestFinished = true;

            dialogueScript = GameObject.Find("Panulaan").GetComponentInChildren<DialogueManagement>();
            dialogueScript.TextTwo = false;
            dialogueScript.TextThree = true;
        }

        if (LupaQuestCount >= 6)
        {
            QuestCount++;
            LupaQuestCount = 0;
            QuestFinished = true;

            dialogueScript = GameObject.Find("Lupa").GetComponentInChildren<DialogueManagement>();
            dialogueScript.TextTwo = false;
            dialogueScript.TextThree = true;
        }

        if (TanimQuestCount >= 2)
        {
            QuestCount++;
            TanimQuestCount = 0;
            QuestFinished = true;

            dialogueScript = GameObject.Find("Tanim").GetComponentInChildren<DialogueManagement>();
            dialogueScript.TextTwo = false;
            dialogueScript.TextThree = true;
        }
    }
}
