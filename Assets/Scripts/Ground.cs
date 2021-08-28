using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private EventHolder eventHolder;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            eventHolder.CallCollisionWithOtherGameObject();
            Destroy(collision.gameObject);
        }
    }
}
