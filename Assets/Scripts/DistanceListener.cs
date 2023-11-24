using System;
using UnityEngine;
using Zenject;

public class DistanceListener : MonoBehaviour
{
    [SerializeField] private Transform _redCubeTransform;
    [SerializeField] private Transform _greenCubeTransform;

    private CubeDistanceView _cubeDistanceView;

    private float _distance;
    private bool _initialized;
    
    public float RoundDistance{ get; private set; }

    [Inject]
    private void Construct(CubeDistanceView cubeDistanceView)
    {
        _cubeDistanceView = cubeDistanceView;

        _initialized = true;
    }

    private void Update()
    {
        GetDistance();
    }

    private void GetDistance()
    {
        if (_initialized)
        {
            _distance = Vector3.Distance(_redCubeTransform.position, _greenCubeTransform.position);

            RoundDistance = (float)Math.Round(_distance, 1);

            _cubeDistanceView.SetValueText(RoundDistance);
        }
    }
}