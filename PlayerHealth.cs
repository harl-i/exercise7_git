using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    private int heartsCount;

    private void Start()
    {
        heartsCount = _hearts.Length;
    }

    public void GetDamage()
    {
        heartsCount--;
        UpdateHeartsBar();
    }

    private void UpdateHeartsBar()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < heartsCount)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }

}
