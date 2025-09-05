using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    void Update()
    {
        // (현재위치, 목표위치, 이동 비율)
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothValue);
    }
}