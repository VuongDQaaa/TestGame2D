using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public static FloorSpawner instance;
    [SerializeField] private GameObject leftFloor, rightFloor, movingFloor, fireTurret, iceTurret, gravityTurret;
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
        GenerateLevel();
        GenerateTurret();
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

    void GenerateLevel()
    {
        if (PlayerController.instance.personalScore < 5 && spawnNew == true)
        {
            int random = Random.Range(0, 1);
            if (random == 1)
            {
                GetSpawnPosition();
                Instantiate(movingFloor, position, Quaternion.identity);
            }
            else if (random == 0)
            {
                GeneratFixedFloor();
            }
        }
        else
        {
            GeneratFixedFloor();
        }
    }

    void GenerateTurret()
    {
        if (PlayerController.instance.personalScore > 5 && spawnNew == true)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                if (spawnLeft == true)
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.identity);
                }
                else
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.Euler(0, 0, 90));
                }
            }
            else if (random == 1)
            {
                if (spawnLeft == true)
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.identity);
                }
                else
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.Euler(0, 0, 90));
                }
            }
            else if (random == 2)
            {
                if (spawnLeft == true)
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.identity);
                }
                else
                {
                    GetTurretPosition();
                    Instantiate(gravityTurret, turretPosition, Quaternion.Euler(0, 0, 90));
                }
            }
        }
    }

    void GetSpawnPosition()
    {
        if (PlayerController.instance.personalScore < 10)
        {
            position.y = currentHigh + Random.Range(3f, 5f);
            currentHigh = position.y;
        }
        else
        {
            position.y = currentHigh + Random.Range(4f, 6f);
            currentHigh = position.y;
        }
    }

    void GetTurretPosition()
    {
        turretPosition.y = currentHigh + 2f;
        if (spawnLeft == true)
        {
            turretPosition.x = 2.388631f;
        }
        else
        {
            turretPosition.x = -2.41f;
        }
    }
}
