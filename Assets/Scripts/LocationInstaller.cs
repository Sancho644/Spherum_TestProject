using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private CubeDistanceView _cubeDistanceView;
    [SerializeField] private DistanceListener _distanceListener;

    public override void InstallBindings()
    {
        BindCubeView();
        BindDistanceListener();
    }

    private void BindCubeView()
    {
        Container
            .Bind<CubeDistanceView>()
            .FromInstance(_cubeDistanceView)
            .AsSingle();
    }

    private void BindDistanceListener()
    {
        Container
            .Bind<DistanceListener>()
            .FromInstance(_distanceListener)
            .AsSingle();
    }
}