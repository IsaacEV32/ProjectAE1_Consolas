using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask cameraLayer;
    [SerializeField] private LayerMask interactableObject;
    Rigidbody rbPlayer;

    bool onMove = false;
    bool onGround = true;

    Vector3 moveDirection = Vector3.zero;

    #region Unity Methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onMove)
        {
            transform.position += playerSpeed * Time.deltaTime
                * (moveDirection.x * transform.forward + moveDirection.z * transform.right).normalized;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object which the player collides has the layer ground
        if ((groundLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            onGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((interactableObject.value & (1 << other.gameObject.layer)) != 0)
        {
            other.GetComponent<ICollectable>().Collect();
            Debug.Log("Coins: " + GameManager.Instance.inventory.GetCoins());
            Debug.Log("Cassetes: " + GameManager.Instance.inventory.GetCassete());
            other.gameObject.SetActive(false);
        }
    }
    #endregion
    #region Input System Methods
    public void OnMove(InputAction.CallbackContext moveContext)
    {
        if (moveContext.performed)
        {
            Vector2 dir = moveContext.ReadValue<Vector2>();
            moveDirection = new Vector3(dir.y, 0, dir.x);
            onMove = true;
        }
        else if (moveContext.canceled)
        {
            onMove = false;
        }
    }
    public void OnJump(InputAction.CallbackContext jumpContext)
    {
        if (jumpContext.performed
            && Physics.Raycast(transform.position, -transform.up, 2, groundLayer | ~playerLayer | ~cameraLayer)
            && onGround)
        {
            rbPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            this.transform.SetParent(null);
        }
    }

    #endregion
}
