using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private GameObject nextAreaTrigger;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("ChechIfLose", 1, 1);
        InvokeRepeating("FindAllEnemits", 1, 1);
    }

    private void FindAllEnemits()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            nextAreaTrigger.SetActive(true);
    }

    private void ChechIfLose()
    {
        if (player == null)
        {
            Time.timeScale = 0;
            loseText.gameObject.SetActive(true);
        }

    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
