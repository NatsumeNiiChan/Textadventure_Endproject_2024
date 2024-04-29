using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject surveyScreen;
    [SerializeField] private GameObject lvl2Screen;
    [SerializeField] private GameObject panulaanBook;

    [SerializeField] private bool gameMenu;
    private bool level2;

    private QuestHandler questScript;

    private void Awake()
    {
        questScript = FindObjectOfType<QuestHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameMenu == true)
        {
            pauseScreen.SetActive(true);
        }
    }

    public void StartLvl1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLvl2()
    {
        if (level2 == false)
        {
            lvl2Screen.SetActive(true);
        }

        else if (level2 == true)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Survey()
    {
        surveyScreen.SetActive(true);
    }

    public void Back()
    {
        if (gameMenu == true)
        {
            pauseScreen.SetActive(false);
            panulaanBook.SetActive(false);
        }

        else
        {
            lvl2Screen.SetActive(false);
            surveyScreen.SetActive(false);
        }
    }

    public void PanulaansBook()
    {
        if (questScript.GotBook == true)
        {
            panulaanBook.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
