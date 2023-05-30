using DefaultNamespace;
using Entity;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankController : MonoBehaviour
{

    private static TankController instance;
    public static TankController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<TankController>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;

    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(Random.Range(0, 2), Random.Range(0, 2), 0),
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _cameraController = camera.GetComponent<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    private void FixedUpdate()
    {
        float minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float maxX = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float minY = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        float maxY = Camera.main.ViewportToWorldPoint(Vector3.one).y;
        Renderer renderer = GetComponent<Renderer>();
        float width = renderer.bounds.size.x;
        float height = renderer.bounds.size.y;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x - width / 2 > minX)
            {
                Move(Direction.Left);
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y - height / 2 > minY)
            {
                Move(Direction.Down);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x + width / 2 < maxX)
            {
                Move(Direction.Right);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y + height / 2 < maxY)
            {
                Move(Direction.Up);
            }
        }


        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        //_cameraController.Move(_tank.Position);
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        var b = new Bullet
        {
            Direction = _tank.Direction,
            Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b);
    }

    public Tank getTank()
    {
        return _tank;
    }
}