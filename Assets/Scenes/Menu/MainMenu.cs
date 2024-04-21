using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button registerButton;

    ArrayList credentials;
                                    //This part is when you move Scenes//
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1); //page 1 to page 2//
    }

    public void QuitGame()
    {
        Application.Quit();// page1 quit//
    }

    public void Login()
    {
        SceneManager.LoadSceneAsync(2);// page2 to page 3 //
    }

    public void SignUp()
    { 
        SceneManager.LoadSceneAsync(3);
    }

    public void Next()
    { 
        SceneManager.LoadSceneAsync(4); //page2 and page 3 to page 4
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void ToScene (string SceneName  )
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
      public void ToScene (int SceneNum  )
    {
        SceneManager.LoadSceneAsync(SceneNum);
    }


                            //this is to do with the Signin
    private void Start()

    {
        if (registerButton != null)
        {



            registerButton.onClick.AddListener(writeStuffToFile);


            if (File.Exists(Application.dataPath + "/credentials.txt"))
            {
                credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
            }
            else
            {
                File.WriteAllText(Application.dataPath + "/credentials.txt", "");
            }

        }
    }
    void writeStuffToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/credentials.txt", (String[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }


       
    
   }