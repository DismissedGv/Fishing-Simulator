using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EPress : MonoBehaviour
{
    [SerializeField] public GameObject currentPosition;
    [SerializeField] public string gameObjectTag;
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
        switch (gameObjectTag)
        {
            case "Interractable":
                //Do Something when interracting with something interractable
                Debug.Log("E Action on Interractable");
                break;
            case "Shop":
                //Do Something when interracting with shop
                Debug.Log("E Action on Shop");
                break;
        }
    }

    public void SetGameObject(GameObject gameObject)
    {
        currentPosition = gameObject;
    }
}
