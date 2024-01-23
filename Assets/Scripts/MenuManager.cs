using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public enum MenuState
{
    notInMenu,
    inMainMenu,
    inPauseMenu,
    inSettingsMenu,
    inDeathMenu,
}
public class MenuManager : MonoBehaviour
{
    public MenuState currentMenuState; 
    public static MenuManager sharedInstanceMenuManager;

    [SerializeField]  // menus game objects (panels, these need to be added inside the unity editor)
    private GameObject mainMenuPanel, pauseMenuPanel, deathMenuPanel, settingsMenuPanel;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (sharedInstanceMenuManager == null)
        {
            sharedInstanceMenuManager = this;
        }
    }
    private void Start()
    {
        currentMenuState = MenuState.inMainMenu; // By default it's set to no menu active
    }
    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            if(currentMenuState == MenuState.notInMenu)
            {
                // Activate pause menu and pause game (sets timescale to 0)
                ShowPauseMenu();
            }
            else if (currentMenuState == MenuState.inPauseMenu)
            {
                // Deactivate pause menu and unpause game (set timescale to 1)
                CloseMenu();
            }
            else if (currentMenuState == MenuState.inSettingsMenu)
            {
                // Deactivate settings menu, this leaves the pause menu active
                CloseMenu();
            }
        }
    }

    // Change menu state functions
    public void InDeathMenu()
    {
        SetMenuState(MenuState.inDeathMenu);
    }
    public void InMainMenu()
    {
        SetMenuState(MenuState.inMainMenu);
    }
    public void InPauseMenu()
    {
        SetMenuState(MenuState.inPauseMenu);
    }
    public void InSettingsMenu()
    {
        SetMenuState(MenuState.inSettingsMenu);
    }
    public void NotInMenu()
    {
        SetMenuState(MenuState.notInMenu);
    }

    private void SetMenuState(MenuState newMenuState)
    {
        if(newMenuState == MenuState.inMainMenu)
        {
            // Go to main menu scene and activate panel
            Time.timeScale = 1;
        }
        else if (newMenuState == MenuState.notInMenu)
        {
            // Deactivate all menu panels and set TimeScale to 1
            Time.timeScale = 1;
        }
        else if (newMenuState == MenuState.inDeathMenu)
        {
            // Activate death panel and set TimeScale to 0
            Time.timeScale = 0;
        }
        else if (newMenuState == MenuState.inPauseMenu)
        {
            // Activate pause panel and set TimeScale to 0
            Time.timeScale = 0;
        }
        else if (newMenuState == MenuState.inSettingsMenu)
        {
            // Activate settings panel
        }

        this.currentMenuState = newMenuState;
    }

    // Show menu functions
    public void ShowSettingsMenu()
    {
        settingsMenuPanel.SetActive(true);  // Activate the panel
        InSettingsMenu();       // Changing Menu State
    }
    public void ShowPauseMenu()
    {
        pauseMenuPanel.SetActive(true);  // Activate the panel
        InPauseMenu();       // Changing Menu State
    }
    public void ShowDeathMenu()
    {
        deathMenuPanel.SetActive(true);  // Activate the panel
        InPauseMenu();       // Changing Menu State
    }
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        InMainMenu();
        //SceneManager.LoadScene("NAME OF SCENE");
    }

    // Close menus function
    public void CloseMenu()
    {
        if (currentMenuState == MenuState.inPauseMenu)
        {
            pauseMenuPanel.SetActive(false);
            NotInMenu();
        }
        else if (currentMenuState == MenuState.inMainMenu)
        {
            mainMenuPanel.SetActive(false);
            Debug.Log("ya deberia haberse cerrado");
            NotInMenu();
        }
        else if (currentMenuState == MenuState.inSettingsMenu)
        {
            settingsMenuPanel.SetActive(false);
            InPauseMenu();
        }
        else if (currentMenuState == MenuState.inDeathMenu)
        {
            NotInMenu();
            deathMenuPanel.SetActive(false);
            NewGame();
        }
    }

    public void NewGame()
    {
        CloseMenu();
        SceneManager.LoadScene("Main");
    }
    // Quit game function
    public void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}