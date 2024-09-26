using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // UI上の得点を表示するText
    public Text timerText; // UI上の残り時間を表示するText
    public float gameTime = 60.0f; // ゲーム時間（秒）
    public static int finalScore;  // 静的変数として最終スコアを保存
    private float currentTime; // 残り時間
    private int score = 0; // 現在の得点
    private int currentScore = 0;

    void Start()
    {
        // ゲーム開始時にタイマーと得点を初期化
        currentTime = gameTime;
        UpdateScore(0);
        UpdateTimer();
    }

    void Update()
    {
        // 毎フレームで時間を減らす
        currentTime -= Time.deltaTime;
        UpdateTimer();

        // 時間が0以下になったらゲームオーバー処理を呼び出す
        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    // 得点を加算する関数
    public void AddScore(int points)
    {
        score += points;
        currentScore=score;
        UpdateScore(score);
    }

    // UI上の得点を更新する
    private void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    // UI上の残り時間を更新する
    private void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
    }

    // ゲーム終了時にスコアを保存してリザルトシーンへ遷移
    public void GameOver()
    {
        finalScore = currentScore;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");  // リザルトシーンに遷移
    }
}
