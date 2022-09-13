using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _WalkingSpeed = 7.5f;
    [SerializeField] private float _RunningSpeed = 11.5f;
    [SerializeField] private float _JumpSpeed = 8.0f;
    [SerializeField] private float _Gravity = 20.0f;
    [SerializeField] private Camera _PlayerCamera;
    [SerializeField] private float _LookSpeed = 2.0f;
    [SerializeField] private float _LookXLimit = 90f;

    private CharacterController _CharacterController;
    private Vector3 _MoveDirection = Vector3.zero;
    private float _RotationX = 0;

    [HideInInspector]
    public bool canMove { get; private set; }

    public static PlayerController myPlayer { get; private set; }

    private void Awake()
    {
        if (myPlayer)
        {
            Destroy(gameObject);
            return;
        }
        myPlayer = this;
        canMove = true;
    }
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? _RunningSpeed : _WalkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? _RunningSpeed : _WalkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _MoveDirection.y;
        _MoveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && _CharacterController.isGrounded)
        {
            _MoveDirection.y = _JumpSpeed;
        }
        else
        {
            _MoveDirection.y = movementDirectionY;
        }

        if (!_CharacterController.isGrounded)
        {
            _MoveDirection.y -= _Gravity * Time.deltaTime;
        }

        _CharacterController.Move(_MoveDirection * Time.deltaTime);

        if (canMove)
        {
            _RotationX += -Input.GetAxis("Mouse Y") * _LookSpeed;
            _RotationX = Mathf.Clamp(_RotationX, -_LookXLimit, _LookXLimit);
            _PlayerCamera.transform.localRotation = Quaternion.Euler(_RotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _LookSpeed, 0);
        }
    }

    public void SetCanMoveTrue()
    {
        canMove = true;
    }
    public void SetCanMoveFalse()
    {
        canMove = false;
    }
}
