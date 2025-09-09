using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject doorLock;

    public string passWord;//비밀번호 설정
    public string keypadNumber;//입력한 숫자

    public void OnInputNumber(string numString)
    {
        keypadNumber += numString;
        Debug.Log($"{numString} 입력 -> 현재 입력 : {keypadNumber}");
    }

    public void OnCheckNumber()
    {
        if ( keypadNumber == passWord )
        {
            Debug.Log("문 열림");
            doorAnim.SetTrigger("Open");
            doorLock.SetActive(false);

            // 문 열린 상태 알려주기
            //isDoorOpened = true; 랑 같은말
            doorAnim.GetComponent<DoorAnimation2>().NotifyDoorOpened();
        }
        else
        {
            keypadNumber = "";
            Debug.Log("비밀 번호 오류");
        }
    }
}
