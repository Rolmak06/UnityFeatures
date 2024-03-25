using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LerpAudioSource : LerpBase
{
    [SerializeField] private float _targetValue;
    [SerializeField, Tooltip("Lerp pitch instead of volume ?")] private bool pitch;
    private AudioSource _source;
    private float _startValue;

    private void Start()
    {
        _source = GetComponent<AudioSource>();

        if(pitch)
        {
            _startValue = _source.pitch;
        }

        else
        {
            _startValue = _source.volume;
        }
    }
    public override void Lerp()
    {
        if(pitch)
        {
            float startValue = _source.pitch;
            _startedRoutine = StartCoroutine(LerpInTime(() => _source.pitch = Mathf.Lerp(startValue, _targetValue, GetNormalizedTime())));
        }

        else
        {
            float startValue = _source.volume;
            _startedRoutine = StartCoroutine(LerpInTime(() => _source.volume = Mathf.Lerp(startValue, _targetValue, GetNormalizedTime())));
        }
    }

    public override void LerpReverse()
    {
        if(pitch)
        {
            float startValue = _source.pitch;
            _startedRoutine = StartCoroutine(LerpInTime(() => _source.pitch = Mathf.Lerp(startValue, _startValue, GetNormalizedTime())));
        }

        else
        {
            float startValue = _source.volume;
            _startedRoutine = StartCoroutine(LerpInTime(() => _source.volume = Mathf.Lerp(startValue, _startValue, GetNormalizedTime())));
        }
    }

    
}
