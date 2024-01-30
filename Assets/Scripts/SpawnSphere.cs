using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    [SerializeField] Vector3 centerLocation;
    public int numberOfSpheres;
    private void Start()
    {
        GameManager.instance.Restart();
        numberOfSpheres = GameManager.instance.ballsLeft;
        LaunchNextWave();
    }
    void Spawn()
    {
        for(int index = 0; index < numberOfSpheres; index++ )
        {
            Instantiate(spherePrefab, centerLocation+
                new Vector3(0, Random.Range(0, 2), Random.Range(-1.8f, 1.8f)),
                Quaternion.identity);
        }
    }
    public void LaunchNextWave()
    {
        //CountDown
        Spawn();
    }
}
