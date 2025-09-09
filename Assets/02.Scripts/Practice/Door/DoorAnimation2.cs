using UnityEngine;

public class DoorAnimation2 : MonoBehaviour
{
    private Animator animator;

    public GameObject doorLock;
    public NumberKeyPad numberKeypad;

    public bool isDoorOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(true);
            //animator.SetTrigger(openKey);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numberKeypad.keypadNumber = "";
            doorLock.SetActive(false);

            // 문이 열린 상태에서 트리거 벗어날때만 도어락창 닫기
            if (isDoorOpened) 
            {
                animator.SetTrigger("Close");
                isDoorOpened = false;
            }

        }
    }

    // 외부에서 문이 열릴 때 호출 (예: NumberKeyPad.cs에서)
    public void NotifyDoorOpened()
    {
        isDoorOpened = true;
    }

}
