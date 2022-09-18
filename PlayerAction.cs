using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGemCollision = new UnityEvent();
    [SerializeField] private UnityEvent _onEnemyCollision = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            _onGemCollision.Invoke();    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _onEnemyCollision.Invoke();
            Debug.Log("Enemy collision");
        }
    }
}
