using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // UI��̓��_��\������Text
    public Text timerText; // UI��̎c�莞�Ԃ�\������Text
    public float gameTime = 60.0f; // �Q�[�����ԁi�b�j
    public static int finalScore;  // �ÓI�ϐ��Ƃ��čŏI�X�R�A��ۑ�
    private float currentTime; // �c�莞��
    private int score = 0; // ���݂̓��_
    private int currentScore = 0;

    void Start()
    {
        // �Q�[���J�n���Ƀ^�C�}�[�Ɠ��_��������
        currentTime = gameTime;
        UpdateScore(0);
        UpdateTimer();
    }

    void Update()
    {
        // ���t���[���Ŏ��Ԃ����炷
        currentTime -= Time.deltaTime;
        UpdateTimer();

        // ���Ԃ�0�ȉ��ɂȂ�����Q�[���I�[�o�[�������Ăяo��
        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    // ���_�����Z����֐�
    public void AddScore(int points)
    {
        score += points;
        currentScore=score;
        UpdateScore(score);
    }

    // UI��̓��_���X�V����
    private void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    // UI��̎c�莞�Ԃ��X�V����
    private void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
    }

    // �Q�[���I�����ɃX�R�A��ۑ����ă��U���g�V�[���֑J��
    public void GameOver()
    {
        finalScore = currentScore;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");  // ���U���g�V�[���ɑJ��
    }
}
