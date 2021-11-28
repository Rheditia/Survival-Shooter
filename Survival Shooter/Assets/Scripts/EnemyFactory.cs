using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] enemyPrefab;

    public GameObject FactoryMethod(int tag, Transform pos)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag], pos.position, pos.rotation);
        return enemy;
    }

}
