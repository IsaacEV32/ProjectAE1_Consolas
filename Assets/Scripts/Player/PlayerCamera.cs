using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float lookSpeed = 20f;
    [SerializeField] GameObject player;

    bool onLook = false;
    Vector3 lookDirection = Vector3.zero;

    private void LateUpdate()
    {
        if (onLook)
        {
            float angularIncrementX = lookDirection.x * lookSpeed * Time.deltaTime;
            float angularIncrementY = lookDirection.y * lookSpeed * Time.deltaTime;
            float eulerAnglesX = transform.localEulerAngles.x;
            float eulerAnglesY = player.transform.localEulerAngles.y;
            if (eulerAnglesY >= 180)
            {
                eulerAnglesY -= 360;
            }
            else if (eulerAnglesY <= -180)
            {
                eulerAnglesY += 360;
            }
            if (eulerAnglesX >= 180)
            {
                eulerAnglesX -= 360;
            }
            eulerAnglesX = math.clamp(eulerAnglesX - angularIncrementX, -60f, 60f);
            eulerAnglesY = eulerAnglesY + angularIncrementY;
 
            transform.localEulerAngles = new Vector3(eulerAnglesX, 0, 0);
            player.transform.localEulerAngles = new Vector3 (0, eulerAnglesY, 0);
        }
    }
    public void OnLook(InputAction.CallbackContext lookContext)
    {
        if (lookContext.performed)
        {
            Vector2 dir = lookContext.ReadValue<Vector2>();
            lookDirection = new Vector3(dir.y, dir.x, 0);

            onLook = true;
        }
        else if (lookContext.canceled)
        {
            onLook = false;
        }
    }
}
