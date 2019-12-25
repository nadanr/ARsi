using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    private GameObject scorePanel;
    [SerializeField]
    private GameObject[] stars;
    [SerializeField]
    private Pieces[] pieces;
    [SerializeField]
    private GameObject[] pieceGO;
    [SerializeField]
    private int levelIndex;

    private LevelStars levelStars;

    public void CheckProgress()
    {
        levelStars = FindObjectOfType<LevelStars>();

        int currentStars = 0;
        for (int i = 0; i < pieces.Length; i++)
        {
            currentStars += (pieceGO[i].transform.localPosition.y <= pieces[i].Answer + 5 && pieceGO[i].transform.localPosition.y >= pieces[i].Answer - 5) ? 1 : 0;            
        }

        for (int i = 0; i < currentStars; i++)
        {
            stars[i].SetActive(true);
            levelStars.StarValues[levelIndex]++;
        }

        scorePanel.SetActive(true);
    }
}
