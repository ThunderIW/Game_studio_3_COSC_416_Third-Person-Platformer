using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI ScoreText;
    private CoinTrigger[] coins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coins = FindObjectsByType<CoinTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (CoinTrigger coin in coins)
        {
            coin.OnCoinPickedUp.AddListener(IncrementScore);

        }


    }
    private void IncrementScore()
    {
        score++;
        ScoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
