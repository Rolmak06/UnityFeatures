using UnityEngine;

public class LerpScale : LerpBase
{
    [SerializeField] bool _useCurrentAsStartValue = false;
    [SerializeField] bool _useRatio;
    [SerializeField] float _scaleRatio;
    [SerializeField] Vector3 _startScale = new(0, 0, 0);
    [SerializeField] Vector3 _targetScale = new(1, 1, 1);
    

    private void Start()
    {
        if(_useRatio)
        {
            _useCurrentAsStartValue = true;
            _startScale = transform.localScale;
            _targetScale = _startScale * _scaleRatio;
        }

        else if(_useCurrentAsStartValue)
        {
            _startScale = transform.localScale;
        }

    }

    public override void Lerp()
    {
        Vector3 startScale = _useCurrentAsStartValue ? transform.localScale : _startScale;
        Vector3 targetedScale = _targetScale;

        _startedRoutine = StartCoroutine(LerpInTime(() => transform.localScale = Vector3.Lerp(startScale, targetedScale, GetNormalizedTime())));
    }

    public override void LerpReverse()
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetedScale = _startScale;

        _startedRoutine = StartCoroutine(LerpInTime(() => transform.localScale = Vector3.Lerp(startScale, targetedScale, GetNormalizedTime())));
    }
}
