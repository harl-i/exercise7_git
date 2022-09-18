using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gem : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _targetPositionY = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerPlatformerController>(out PlayerPlatformerController player))
        {
            StartCoroutine(Picked());
        }
    }

    private IEnumerator Picked()
    {
        _animator.SetBool(AnimatorGem.HashAnimationsName.IsPick, true);

        yield return new WaitUntil(() => gameObject.transform.position.y >= _targetPositionY);

        gameObject.SetActive(false);
    }
}
