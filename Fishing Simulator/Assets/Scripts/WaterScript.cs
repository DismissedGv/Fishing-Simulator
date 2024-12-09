using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerMovementScript playerMovementScript;
    public void Start()
    {
        playerMovementScript = player.GetComponent<PlayerMovementScript>();
        Debug.Log(playerMovementScript);
    }
    public void OnMouseDown()
    {
        playerMovementScript.hooked = true;

    }
}
