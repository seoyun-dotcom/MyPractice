using UnityEngine;

public class Study_Material : MonoBehaviour
{
    public Material mat;
    void Start()
    {
        // this.GetComponent<MeshRenderer>().material = mat; // MeshRenderer에 접근해서 바꾸는 방식

        // this.GetComponent<MeshRenderer>().sharedMaterial = mat; // MeshRenderer에 접근해서 바꾸는 방식

        // this.GetComponent<MeshRenderer>().material.color = Color.green;//Material 데이터를 바꾸는 방식

        // this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;//Material 데이터를 바꾸는 방식


        this.GetComponent<MeshRenderer>().material.color = new Color(255f, 255f, 255f, 255f);

        this.GetComponent<MeshRenderer>().material.color = new Color(130f / 255f, 20f / 255f, 70f / 255f, 1);
    }

    
}
