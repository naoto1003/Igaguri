using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    private bool isSpecial = false; // 特別なイガグリかどうかのフラグ
    private bool hasCollided = false; // 衝突が発生したかどうかを管理

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // 特別なイガグリに設定するメソッド
    public void SetSpecial()
    {
        isSpecial = true;
        // 見た目やエフェクトを変える（例として赤くする）
        GetComponent<Renderer>().material.color = Color.red;

        // デバッグログで確認
        Debug.Log("Special Igaguri generated!");
    }

    // 通常のイガグリに設定するメソッド（新しく生成されたとき）
    public void ResetSpecial()
    {
        isSpecial = false;
        hasCollided = false; // 衝突フラグもリセット
        // 色を通常の状態に戻す（例として白に戻す）
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // すでに衝突していた場合は何もしない
        if (hasCollided)
        {
            return;
        }

        // 初回の衝突時のみ処理を行う
        hasCollided = true;

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        GameManager gameManager = FindObjectOfType<GameManager>();

        // 特別なイガグリの場合は得点3倍
        if (isSpecial)
        {
            Debug.Log("Special Igaguri hit! Score is tripled!");
            gameManager.AddScore(200); // 例として300点にする
        }
        else
        {
            // 通常の得点処理
            gameManager.AddScore(0); // 通常は100点
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
