using UnityEngine;

public class Player : MonoBehaviour/*, ITakeDamage, ITakeHp */
{   
    //[SerializeField] private int _hp = 4;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _acceleration = 10;

    private int _damage = 1;
    //private bool _isAlive = false;
    private bool _isGrounded;
    private IMove _direction;
    private JumpTransform _jump;
   // private Fire _fire;

    public void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void Start()
    {
        _direction = new AccelerationMove(transform, _speed, _acceleration);
        _jump = new JumpTransform(transform, _speed);
        //_fire = new Fire();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }

    private void Update()
    {
        //_jump.Jump(Input.GetAxis("Vertical"), Time.deltaTime);

        //if (Input.GetMouseButtonDown(0))
        //    _fire.FireSword();

        _direction.Move(Input.GetAxis("Horizontal"),  Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_direction is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (_direction is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            takeDamage.TakeDamage(_damage);
        }
    }

    //public void TakeDamage(int damage)
    //{
    //    if (_isAlive == true)
    //    {
    //        _hp -= damage;
    //        if (_hp <= 0)
    //        {
    //            Destroy();
    //        }
    //    }
    //}

    //public void Destroy()
    //{
    //    _isAlive = false;
    //    Time.timeScale = 0f;
    //}

    //public void TakeHp(int health)
    //{
    //    if (_isAlive == true)
    //    {
    //        _hp += health;
    //    }
    //}

}
