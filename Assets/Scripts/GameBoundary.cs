using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    [SerializeField] private EventHolder eventHolder;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>())
        {
            eventHolder.CallCollisionWithOtherGameObject();
            Destroy(other.gameObject);
        }
    }
}
