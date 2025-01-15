using UnityEngine;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject settings;
    public bool isPaused {get; private set;} //bool if things needs to be done on pause
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
        

            if (settings.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    private void ResumeGame(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        settings.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    private void PauseGame(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        settings.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
