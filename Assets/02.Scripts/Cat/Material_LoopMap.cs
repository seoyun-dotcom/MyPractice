using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    //MeshRenderer안에 material에 접근
    private MeshRenderer myrenderer;
    public float offsetSpeed = 0.1f;

    void Start()
    {
        myrenderer = this.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //Vector2.right=(1,0)
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;

        //현재 텍스처 오프셋 값에 offset을 누적해서 조금씩 오른쪽으로 움직이게 만듬
        //"_MainTex": 기본 텍스처 슬롯을 지정하는 키
        myrenderer.material.SetTextureOffset("_MainTex", myrenderer.material.mainTextureOffset + offset);
    }
}
