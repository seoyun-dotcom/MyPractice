using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    // isTrigger = false일 경우 호출
    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{this.gameObject.name} Collision Enter");
    }

    // isTrigger = true일 경우 호출
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.gameObject.name} Trigger Enter");

    }
}