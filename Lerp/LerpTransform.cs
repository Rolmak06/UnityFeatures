using UnityEngine;

public class LerpTransform : LerpBase
{
    [SerializeField, Tooltip("Transform to go to, will override target position and rotation if not null")] 
    private Transform _targetTransform;
    
    [SerializeField, Tooltip("Position to go to")] 
    private Vector3 _targetPosition;
    
    [SerializeField, Tooltip("Rotation to go to")] 
    private Vector3 _targetRotation;

    [SerializeField, Tooltip("Absolute will lead your transform at the defined position and rotation, relative will add those values to initial position and rotation")]
    private bool _absolute;

    private Pose _startPose;
    private Pose _targetPose;

    public void Start()
    {
        DefinePoses();

    }

    // Use of poses to simplify and clarify code 
    private void DefinePoses()
    {
        _startPose = new Pose
        {
            position = transform.position,
            rotation = transform.rotation
        };

        if (_targetTransform != null)
        {
            _targetPose = new Pose
            {
                position = _targetTransform.position,
                rotation = _targetTransform.rotation
            };
        }

        else
        {
            _targetPose = new Pose
            {
                position = _absolute ? _targetPosition : transform.position + _targetPosition,
                rotation = _absolute ? Quaternion.Euler(_targetRotation) : Quaternion.Euler(transform.eulerAngles + _targetRotation)
            };
        }
    }

    /// <summary>
    /// Lerps position and rotation from initial transform's values to targeted position and rotation 
    /// </summary>
    public override void Lerp()
    {
        Pose startLerpPose = new Pose
        {
            position = transform.position,
            rotation = transform.rotation
        };

        StartCoroutine(LerpInTime(
            () => transform.SetPositionAndRotation
                (
                    Vector3.Lerp(startLerpPose.position, _targetPose.position, GetNormalizedTime()),
                    Quaternion.Lerp(startLerpPose.rotation, _targetPose.rotation, GetNormalizedTime())
                )
                ));
    }

    /// <summary>
    /// Lerps back to initial position and rotation
    /// </summary>
    public override void LerpReverse()
    {
        Pose startLerpPose = new Pose
        {
            position = transform.position,
            rotation = transform.rotation
        };

        StartCoroutine(LerpInTime(
            () => transform.SetPositionAndRotation
                (
                    Vector3.Lerp(startLerpPose.position, _startPose.position, GetNormalizedTime()),
                    Quaternion.Lerp(startLerpPose.rotation, _startPose.rotation, GetNormalizedTime())
                )
                ));
    }


}
