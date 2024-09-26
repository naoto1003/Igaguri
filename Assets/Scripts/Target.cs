using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 100; // �I�ɓ��������ۂ̃|�C���g
    public GameObject popupTextPrefab; // �|�b�v�A�b�v�e�L�X�g�̃v���n�u

    
    void OnCollisionEnter(Collision collision)
    {
        // �^�[�Q�b�g�ɋ������������珈�����s��
        if (collision.gameObject.tag == "Ball")
        {
            // ���_��ǉ�
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore(pointValue);


            // ���������ꏊ�Ƀ|�b�v�A�b�v�e�L�X�g�𐶐�
            Vector3 hitPosition = collision.contacts[0].point; // �Փˈʒu���擾
            ShowPopupText(hitPosition, "+100");

            // �^�[�Q�b�g���폜�i�܂��͍Ĕz�u�Ȃǁj
            Destroy(gameObject);
        }
    }

    void ShowPopupText(Vector3 position, string text)
    {
        // �|�b�v�A�b�v�e�L�X�g�𐶐�
        GameObject popupText = Instantiate(popupTextPrefab, position, Quaternion.identity);
        popupText.GetComponent<TextMesh>().text = text;

        // �|�b�v�A�b�v�e�L�X�g��������Ɉړ������A�t�F�[�h�A�E�g�����邽�߂ɁA��p�X�N���v�g��K�p
        popupText.AddComponent<PopupText>().Initialize();
    }
}
