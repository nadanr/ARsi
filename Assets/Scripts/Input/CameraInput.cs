using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : IRayInput
{
    private Camera mainCam;

    public bool Click => Input.GetMouseButtonDown(0);

    public Vector2 Position => new Vector2(mainCam.scaledPixelWidth/2, mainCam.scaledPixelHeight/2);

    public CameraInput (Camera _mainCam)
    {
        mainCam = _mainCam;
    }
}
