using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"현재까지 {Movement.coinCount}개의 코인 획득!!");

            Movement.coinCount++;

            Destroy(this.gameObject);
        }
    }
}
