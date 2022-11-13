using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour
{
    public GameObject[] ColorPrefab;

    float spawnsTime;
    public float defaultTime = 0.05f;

    public GameController controller;

    void Update()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {
            CircleCreat();
            spawnsTime = 0;
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                UnityEngine.Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Moved)
                {
                    if (spawnsTime >= defaultTime)
                    {
                        Vector3 mPosition = Camera.main.ScreenToWorldPoint(touch.position);
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

                        spawnsTime = 0;
                    }
                }
            }
        }
#elif UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {
            CircleCreat();
            spawnsTime = 0;
        }

#endif



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
