using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button continueGameButton;

    [Header("Menu Navigation")]
    [SerializeField] private GameObject maineMenu;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject saveSlotsMenu;
    [SerializeField] private SaveSlotsMenu _saveSlotsMenu;

    private void Start()
    {
       DisableButtonsDependingOnData();
    }

    private void DisableButtonsDependingOnData()
    {
        // if there is no game data, disable the continue game button
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

//====================================================================================================== Menu Navigation
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

    public void EnterSaveSlots()
    {
        playMenu.SetActive(false);
        saveSlotsMenu.SetActive(true);
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

//====================================================================================================== Menu Buttons
    public void OnNewGameClicked()
    {   
        _saveSlotsMenu.ActivateMenu(false);
        EnterSaveSlots();
    }

    public void OnLoadGameClicked()
    {
        _saveSlotsMenu.ActivateMenu(true);
        EnterSaveSlots();
    }

    public void OnContinueGameClicked()
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
