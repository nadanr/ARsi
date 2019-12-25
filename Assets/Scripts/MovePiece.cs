using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePiece : MonoBehaviour
{
    enum Mode
    {
        SCALE,
        TRANSLATE,
        STEPS
    }

    [SerializeField]
    private float maxLength = 0f;
    [SerializeField]
    private float maxSize = 0f;
    [SerializeField]
    private Mode mode;

    private Pieces heldPiece = null;
    private float progress;
    private Scrollbar scrollbar;
    private float restHeight = -85;

    private void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    public void SetPiece(Pieces piece)
    {
        heldPiece = piece;
        scrollbar.value = piece.Progress;
    }

    public void SetProgress()
    {
        heldPiece.Progress = scrollbar.value;
    }

    private void Update()
    {
        if (heldPiece != null && scrollbar != null)
        {
            switch (mode)
            {
                case Mode.SCALE:
                    heldPiece.Piece.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1f, 1f, maxSize), scrollbar.value);
                    heldPiece.Piece.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, 0f, maxLength), scrollbar.value);
                    break;
                case Mode.TRANSLATE:
                    heldPiece.Piece.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(heldPiece.transform.localPosition.x, maxLength, heldPiece.transform.localPosition.z), scrollbar.value);
                    break;
                case Mode.STEPS:
                    //Debug.Log((int)(scrollbar.value * 10)/2);
                    heldPiece.Piece.transform.localPosition = Vector3.Lerp(heldPiece.Piece.transform.localPosition, new Vector3(heldPiece.transform.localPosition.x, restHeight + heldPiece.Steps[(int)((scrollbar.value * 10)/2)], heldPiece.transform.localPosition.z), scrollbar.value);
                    break;
            }   
            
        }            
    }

    public void FreePiece()
    {
        heldPiece = null;
    }
}
