using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text scoreText;  // ���_��\������UI Text
    public Button retryButton;  // ���g���C�{�^��

    void Start()
    {
        // �Q�[���̍ŏI�X�R�A��\��
        scoreText.text = "Score: " + GameManager.finalScore;

        // ���g���C�{�^���Ƀ��g���C���\�b�h��o�^
        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    // ���g���C�{�^���������ꂽ�Ƃ��ɌĂ΂��
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("StartScene");  // �X�^�[�g�V�[���ɖ߂�
    }
}
