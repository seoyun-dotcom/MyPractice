using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))// 앞으로 가는 기능
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))// 뒤로 가는 기능
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.D))// 오른쪽으로 가는 기능
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))// 왼쪽으로 가는 기능
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
