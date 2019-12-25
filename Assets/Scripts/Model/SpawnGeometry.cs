using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Shape
{
    CUBE,
    CONE,
    SPHERE,
    ICOSPHERE,
    NONE
}

public class SpawnGeometry : MonoBehaviour
{
    

    [SerializeField]
    private GameObject cube, cone, sphere, icosphere;
    private GameObject preview = null;
    [SerializeField]
    private GameObject targetParent;

    [SerializeField]
    private GameObject clickBtn, cancelBtn;

    private Shape currentShape = Shape.NONE;

    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(false);
        cone.SetActive(false);
        sphere.SetActive(false);
        icosphere.SetActive(false);
        preview?.SetActive(false);
        clickBtn.SetActive(false);
        cancelBtn.SetActive(false);
    }

    public void Ready()
    {
        preview?.SetActive(false);
        clickBtn.SetActive(true);
        cancelBtn.SetActive(true);

        switch (currentShape)
        {
            case Shape.CUBE:
                preview = cube;
                break;
            case Shape.CONE:
                preview = cone;
                break;
            case Shape.SPHERE:
                preview = sphere;
                break;
            case Shape.ICOSPHERE:
                preview = icosphere;
                break;
        }

        preview.SetActive(true);
    }

    public void Cancel()
    {
        preview.SetActive(false);
        clickBtn.SetActive(false);
        cancelBtn.SetActive(false);
        preview = null;
    }

    public void Spawn()
    {
        Instantiate(preview, targetParent.transform, true);
        Cancel();
    }

    public void AcceptShape(Shape shape)
    {
        //if(currentShape != shape)
        //    currentShape = shape;
        //else if(currentShape != shape && currentShape != Shape.NONE)
        //{
        //    preview.SetActive(false);
        //    currentShape = shape;
        //}
        currentShape = shape;
    }
}
