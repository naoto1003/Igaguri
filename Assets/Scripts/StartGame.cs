using UnityEngine;
using UnityEngine.SceneManagement; // シーンの遷移に必要

public class StartGame : MonoBehaviour
{
    // スタートボタンを押したときに呼ばれる
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // ゲームシーンに遷移
    }
}
