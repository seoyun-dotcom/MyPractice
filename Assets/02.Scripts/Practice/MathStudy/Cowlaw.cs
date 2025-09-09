using UnityEngine;

public class Cowlaw : MonoBehaviour
{
    public float cAngle = 60f;
    public float aSide = 1f;
    public float bSide = 1f;

    void Start()
    {
        float cRad = cAngle * Mathf.Deg2Rad;
        float cSide = Mathf.Sqrt(Mathf.Pow(aSide, 2) + Mathf.Pow(bSide, 2) - 2 * aSide * bSide * Mathf.Cos(cRad));

        Debug.Log(cSide);
    }
}