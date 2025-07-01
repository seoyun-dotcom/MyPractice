using UnityEngine;

public class DoorAnimation2 : MonoBehaviour
{
    private Animator animator;

    //코드 재사용 가능
    public string openKey;
    public string closeKey;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(openKey);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(closeKey);
        }
    }
}
