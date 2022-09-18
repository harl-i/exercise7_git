using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    public UnityEvent OnGemCollision = new UnityEvent();
    public UnityEvent OnEnemyCollision = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            OnGemCollision.Invoke();    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnEnemyCollision.Invoke();
            Debug.Log("Enemy collision");
        }
    }
}
