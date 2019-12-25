using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInput : IRayInput
{
    public bool Click => Input.GetMouseButtonDown(0);

    public Vector2 Position => Input.mousePosition;
}
