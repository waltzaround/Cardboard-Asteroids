using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public int numAsteroids;
    public int numAsteroidTypes;
    public GameObject[] asteroids;
    public int maxX;
    public int maxY;
    public int maxZ;
    public int minVelocity;
    public int maxVelocity;

    // Use this for initialization
    void Start() {
        SpawnAsteroids();
    }

    void SpawnAsteroids() {
        for (int i = 0; i < numAsteroids; i++) {
            // Choose a random asteroid
            int asteroidNumber = Random.Range(0, numAsteroidTypes);

            // Generate random X/Y/Z spawn location
            int posX = Random.Range(0, maxX);
            int posY = Random.Range(0, maxY);
            int posZ = Random.Range(0, maxZ);

            // Generate random X/Y/Z spawn rotation
            int rotX = Random.Range(0, 360);
            int rotY = Random.Range(0, 360);
            int rotZ = Random.Range(0, 360);

            // Instantiate that asteroid in a random position
            GameObject asteroid = (GameObject)Instantiate(asteroids[asteroidNumber], new Vector3(posX, posY, posZ), Quaternion.Euler(rotX, rotY, rotZ));
            
            // Give asteroid random velocity (between min and max velocity) in the direction it is facing
            int velocity = Random.Range(minVelocity, maxVelocity);
            asteroid.GetComponent<Rigidbody>().velocity = Vector3.forward * velocity;
        }
    }
}
