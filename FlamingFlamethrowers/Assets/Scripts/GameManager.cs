using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Alien;
    public GameObject Earth;
    public GameObject Human;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public Text scoreText;
    public int enemySpawnPercent = 50;
    public int spawnRange = 150;
    public float enemySpawnTime = 3f;
    public static int currentEnemyCount;

    public int maxEnemyCount = 5;
    public float timeBetweenDifficultyIncreases = 30f;

    public static bool gameOver = false;

    void Start() {
        StartCoroutine(EnemySpawnCycle());
        StartCoroutine(DifficultyIncrease());
    }
    void Awake() {
        Setup();
    }
    public void Setup() {
        currentEnemyCount = 0;
        maxEnemyCount = 5;
        Time.timeScale = 1f;
        gameOver = false;
        Earth.SetActive(true);
        Human.SetActive(true);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    void Update() {
        scoreText.text = (Time.timeSinceLevelLoad.ToString("F1"));
    }
	private void SpawnEnemy() {
        Object.Instantiate(Alien, GetSpawnLocation(), Quaternion.identity);
        currentEnemyCount++;
        Debug.Log("There are currently " + currentEnemyCount + " enemies");
	}
    private Vector2 GetSpawnLocation() {
		int num = 45;
		int num2 = 90 - num / 2;
		int num3 = 90 + num / 2;
		if (Random.Range(0, 2) == 0) {
			return Quaternion.AngleAxis((float)Random.Range(num2, num3), Vector3.forward) * (Vector3)Vector2.up * (float)spawnRange;
		}
		return Quaternion.AngleAxis((float)Random.Range(num2 + 180, num3 + 180), Vector3.forward) * (Vector3)Vector2.up * (float)spawnRange;
	}

    private IEnumerator DifficultyIncrease() {
        while(gameOver != true) {
            Debug.Log("The max enemy count is: " + maxEnemyCount);
            maxEnemyCount++;
            yield return new WaitForSeconds(timeBetweenDifficultyIncreases);
        }  
    }
    private IEnumerator EnemySpawnCycle()
	{
        while(gameOver != true) {
            if(currentEnemyCount < maxEnemyCount) {
                SpawnEnemy();
		        yield return (object)new WaitForSeconds(enemySpawnTime);
            }
            else {
                yield return null;
            }
        }
	}
}
