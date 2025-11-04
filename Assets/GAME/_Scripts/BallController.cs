using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private Rotator _target;
    [SerializeField] private float _force;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckForLoose();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.forward * _target.GetNormalizedY() * _force, ForceMode.Force);
        _rigidbody.AddForce(Vector3.right * _target.GetNormalizedX() * _force, ForceMode.Force);
    }

    private void CheckForLoose()
    {
        if (transform.position.y > -6)
            return;

        transform.gameObject.SetActive(false);
        Debug.Log("Вы проиграли!");
    }
}