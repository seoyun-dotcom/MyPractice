using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform cat;
    public Vector3 offset; // 기준점을 맞추기 위한 변수

    void Update()
    {
        //cat.position이라고 써도된다. cat이 Transform타입이기 때문에.
        transform.position = cat.transform.position + offset;
    }
}
