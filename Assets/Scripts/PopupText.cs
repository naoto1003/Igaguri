using UnityEngine;

public class PopupText : MonoBehaviour
{
    public float moveSpeed = 1.0f;  // ��ɓ������x
    public float fadeDuration = 1.0f; // �t�F�[�h�A�E�g�ɂ����鎞��
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
        // �e�L�X�g��������Ɉړ����A�t�F�[�h�A�E�g����悤�ɏ���
        Destroy(gameObject, fadeDuration);  // ��莞�Ԍ�ɃI�u�W�F�N�g���폜
    }

    void Update()
    {
        // ������Ɉړ�
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // ���X�ɓ����ɂ���t�F�[�h�A�E�g
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
        textMesh.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
    }
}
