using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeSquare : MonoBehaviour
{
    public Image occupideImage;
    private void Start()
    {
        occupideImage.gameObject.SetActive(false);
    }

}
