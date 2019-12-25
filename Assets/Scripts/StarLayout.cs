using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLayout : MonoBehaviour
{
    [SerializeField]
    private GameObject[] starLayouts;

    private LevelStars levelStar;

    // Start is called before the first frame update
    void Start()
    {
        levelStar = FindObjectOfType<LevelStars>();

        for (int i = 0; i < starLayouts.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                starLayouts[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }

        UpdateStar();
    }

    // Update is called once per frame
    void UpdateStar()
    {
        for (int i = 0; i < starLayouts.Length; i++)
        {
            for (int j = 0; j < levelStar.StarValues[i]; j++)
            {
                starLayouts[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
}
