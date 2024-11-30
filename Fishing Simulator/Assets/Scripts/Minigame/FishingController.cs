using UnityEngine;
using UnityEngine.InputSystem;

public class FishingController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float HookSpeed;
    public bool occupied;

    [Header("References")]
    [SerializeField] private GameObject HookTarget;
    [SerializeField] private GameObject Hook;
    [SerializeField] private GameObject RotateTarget;
    [SerializeField] private Canvas canvas;
    
    Vector2 MousePosition;

    void Update()
    {
        MousePosition = Mouse.current.position.ReadValue();
        
        // Convert mouse position to canvas space
        Vector2 canvasPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, MousePosition, null, out canvasPosition))
        {
            HookTarget.transform.position = canvas.transform.TransformPoint(canvasPosition);
        }

        LookTowards();
        Hook.transform.position = Lerp(Hook.transform.position, HookTarget.transform.position, HookSpeed * Time.deltaTime); 

        Vector3 newPosition = RotateTarget.transform.position;
        newPosition.x += (Hook.transform.position.x - RotateTarget.transform.position.x) * HookSpeed * Time.deltaTime;
        RotateTarget.transform.position = newPosition;
    }

    private void LookTowards()
    {
        Vector3 look = Hook.transform.InverseTransformPoint(RotateTarget.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

        Hook.transform.Rotate(0, 0, angle);
    }

    private Vector3 Lerp(Vector3 start, Vector3 end, float time)
    {
        return start + (end - start) * time;
    }
}
