using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public float moveSpeed;
    private float h;

    public float jumpPower = 10f;
    private bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 키 입력
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        Flip();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;

        renderers[2].gameObject.SetActive(false); // Jump
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGround = false;

        renderers[0].gameObject.SetActive(false); // Idle
        renderers[1].gameObject.SetActive(false); // Run
        renderers[2].gameObject.SetActive(true); // Jump
    }

    /// <summary>
    /// Move 기능
    /// </summary>
    void Move()
    {
        if (!isGround)
            return;

        if (h != 0)// 움직일 때
        {
            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(true); // Run
            renderers[2].gameObject.SetActive(false); // Jump

            //rigidbody는 물리적이동이라 꼭 FixedUpdate에서 실행해주기
            characterRb.linearVelocityX = h * moveSpeed; // 물리적인 이동
        }

        else//h가 0일 때 실행되는 코드
        {
            renderers[0].gameObject.SetActive(true); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(false); // Jump
        }
    }

    /// <summary>
    /// 움직임에따른 좌우반전 Flip 기능
    /// </summary>
    void Flip()
    {
        if (h > 0)//오른쪽으로 이동 중
        {
            //flipX = false → 원래 스프라이트 방향 그대로 (오른쪽 보기)
            renderers[0].flipX = false;
            renderers[1].flipX = false;
            renderers[2].flipX = false;
        }
        else if (h < 0)
        {
            //flipX = true → 좌우 반전됨 (왼쪽 보기)
            renderers[0].flipX = true;
            renderers[1].flipX = true;
            renderers[2].flipX = true;
        }
    }

    /// <summary>
    /// Y방향으로(위로) 점프하는 기능
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(false); // Run
            renderers[2].gameObject.SetActive(true); // Jump
        }
    }
}

