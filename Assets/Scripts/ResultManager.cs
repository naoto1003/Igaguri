using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text scoreText;  // 得点を表示するUI Text
    public Button retryButton;  // リトライボタン

    void Start()
    {
        // ゲームの最終スコアを表示
        scoreText.text = "Score: " + GameManager.finalScore;

        // リトライボタンにリトライメソッドを登録
        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    // リトライボタンが押されたときに呼ばれる
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("StartScene");  // スタートシーンに戻る
    }
}
