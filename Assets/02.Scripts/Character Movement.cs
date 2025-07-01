using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;

    public float moveSpeed;

    private float h;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 키 입력
    }

    void FixedUpdate()
    {
        characterRb.linearVelocityX = h * moveSpeed; // 물리적인 이동
    }
}
