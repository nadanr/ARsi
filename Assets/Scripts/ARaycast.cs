using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARaycast : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollbar;
    [SerializeField]
    private Material outlineMaterial, defaultMaterial;
    
    private Camera mainCam;
    private IRayInput rayInput;
    private Pieces chosenPieces;
    private MovePiece movePiece;
    private GameObject plate;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        movePiece = scrollbar.GetComponent<MovePiece>();
    #if UNITY_EDITOR
        //rayInput = new EditorInput();
        rayInput = new CameraInput(mainCam);

    #elif UNITY_ANDROID
        rayInput = new AndroidInput(mainCam);

    #endif

    }

    private void Update()
    {
        if(rayInput.Click)
        {
            chosenPieces = plate.GetComponent<Pieces>();
            if(chosenPieces != null)
            {
                movePiece.SetPiece(chosenPieces);
                SetPlateMaterial(false);
            }
            else
            {
                movePiece.FreePiece();
            }
        }

        scrollbar.gameObject.SetActive(chosenPieces != null ? true : false);
    }

    private void FixedUpdate()
    {
        Ray ray = mainCam.ScreenPointToRay(rayInput.Position);//Input.GetTouch(0).position);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.tag == "Model")
            {
                //chosenPieces = null;
                if (plate == hit.collider.gameObject) return;

                if (plate != null)
                {
                    SetPlateMaterial(false);
                    plate = null;
                    return;
                }

                plate = hit.collider.gameObject;
                //chosenPieces = hit.collider.GetComponent<Pieces>();
                if(plate.GetComponent<Pieces>() != chosenPieces)
                    SetPlateMaterial(true);
                //movePiece.SetPiece(chosenPieces);
            }
            else
            {
                                
                //movePiece.FreePiece();
            }

        }
    }

    private void SetPlateMaterial(bool outline)
    {
        plate.GetComponent<Renderer>().material = outline ? outlineMaterial : defaultMaterial;
    }
}
