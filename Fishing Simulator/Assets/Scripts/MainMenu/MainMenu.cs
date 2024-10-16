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
    [SerializeField] private SaveSlotsMenu _saveSlotsMenu;

    // Animator
    private Animator animator;


    private void Start()
    {
        animator = GameObject.Find("Main Camera").GetComponent<Animator>();

        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
    }

    public void NewGame()
    {
        _saveSlotsMenu.ActivateMenu(false);
        animator.SetTrigger("EnterSaveSlots");
    }

    public void LoadGame()
    {
        _saveSlotsMenu.ActivateMenu(true);
        animator.SetTrigger("EnterSaveSlots");
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

    public void EnterSettings()
    {
        animator.SetTrigger("OpenSettings");
    }

    public void ExitSettings()
    {
        animator.SetTrigger("ExitSettings");
    }

    public void ExitSaveSlots()
    {
        animator.SetTrigger("ExitSaveSlots");
    }

    public void EnterLobby()
    {
        animator.SetTrigger("EnterLobby");
    }
    public void ExitLobby()
    {
        animator.SetTrigger("ExitLobby");
    }
    
    public void ExitToDesktop()
    {
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
