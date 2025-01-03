using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EPress : MonoBehaviour
{
    [SerializeField] public GameObject currentPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPosition != null)
        {
            Vector3 newPosition = currentPosition.transform.position;
            gameObject.transform.position = newPosition;
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateEPressed();
        }

    }
    public void OnMouseDown()
    {
        ActivateEPressed();
    }

    public void ActivateEPressed()
    {

        //Do something after pressed E, open shop etc.
        Debug.Log("E Action");
    }

    public void SetGameObject(GameObject gameObject)
    {
        currentPosition = gameObject;
    }
}
