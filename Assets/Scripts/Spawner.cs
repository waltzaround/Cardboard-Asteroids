using UnityEngine;

public class Spawner : MonoBehaviour {

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
    public int safeRadius;
    public GameObject player;

    // Use this for initialization
    void Start() {
        SpawnAsteroids();
    }

    void SpawnAsteroids() {
        for (int i = 0; i < numAsteroids; i++) {
            // Choose a random asteroid from the asteroids array
            int asteroidNumber = Random.Range(0, numAsteroidTypes);

            // Generate random X/Y/Z spawn location outside of player's safe radius
            float posX = Random.Range(player.transform.position.x + safeRadius, player.transform.position.x + arenaX / 2);
            float posY = Random.Range(player.transform.position.y + safeRadius, player.transform.position.y + arenaY / 2);
            float posZ = Random.Range(player.transform.position.z + safeRadius, player.transform.position.z + arenaZ / 2);

            Vector3 pos = Random.insideUnitSphere * (arenaX / 2);
            pos.x += player.transform.position.x;
            pos.y += player.transform.position.y;
            pos.z += player.transform.position.z;
            // If random position is within player's safe radius, generate a new random position (try up to 10 times)
            for (int j = 0; j < 10; j++) {
                if (!WithinSafeCircle(pos)) {
                    break;
                }
                pos = Random.insideUnitSphere * (arenaX / 2);
                pos.x += player.transform.position.x;
                pos.y += player.transform.position.y;
                pos.z += player.transform.position.z;
            }

            // Generate random X/Y/Z spawn rotation
            int rotX = Random.Range(0, 360);
            int rotY = Random.Range(0, 360);
            int rotZ = Random.Range(0, 360);

            // Spawn that asteroid in a random position
            //GameObject asteroid = (GameObject)Instantiate(asteroids[asteroidNumber], new Vector3(posX, posY, posZ), Quaternion.Euler(rotX, rotY, rotZ));
            GameObject asteroid = (GameObject)Instantiate(asteroids[asteroidNumber], pos, Quaternion.Euler(rotX, rotY, rotZ));
            asteroid.GetComponent<OnCollision>().spawner = this;

            // Increase scale of asteroid (1/1/1 default)
            asteroid.transform.localScale += new Vector3(scale, scale, scale);

            // Give asteroid random velocity (between min and max velocity) in the direction it is facing
            float velocity = Random.Range((float)minVelocity, (float)maxVelocity);
            //asteroid.GetComponent<Rigidbody>().velocity = new Vector3(posX, posY, posZ) * (velocity / 5);
            asteroid.GetComponent<Rigidbody>().velocity = pos * (velocity / 5);

            // Give asteroids a slight random rotation
            //asteroid.GetComponent<Rigidbody>().angularVelocity = new Vector3(posX, posY, posZ) * (velocity / 50);
            asteroid.GetComponent<Rigidbody>().angularVelocity = pos * (velocity / 50);
        }
    }

    public void RespawnAsteroid(GameObject asteroid) {
        // Generate random X/Y/Z spawn location outside of player's safe radius
        float posX = Random.Range(player.transform.position.x + safeRadius, player.transform.position.x + arenaX / 2);
        float posY = Random.Range(player.transform.position.y + safeRadius, player.transform.position.y + arenaY / 2);
        float posZ = Random.Range(player.transform.position.z + safeRadius, player.transform.position.z + arenaZ / 2);
        asteroid.transform.position = new Vector3(posX, posY, posZ);
    }

    // Check if asteroid is within the safe radius of the player (i.e. the radius around the player in which asteroids should not spawn)
    public bool WithinSafeCircle(Vector3 pos) {
        if ((pos.x > player.transform.position.x && pos.x < player.transform.position.x + safeRadius) ||
                (pos.x < player.transform.position.x && pos.x > player.transform.position.x - safeRadius)) {
            return true;
        }
        else if ((pos.y > player.transform.position.y && pos.y < player.transform.position.y + safeRadius) ||
            (pos.y < player.transform.position.y && pos.y > player.transform.position.y - safeRadius)) {
            return true;
        }
        else if ((pos.z > player.transform.position.z && pos.z < player.transform.position.z + safeRadius) ||
    (pos.z < player.transform.position.z && pos.z > player.transform.position.z - safeRadius)) {
            return true;
        }
        else {
            return false;
        }
    }
}
