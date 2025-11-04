using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;

    private string MouseXInput = "Mouse X";
    private string MouseYInput = "Mouse Y";

    private float _aroundXRotation;
    private float _aroundYRotation;

    private bool _isGameStarted;

    private float _minX = -20f;
    private float _maxX = 20f;
    private float _minY = -80f;
    private float _maxY = -40f;

    private void Awake()
    {
        _aroundYRotation = transform.eulerAngles.y;
        _aroundXRotation = transform.eulerAngles.x;
    }

    private void Update()
    {
        float mouseDeltaX = Input.GetAxis(MouseXInput) * _sensitivity;
        float mouseDeltaY = Input.GetAxis(MouseYInput) * _sensitivity;

        _aroundXRotation += mouseDeltaX;
        _aroundYRotation += mouseDeltaY;
        
        _aroundYRotation = Mathf.Clamp(_aroundYRotation, _minY, _maxY);
        _aroundXRotation = Mathf.Clamp(_aroundXRotation, _minX, _maxX);

        if (_isGameStarted == false) {
            _aroundYRotation = 0;
            _aroundXRotation = 0;
            _isGameStarted = true;
        }

        Quaternion rotation = Quaternion.Euler(-_aroundYRotation, 0, _aroundXRotation);
        transform.rotation = rotation;
    }

    private void LateUpdate()
    {
        Vector3 offset = transform.rotation * new Vector3(0, 0, _offset);

        transform.position = _target.position + offset;
    }

    public float GetNormalizedX()
    {
        float midX = (_maxX + _minX) / 2f; // 0
        return (_aroundXRotation - midX) / ((_maxX - _minX) / 2f);
    }

    public float GetNormalizedY()
    {
        float midY = (_maxY + _minY) / 2f; // -60
        return (_aroundYRotation - midY) / ((_maxY - _minY) / 2f);
    }
}