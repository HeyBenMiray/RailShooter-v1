using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public int damage = 25;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit: " + other.name);

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            Debug.Log("Enemy is found.");
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("..");
        }
    }
}