using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D carRb;

    private float h;

    //성능에 따라 프레임이 다른 콜백 함수
    void Update()
    {
        //Input.GetAxis("Horizontal"): 왼쪽(–1)부터 오른쪽(+1)까지의 부드러운 값을 반환하는 함수
        float h = Input.GetAxis("Horizontal");
        //transform으로 이동하는 방법->떨림현상발생
        transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    //고정프레임인 콜백함수
    void FixedUpdate()
    {
        // Rigidbody의 속도를 활용한 이동
        carRb.linearVelocityX = h * moveSpeed;
    }
}
