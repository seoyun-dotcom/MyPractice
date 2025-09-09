
using UnityEngine;

public interface IDropItem
{
    void Grab(Transform grabPos); // 아이템 줍기
    void Use(); // 아이템 사용하기
    void Drop(); // 아이템 버리기
}


