using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���̑J�ڂɕK�v

public class StartGame : MonoBehaviour
{
    // �X�^�[�g�{�^�����������Ƃ��ɌĂ΂��
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // �Q�[���V�[���ɑJ��
    }
}
