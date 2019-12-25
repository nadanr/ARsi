using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private SpawnGeometry spawner;
    [SerializeField]
    private Shape shape;

    public void SetSpawner()
    {
        spawner.AcceptShape(shape);
        spawner.Ready();
    }
}
