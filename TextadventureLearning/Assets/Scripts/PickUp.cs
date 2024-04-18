using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //[SerializeField] private GameObject uiObject;
    public bool IsPickable;
    private TaskManager taskMScript;

    private void Awake()
    {
        taskMScript = FindObjectOfType<TaskManager>();
    }

    private void Update()
    {
        if (IsPickable == true && Input.GetKeyDown(KeyCode.Space))
        {
            //uiObject.SetActive(false);

            taskMScript.BookCount++;
            Destroy(gameObject);
        }
    }
}
