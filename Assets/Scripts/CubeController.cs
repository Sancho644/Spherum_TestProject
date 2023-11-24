using UnityEngine;

public class CubeController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    private const float Delta = 0.5f;

    [SerializeField] private CubeTypes _cubeType;
    [SerializeField] private float _speed;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MoveCube();
        TransformLimiter();
    }

    private void MoveCube()
    {
        if (Input.GetAxis(_cubeType + Horizontal) > 0)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        if (Input.GetAxis(_cubeType + Horizontal) < 0)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetAxis(_cubeType + Vertical) > 0)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        if (Input.GetAxis(_cubeType + Vertical) < 0)
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
    }

    private void TransformLimiter()
    {
        Vector3 cameraDistance = transform.position - _camera.transform.position;
        float distance = -Vector3.Project(cameraDistance, _camera.transform.forward).y;

        Vector3 leftBot = _camera.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = _camera.ViewportToWorldPoint(new Vector3(1, 1, distance));

        float x_left = leftBot.x + Delta;
        float x_right = rightTop.x - Delta;
        float z_top = rightTop.z - Delta;
        float z_bot = leftBot.z + Delta;

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.z = Mathf.Clamp(clampedPos.z, z_bot, z_top);
        transform.position = clampedPos;
    }
}