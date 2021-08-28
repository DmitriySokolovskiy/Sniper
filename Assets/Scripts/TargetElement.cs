using UnityEngine;

public class TargetElement : MonoBehaviour
{
    [SerializeField] private float enemyScore;
    private EventHolder eventHolder;

    private void Start() 
    {
        eventHolder = FindObjectOfType<EventHolder>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollisionWithProjectile(collision.contacts[0].otherCollider.gameObject.GetComponent<Projectile>());
    }

    private void HandleCollisionWithProjectile(Projectile projectile) 
    {
        if (projectile == null) 
        {
            return;
        }
        
        eventHolder.CallScoreChanged(enemyScore);
        eventHolder.CallCollisionPositionWithTargetUpdated(gameObject.transform.position);
    }
}
