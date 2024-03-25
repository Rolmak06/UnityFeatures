using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class LerpBase : MonoBehaviour
{
    [SerializeField, Tooltip("Lerp Duration")] protected float _animationTime = 0.5f;
    [SerializeField, Tooltip("Use this curve to avoid linear lerp")] protected AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField, Tooltip("Does the lerp starts when the object is enabled ?")] protected bool _lerpOnEnable;
    public UnityEvent OnLerpStarted;
    public UnityEvent OnLerpEnded;
    protected float _timeElapsed;
    protected Coroutine _currentLerpRoutine;
    protected Coroutine _startedRoutine;
    protected virtual void OnEnable()
    {
        EnforceCurveNormalization();
        
        if(_lerpOnEnable)
        {
            Lerp();
        }
    }
    public abstract void Lerp();
    public abstract void LerpReverse();

    /// <summary>
    /// Gets the normalized time of the lerp
    /// </summary>
    /// <returns>The lerp time normalized and evaluated by the curve between 0 - 1 </returns>
    protected float GetNormalizedTime()
    {
        return _animationCurve.Evaluate(_timeElapsed / _animationTime);
    }

    protected float GetLerpTime()
    {
        return _timeElapsed;
    }

    /// <summary>
    /// Base coroutine that invokes the action during the defined duration 
    /// </summary>
    /// <param name="lerpMethod">Action to invoke every frame during the lerp, it is the lerp method of your choice</param>
    /// <returns></returns>
    protected virtual IEnumerator LerpInTime(Action lerpMethod)
    {
        // If there is already a coroutine running, stop it
        if(_currentLerpRoutine != null)
        {
            OnLerpEnded?.Invoke();
            StopCoroutine(_currentLerpRoutine);
        }

        // Sets this coroutine as current coroutine
        _currentLerpRoutine = _startedRoutine;
            
        OnLerpStarted?.Invoke();

        _timeElapsed = 0f;

        while(_timeElapsed < _animationTime)
        {
            _timeElapsed += Time.deltaTime;
            
            // Do the actual lerp with defined action or anonymous function
            lerpMethod.Invoke();

            yield return null;
        }

        _currentLerpRoutine = null;

        OnLerpEnded?.Invoke();
    }

 
    /// Enforces curve's normalization to avoid troubles with lerping : first key at (0, 0) and last key at (1, 1)
    private void EnforceCurveNormalization()
    {
        _animationCurve.keys[0].value = 0;
        _animationCurve.keys[0].time = 0;

        _animationCurve.keys[_animationCurve.keys.Length -1].value = 1;
        _animationCurve.keys[_animationCurve.keys.Length -1].time = 1;
    }
}
