using UnityEngine;

public class PopupText : MonoBehaviour
{
    public float moveSpeed = 1.0f;  // 上に動く速度
    public float fadeDuration = 1.0f; // フェードアウトにかかる時間
    private float timer = 0.0f;
    private TextMesh textMesh;
    private Color initialColor;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        initialColor = textMesh.color;
    }

    public void Initialize()
    {
        // テキストを少し上に移動し、フェードアウトするように処理
        Destroy(gameObject, fadeDuration);  // 一定時間後にオブジェクトを削除
    }

    void Update()
    {
        // 上方向に移動
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // 徐々に透明にするフェードアウト
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
        textMesh.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
    }
}
