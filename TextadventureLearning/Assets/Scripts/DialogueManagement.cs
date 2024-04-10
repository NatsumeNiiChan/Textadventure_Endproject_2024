using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;

public class DialogueManagement : MonoBehaviour
{
    //[SerializeField] private Transform dialogueText;
    [SerializeField] private TMP_Text textDoc;
    [SerializeField] private string textName;

    [SerializeField] List<string> fileLines;

    public int lineAmount;
    public int lineCount;

    private void Start()
    {
        string textFinder = Application.streamingAssetsPath + "/Text Assets/" + textName + ".txt";

        fileLines = File.ReadAllLines(textFinder).ToList();

    }

    private void Update()
    {
        foreach (string line in fileLines)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                textDoc.text = line;
            }

            else
            {
                return;
            }
        }

        //for (int i = 0; i < lineAmount; i = lineCount)
        //{
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        lineCount++;
        //    }
        //}
    }
}
