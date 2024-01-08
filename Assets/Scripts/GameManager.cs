using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    inBattle,
    exploring,
    inMenu,
    inInventory,
    gameOver,

}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.inMenu;

    public static GameManager sharedInstanceGameManager;
    private void Awake()
    {
        if (sharedInstanceGameManager == null)
        {
            sharedInstanceGameManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            InBattle();
        }
        else if (keyboard.digit2Key.wasPressedThisFrame)
        {  
            Exploring();
        }
        else if (keyboard.digit3Key.wasPressedThisFrame)
        {
            BackToMenu();
        }
        else if (keyboard.digit4Key.wasPressedThisFrame)
        {
            inInventory();
        }
        else if (keyboard.digit5Key.wasPressedThisFrame)
        {
            GameOver();
        }
    }
    public void InBattle()
    {
        SetGameState(GameState.inBattle);
    }

    public void Exploring()
    {
        SetGameState(GameState.exploring);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.inMenu);
    }

    public void inInventory()
    {
        SetGameState(GameState.inInventory);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.inBattle)
        {
            //TODO: Logica al estar en batalla.

        }
        else if (newGameState == GameState.exploring)
        {
            //TO-DO: Lógica al explorar

            /*LevelManager.sharedInstanceLevelManager.RemoveAllLevelBlocks();
            ReloadGame();
            Time.timeScale = 1f;
            playerController.StartGame();
            MenuManager.sharedInstance.HideMainMenu();
            MenuManager.sharedInstance.HidePausedGameMenu();
            MenuManager.sharedInstance.showInGameMenu();
            MenuManager.sharedInstance.HideGameOverMenu();*/
        }
        else if (newGameState == GameState.inMenu)
        {
            //TODO:Lógica al estar en el menu de pausa y el de inicio, sera la misma por lo que se unen.

            /*Time.timeScale = 0f;
            MenuManager.sharedInstance.showPausedGameMenu();
            MenuManager.sharedInstance.HideInGameMenu();*/
        }
        else if (newGameState == GameState.inInventory)
        {
            //TODO: Lógica al estar en el menu, esta sera especial por lo que muy probablemente no podamos poner tiempo 0, sin embargo dependiendo de la lógica elegida se harán cambios.
        }
        else if (newGameState == GameState.gameOver)
        {

            //TODO: Lógica al morir, perder la partida.

            /*MenuManager.sharedInstance.showGameOverMenu();
            MenuManager.sharedInstance.HideInGameMenu();*/
        }
        this.currentGameState = newGameState;
    }
    private void ReloadGame()
    {
        //TO-DO: logica al reiniciar el juego, nueva partida.
    }

    private void LoadGame()
    {
        //TO-DO: logica al cargar partida.
    }

    private void SaveGame()
    {
        //TO-DO: logica al guardar partida.
    }
}
