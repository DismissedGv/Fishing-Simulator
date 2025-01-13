using UnityEngine;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    public bool isPaused {get; private set;} //bool if things needs to be done on pause
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
        

            if (Settings.activeSelf)
            {
                isPaused = false;
                Settings.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = true;
                Settings.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
