using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    // Set variable values in AsteroidSpawner prefab in Unity scene
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
            int posX = Random.Range(0, maxX) - 50;
            int posY = Random.Range(0, maxY) - 50;
            int posZ = Random.Range(0, maxZ) - 50;

            // Generate random X/Y/Z spawn rotation
            int rotX = Random.Range(0, 360);
            int rotY = Random.Range(0, 360);
            int rotZ = Random.Range(0, 360);

            // Instantiate that asteroid in a random position
            GameObject asteroid = (GameObject)Instantiate(asteroids[asteroidNumber], new Vector3(posX, posY, posZ), Quaternion.Euler(rotX, rotY, rotZ));

            // Increase scale of asteroid (1/1/1 => 3/3/3)
            asteroid.transform.localScale += new Vector3(2, 2, 2);

            // Give asteroid random velocity (between min and max velocity) in the direction it is facing
            float velocity = Random.Range(minVelocity, maxVelocity);
            asteroid.GetComponent<Rigidbody>().velocity = new Vector3(posX, posY, posZ) * (velocity / 5);

            // Give asteroids a slight random rotation
            asteroid.GetComponent<Rigidbody>().angularVelocity = new Vector3(posX, posY, posZ) * (velocity / 50);
        }
    }
}
