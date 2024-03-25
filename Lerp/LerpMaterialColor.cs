using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class LerpMaterialColor : LerpBase
{
    [SerializeField] Color _targetColor = Color.white;
    [SerializeField] Color _startingColor = Color.white;
    Renderer _renderer;
    Material _instantiatedMaterial;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        if(_renderer)
        {
            _instantiatedMaterial = _renderer.material;
            _startingColor = _instantiatedMaterial.color;
        }
    }
    public override void Lerp()
    {
        if(!_renderer) 
        {
            Debug.Log("No renderer on this object", this);
            return;
        }
        
        Color startLerpColor =_instantiatedMaterial.color;
        _startedRoutine = StartCoroutine(LerpInTime( () =>  _instantiatedMaterial.color = Color.Lerp(startLerpColor, _targetColor, GetNormalizedTime())));
    }

    public override void LerpReverse()
    {
        if(!_renderer) return;

        Color startLerpColor =_instantiatedMaterial.color;
        _startedRoutine = StartCoroutine(LerpInTime( () =>  _instantiatedMaterial.color = Color.Lerp(startLerpColor, _startingColor, GetNormalizedTime())));
    }

}
