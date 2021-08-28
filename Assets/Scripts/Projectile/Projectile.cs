using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary> Множитель силы воздействия на снаряд. </summary>
    [SerializeField] private float forceСoefficient;
    private Rigidbody rigidBody;
    private Transform currentTransform;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move() 
    {       
        if (rigidBody) 
        {
            Vector3 force = currentTransform.forward * forceСoefficient;
            rigidBody.AddForce(force, ForceMode.Force);
        }        
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
