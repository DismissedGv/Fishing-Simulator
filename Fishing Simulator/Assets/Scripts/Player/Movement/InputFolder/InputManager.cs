using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
[CreateAssetMenu(fileName = "InputManager", menuName = "Game/Input Manager")]
public class InputManager : ScriptableObject, PlayerInputMap.IPlayerActions
{
    private PlayerInputMap playerMovement;

    public event UnityAction<Vector2> MovementEvent = delegate { };


    private void OnEnable()
    {
        if (playerMovement == null)
        {
            playerMovement = new PlayerInputMap();
            playerMovement.Player.SetCallbacks(this);
            playerMovement.Enable();

        }
    }

    void PlayerInputMap.IPlayerActions.OnMovement(InputAction.CallbackContext context)
    {
        MovementEvent.Invoke(context.ReadValue<Vector2>());
    }

}
