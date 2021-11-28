using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;

    public Transform[] spawnPoints; //*tanpa factory pattern *bisa ditambahkan untuk mengatur posisi spawn pada factorymethod
    //public GameObject enemy; //*tanpa factory pattern

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } } //*factory pattern

    private void Start()
    {
        //Mengeksekusi fungsi Spawn setiap beberapa detik sesuai dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        //mengecheck delay antar spawn
        //Debug.Log(Time.unscaledTime);

        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random *tanpa factory pattern *bisa ditambahkan untuk mengatur posisi spawn pada factorymethod
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Menduplikasi enemy *tanpa factory pattern
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        //*factory pattern
        int spawnEnemy = Random.Range(0, 3);

        //Memduplikasi enemy *factory pattern
        Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex]);
    }
}
