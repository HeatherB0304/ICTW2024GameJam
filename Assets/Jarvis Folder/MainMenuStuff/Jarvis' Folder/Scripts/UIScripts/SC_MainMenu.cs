using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject OptionsMenu;
    public GameObject GalleryMenu;
    public GameObject LevelSelectMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Castle Halls");
        LevelSelectButton();
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void OptionsButton()
    {
        // Show Options Menu
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void GalleryButton()
    {
        // Show Gallery Menu
        MainMenu.SetActive(false);
        GalleryMenu.SetActive(true);
    }

    public void LevelSelectButton()
    {
        // Show Level Select Menu
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        GalleryMenu.SetActive(false);
        LevelSelectMenu.SetActive(false);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quit Game
            Application.Quit();
        #endif
    }

    //Level Select
    public void SelectLevelOne() 
    {
        SceneManager.LoadScene("Insert Scene Name Here");
    }
    public void SelectLevelTwo() 
    {
        SceneManager.LoadScene("Insert Scene Name Here");
    }
    public void SelectLevelThree() 
    {
        SceneManager.LoadScene("Insert Scene Name Here");
    }
}
