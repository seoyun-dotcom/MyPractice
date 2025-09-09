using UnityEngine;

public class MathDot : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    private void Start()
    {
        //float result = Vector3.Dot(vecA, vecB); // Cos(theta) 값
        float result = Vector3.Angle(vecA, vecB); // 각도 값

        Debug.Log($"벡터의 끼인각 : {result}");
    }
}
