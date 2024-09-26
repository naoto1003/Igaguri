using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    private bool isSpecial = false; // ���ʂȃC�K�O�����ǂ����̃t���O
    private bool hasCollided = false; // �Փ˂������������ǂ������Ǘ�

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // ���ʂȃC�K�O���ɐݒ肷�郁�\�b�h
    public void SetSpecial()
    {
        isSpecial = true;
        // �����ڂ�G�t�F�N�g��ς���i��Ƃ��ĐԂ�����j
        GetComponent<Renderer>().material.color = Color.red;

        // �f�o�b�O���O�Ŋm�F
        Debug.Log("Special Igaguri generated!");
    }

    // �ʏ�̃C�K�O���ɐݒ肷�郁�\�b�h�i�V�����������ꂽ�Ƃ��j
    public void ResetSpecial()
    {
        isSpecial = false;
        hasCollided = false; // �Փ˃t���O�����Z�b�g
        // �F��ʏ�̏�Ԃɖ߂��i��Ƃ��Ĕ��ɖ߂��j
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���łɏՓ˂��Ă����ꍇ�͉������Ȃ�
        if (hasCollided)
        {
            return;
        }

        // ����̏Փˎ��̂ݏ������s��
        hasCollided = true;

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        GameManager gameManager = FindObjectOfType<GameManager>();

        // ���ʂȃC�K�O���̏ꍇ�͓��_3�{
        if (isSpecial)
        {
            Debug.Log("Special Igaguri hit! Score is tripled!");
            gameManager.AddScore(200); // ��Ƃ���300�_�ɂ���
        }
        else
        {
            // �ʏ�̓��_����
            gameManager.AddScore(0); // �ʏ��100�_
        }
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
