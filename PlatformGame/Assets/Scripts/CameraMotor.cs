using System;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private readonly float _horzExtent = Camera.main.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height;
    public Transform _lookAt;
    public float _boundX = 0.15f;
    public float _boundY = 0.05f;
    
    private void LateUpdate()
    {
        Vector3 _delta = Vector3.zero;
        
        var _position = transform.position;
        var _lookAtPosition = _lookAt.position;
        //  Check if the camera is inside the bounds on the X axis
        _delta.x = MovedDelta(_position.x, _lookAtPosition.x, _boundX);
        
        //  Check if the camera is inside the bounds on the Y axis
        _delta.y = MovedDelta(_position.y, _lookAtPosition.y, _boundY);
        
        // Move camera
        transform.position = _position + new Vector3(_delta.x, _delta.y, 0);
    }

    private float MovedDelta(float _positionComponent, float _lookAtComponent, float _boundComponent)
    {
        float _deltaComponent = _lookAtComponent - _positionComponent;
        if (_deltaComponent > _boundComponent || _deltaComponent < -_boundComponent)
        {
            if (_positionComponent < _lookAtComponent) return _deltaComponent - _boundComponent;
            return _deltaComponent + _boundComponent;
        }

        return 0;
    }
}
