using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    private int _heartsCount;

    private void Start()
    {
        _heartsCount = _hearts.Length;
    }

    public void TakeDamage()
    {
        if (_heartsCount > 0)
            _heartsCount--;

        UpdateHeartsBar();
    }

    private void UpdateHeartsBar()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            _ = i < _heartsCount ? _hearts[i].enabled = true : _hearts[i].enabled = false;
        }
    }

}
