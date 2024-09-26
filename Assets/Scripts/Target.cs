using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 100; // 的に当たった際のポイント
    public GameObject popupTextPrefab; // ポップアップテキストのプレハブ

    
    void OnCollisionEnter(Collision collision)
    {
        // ターゲットに球が当たったら処理を行う
        if (collision.gameObject.tag == "Ball")
        {
            // 得点を追加
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(pointValue);


            // 当たった場所にポップアップテキストを生成
            Vector3 hitPosition = collision.contacts[0].point; // 衝突位置を取得
            ShowPopupText(hitPosition, "+100");

            // ターゲットを削除（または再配置など）
            Destroy(gameObject);
        }
    }

    void ShowPopupText(Vector3 position, string text)
    {
        // ポップアップテキストを生成
        GameObject popupText = Instantiate(popupTextPrefab, position, Quaternion.identity);
        popupText.GetComponent<TextMesh>().text = text;

        // ポップアップテキストを少し上に移動させ、フェードアウトさせるために、専用スクリプトを適用
        popupText.AddComponent<PopupText>().Initialize();
    }
}
