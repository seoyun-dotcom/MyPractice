using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputKeyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        inputDir = new Vector3 (h, v, 0);
    }

    void Move()
    {
        knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }
}
