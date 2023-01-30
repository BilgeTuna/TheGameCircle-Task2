using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float planeWidth;
    [SerializeField] private float moveSmoothTime;
    [SerializeField] private float turnSmoothTime;
    private float speed = 35f;


    private Vector3 _targetPosition;
    private Vector3 _initialMousePos;
    private Vector3 _initialPos;
    private Vector3 _refVector;
    private Vector3 _firstTouchPos;

    private float _screenWidth;
    private float _turnSmoothVelocity;
    private float _angle;
    private float _startYpos;

    private float _targetSpeed;
    private float _currentSpeed;

    private bool _firstTouch;



    private void Awake()
    {
        _screenWidth = Screen.width;
    }

    private void Start()
    {
        _startYpos = transform.position.y;
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        GetInput();
    }

    private void GetInput()
    {
        GetTouchInput();
        UpdatePosition();
    }

    private void GetTouchInput()
    {
        var mousePos = Input.mousePosition;
        var currentPos = transform.position;
        var pos = transform.position;

        if (Input.GetMouseButtonDown(0) || _firstTouch)
        {
            _firstTouch = false;
            _initialMousePos = mousePos;
            _initialPos = pos;
        }

        if (Input.GetMouseButton(0))
        {
            _initialPos.z = currentPos.z;
            var diff = Input.mousePosition.x - _initialMousePos.x;
            var x = (diff / _screenWidth * planeWidth);
            pos = _initialPos + new Vector3(x, 0, 0);
        }

        _targetPosition = pos;
    }

    private void UpdatePosition()
    {
        var newPos = _targetPosition;
        var position = transform.position;

        newPos.y = _startYpos;

        position += Vector3.forward * (_currentSpeed * Time.deltaTime);
        position = Vector3.SmoothDamp(position, _targetPosition, ref _refVector, moveSmoothTime);

        transform.position = position;

        CalculateTurningAngle(newPos);
    }

    private void CalculateTurningAngle(Vector3 newPos)
    {
        var diff = newPos - transform.position;
        var dir = diff.normalized;
        var mag = diff.magnitude;

        var direc = dir.x < 0 ? -1 : 1;
        var targetAngle = direc * mag * 35f;

        if (mag <= 0.5f)
        {
            targetAngle = 0f;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }
}
