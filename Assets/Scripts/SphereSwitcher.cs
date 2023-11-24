using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SphereSwitcher : MonoBehaviour
{
    private const string Level2Name = "Level_2";

    [SerializeField] private GameObject _sphereParent;

    private DistanceListener _distanceListener;

    private bool _initialized;

    [Inject]
    private void Construct(DistanceListener distanceListener)
    {
        _distanceListener = distanceListener;
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (_distanceListener.RoundDistance == 0)
            return;

        if (_distanceListener.RoundDistance < 1)
        {
            SceneManager.LoadScene(Level2Name);
        }

        if (_distanceListener.RoundDistance < 2)
        {
            _sphereParent.SetActive(true);
        }

        if (_distanceListener.RoundDistance > 2)
        {
            _sphereParent.SetActive(false);
        }
    }
}