using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject[] ColorPrefab;

    float spawnsTime;
    public float defaultTime = 0.05f;

    public GameController controller;
    
    void Update()
    {
        if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {
            CircleCreat();
            spawnsTime = 0;
        }
        spawnsTime += Time.deltaTime;
    }

    void CircleCreat()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition.z = 0;
        

        if (controller._isBlue)
        {
            Instantiate(ColorPrefab[1], mPosition, Quaternion.identity);
        }
        else if (controller._isBlack)
        {
            Instantiate(ColorPrefab[0], mPosition, Quaternion.identity);
        }
        else if (controller._isGreen)
        {
            Instantiate(ColorPrefab[2], mPosition, Quaternion.identity);
        }

    }

}
