using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("New, Load & Continue")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private SaveSlotsMenu _saveSlotsMenu;

    [Header("Main Menu")]
    [SerializeField] private GameObject maineMenu;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject saveSlotsMenu;

    private void Start()
    {
        // if there is no game data, disable the continue game button
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

//====================================================================================================== Main Menu
    public void EnterPlay()
    {
        maineMenu.SetActive(false);
        playMenu.SetActive(true);
    }

    public void ExitPlay()
    {
        maineMenu.SetActive(true);
        playMenu.SetActive(false);
    }

    public void EnterSettings()
    {
        maineMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitSettings()
    {
        maineMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ExitSaveSlots()
    {
        playMenu.SetActive(true);
        saveSlotsMenu.SetActive(false);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }

//====================================================================================================== New, Load & Continue
    public void NewGame()
    {
        _saveSlotsMenu.ActivateMenu(false);
    }

    public void LoadGame()
    {
        _saveSlotsMenu.ActivateMenu(true);
    }

    public void ContinueGame()
    {
        DisableMenuButtons();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();

        // load the next scene - which will in turn load the game because of
        // OnSceneLoaded() in the DataPersistenceManager
        SceneManager.LoadSceneAsync("Game");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
