using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsCountUI : MonoBehaviour
{
    [SerializeField] private Text _gemsText;
    private int _gemsCount;

    public void Pick()
    {
        _gemsCount++;
        _gemsText.text = _gemsCount.ToString();
    }
}
