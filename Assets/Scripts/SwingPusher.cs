using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SwingPusher : MonoBehaviour
{
    [SerializeField] private Vector3 _force;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Push()
    {
        _rigidBody.AddForce(_force, ForceMode.Impulse);
    }
}