using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;

public class MainMenuUI : MonoBehaviour {

    public GameObject mainMenuCanvas;

    private GameObject mainMenu, options, login;
    private bool b;

    void Start()
    {
        mainMenu = mainMenuCanvas.transform.FindChild("MainMenu").gameObject;
        options = mainMenuCanvas.transform.FindChild("Options").gameObject;
        login = mainMenuCanvas.transform.FindChild("Login").gameObject;

        options.SetActive(false);
        login.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Login()
    {
        string username = login.transform.FindChild("UsernameInput").FindChild("Text").GetComponent<Text>().text;
        string password = login.transform.FindChild("PasswordInput").GetComponent<InputField>().text;

        login.transform.FindChild("Button").GetComponent<Button>().interactable = false;
        ParseUser.LogInAsync(username, password).ContinueWith(t =>
        {
            Debug.Log("Dont mind me, just debugging in ParseUser.LogInAsync...");
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.Log("Couldnt log in!!");
                b = false;
            }
            else
            {
                Debug.Log("Logged in and ready to roll!");
                b = true;
            }
        });
    }

    void Update()
    {
        if (b)
        {
            mainMenuCanvas.SetActive(false);
            GameObject.FindGameObjectWithTag("Parse").GetComponent<ParseTest>().Debugg();
        }
    }

    #region Main Menu
    public void Play()
    {
        login.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Only in editor: The game have been shut down.");
    }
    #endregion

    #region Options
    public void Options_Back()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}
