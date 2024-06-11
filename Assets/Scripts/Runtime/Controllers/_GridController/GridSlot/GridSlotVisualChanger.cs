using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlotVisualChanger : MonoBehaviour
{
    [SerializeField] private GameObject _foreGroundImage;

    public void SetActivenessOfForeGroundImageGo(bool isActive)
    {
        _foreGroundImage.SetActive(isActive);
    }
}
