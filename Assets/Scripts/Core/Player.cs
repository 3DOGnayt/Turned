using Assets.Scripts.Move;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _acceleration = 10;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private IMove _direction;

    private int _damage = 1;

    private void Start()
    {
        _direction = new AccelerationMove(transform, _speed, _acceleration);
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        JumpPlayer();
    }

    private void Update()
    {
        AccelerationPlayer();
    }

    private void AccelerationPlayer()
    {
        _direction.Move(Input.GetAxis("Horizontal"), Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_direction is AccelerationMove accelerationMove)
                accelerationMove.AddAcceleration();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (_direction is AccelerationMove accelerationMove)
                accelerationMove.RemoveAcceleration();
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision) => _isGrounded = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.TakeDamage(_damage);
        }
    }
}