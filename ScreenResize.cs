using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResize : MonoBehaviour
{
    public static float widthCam;
    public static float offset = 0.2f;
    public static float minX, maxX;
    public static float minX_offset, maxX_offset;
    public static int number_of_spawners;
    public static float width;

    private Camera cam;


    private void Awake()
    {
        cam = Camera.main;

        widthCam = cam.orthographicSize * cam.aspect;
        minX = 0 - widthCam;
        maxX = 0 + widthCam;

        minX_offset = minX + offset;
        maxX_offset = maxX - offset;

        width = Mathf.Abs(minX_offset) + Mathf.Abs(maxX_offset);
        number_of_spawners = Mathf.FloorToInt(width / 0.5f);

    }

    void Update()
    {
        widthCam = cam.orthographicSize * cam.aspect;
        minX = 0 - widthCam;
        maxX = 0 + widthCam;

        minX_offset = minX + offset;
        maxX_offset = maxX - offset;

        width = Mathf.Abs(minX_offset) + Mathf.Abs(maxX_offset);
        number_of_spawners = Mathf.FloorToInt(width / 0.5f);
    }
}
