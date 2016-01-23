using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    // Set variable values in AsteroidSpawner prefab in Unity scene
    public int numAsteroids;
    public int numAsteroidTypes;
    // Must reference all different types of asteroid prefabs
    public GameObject[] asteroids;
    public int arenaX;
    public int arenaY;
    public int arenaZ;
    public double minVelocity;
    public double maxVelocity;
    public int scale;

    // Use this for initialization
    void Start() {
        SpawnAsteroids();
    }

    void SpawnAsteroids() {
        for (int i = 0; i < numAsteroids; i++) {
            // Choose a random asteroid from the asteroids array
            int asteroidNumber = Random.Range(0, numAsteroidTypes);

            // Generate random X/Y/Z spawn location
            int posX = Random.Range(0, arenaX) - arenaX / 2;
            int posY = Random.Range(0, arenaY) - arenaY / 2;
            int posZ = Random.Range(0, arenaZ) - arenaZ / 2;

            // Generate random X/Y/Z spawn rotation
            int rotX = Random.Range(0, 360);
            int rotY = Random.Range(0, 360);
            int rotZ = Random.Range(0, 360);

            // Spawn that asteroid in a random position
            GameObject asteroid = (GameObject)Instantiate(asteroids[asteroidNumber], new Vector3(posX, posY, posZ), Quaternion.Euler(rotX, rotY, rotZ));

            // Increase scale of asteroid (1/1/1 default)
            asteroid.transform.localScale += new Vector3(scale, scale, scale);

            // Give asteroid random velocity (between min and max velocity) in the direction it is facing
            float velocity = Random.Range((float)minVelocity, (float)maxVelocity);
            asteroid.GetComponent<Rigidbody>().velocity = new Vector3(posX, posY, posZ) * (velocity / 5);

            // Give asteroids a slight random rotation
            asteroid.GetComponent<Rigidbody>().angularVelocity = new Vector3(posX, posY, posZ) * (velocity / 50);
        }
    }
}
