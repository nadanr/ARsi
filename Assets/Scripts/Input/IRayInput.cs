using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRayInput
{
    bool Click { get; }
    Vector2 Position { get; }
}
