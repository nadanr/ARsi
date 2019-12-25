using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    [SerializeField]
    private string dest;
    [SerializeField]
    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        if (levelLoader == null) levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void GoTo()
    {
        StartCoroutine(levelLoader.LoadSyncronously(dest));
    }
}
