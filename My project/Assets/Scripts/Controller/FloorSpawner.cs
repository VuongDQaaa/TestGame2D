using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public static FloorSpawner instance;
    [SerializeField] private GameObject leftFloor, rightFloor, movingFloor;
    [SerializeField] private GameObject[] turret;
    public bool spawnLeft;
    public bool spawnNew;
    public float currentHigh;
    Vector3 position, turretPosition;
    void MakeIsntance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
        MakeIsntance();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnNew = false;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTurret();
        GenerateLevel();
    }

    void GeneratFixedFloor()
    {
        if (spawnNew == true && spawnLeft == true)
        {
            GetSpawnPosition();
            Instantiate(leftFloor, position, Quaternion.identity);
            spawnNew = false;
            spawnLeft = false;
        }
        if (spawnNew == true && spawnLeft == false)
        {
            GetSpawnPosition();
            Instantiate(rightFloor, position, Quaternion.identity);
            spawnNew = false;
            spawnLeft = true;
        }
    }

    void GenerateMovingFloor()
    {
        if (spawnNew == true)
        {
            GetSpawnPosition();
            Instantiate(movingFloor, position, Quaternion.identity);
            spawnNew = false;
        }
    }

    void GenerateLevel()
    {
        if (PlayerController.instance.personalScore <= 5)
        {
            GeneratFixedFloor();
        }
        else
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                GenerateMovingFloor();
            }
            else
            {
                GeneratFixedFloor();
            }
        }
    }

    void GenerateTurret()
    {
        if (spawnNew == true && PlayerController.instance.personalScore > 5)
        {
            GetTurretPosition();
            int random = Random.Range(0, 3);
            if (spawnLeft == true)
            {
                Instantiate(turret[random], turretPosition, Quaternion.Euler(0,0,-90));
            }
            else
            {
                Instantiate(turret[random], turretPosition, Quaternion.Euler(0,0,90));
            }
        }
    }

    void GetSpawnPosition()
    {
        if (PlayerController.instance.personalScore <= 10)
        {
            currentHigh = currentHigh + Random.Range(3f, 5f);
        }
        else
        {
            currentHigh = currentHigh + Random.Range(4f, 6f);
        }
        position.y = currentHigh;
    }

    void GetTurretPosition()
    {
        turretPosition.y = currentHigh + Random.Range(1f, 2f);
        if (spawnLeft == false)
        {
            turretPosition.x = 2.36f;
        }
        else
        {
            turretPosition.x = -2.36f;
        }
    }
}
