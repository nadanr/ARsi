using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    [SerializeField]
    private float[] steps;
    [SerializeField]
    private int answer;
    [SerializeField]
    private GameObject piece;

    public float Progress { get; set; } = 0f;
    public float[] Steps { get => steps; }
    public int Answer { get => answer; }
    public GameObject Piece { get => piece; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
