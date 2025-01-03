using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    [SerializeField] GameObject eButton;
    [SerializeField] GameObject[] interactableArray;
    [SerializeField] GameObject gameobjectToInstantiate;
    GameObject instantiated;
    public EPress ePress;
    // Start is called before the first frame update
    public void Start()
    {
        interactableArray = new GameObject[10];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        ArrayChanger(true, interactableArray, col.gameObject);
        instantiated = (GameObject)Instantiate(gameobjectToInstantiate, gameObject.transform.position, quaternion.identity);
        ePress = instantiated.GetComponent<EPress>();
        ePress.currentPosition = col.gameObject;
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        ArrayChanger(false, interactableArray, col.gameObject);
        Destroy(instantiated);
    }

    public void ArrayChanger(bool addBoolean, GameObject[] array, GameObject objectToAddOrDelete)
    {
        if (addBoolean)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    array[i] = objectToAddOrDelete;
                    Debug.Log("Added");
                    i = array.Length;
                }
            }
        }
        else
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == objectToAddOrDelete)
                {
                    array[i] = null;
                    Debug.Log("Deleted");
                    i = array.Length;
                }
            }
        }
    }
}
