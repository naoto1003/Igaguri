using System.Collections.Generic; // List���g�����߂̖��O���
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject igaguriPrefab;
    private List<GameObject> igaguriList = new List<GameObject>(); // ����ێ����郊�X�g
    private int maxIgaguriCount = 3; // �ő�ŕێ����鋅�̐�
    private int throwCount = 0; // �������񐔂��J�E���g

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �������񐔂��J�E���g
            throwCount++;

            // 100���1��A���ʂȃC�K�O���ɂ���
            bool isSpecial = throwCount % 100 == 0;

            // �f�o�b�O���O�Ŋm�F
            Debug.Log("Throw Count: " + throwCount);
            Debug.Log(isSpecial ? "Special Igaguri will be generated!" : "Normal Igaguri will be generated.");

            // �V�������𐶐�
            GameObject newIgaguri = Instantiate(igaguriPrefab);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            // ���ʂȃC�K�O���̏���
            if (isSpecial)
            {
                newIgaguri.GetComponent<IgaguriController>().SetSpecial(); // ���ʂȃC�K�O���ɐݒ�
            }
            else
            {
                newIgaguri.GetComponent<IgaguriController>().ResetSpecial(); // �ʏ�̃C�K�O���Ƀ��Z�b�g
            }

            // �C�K�O���𔭎�
            newIgaguri.GetComponent<IgaguriController>().Shoot(worldDir.normalized * 2000);

            // �������X�g�ɒǉ�
            igaguriList.Add(newIgaguri);

            // ���X�g��maxIgaguriCount�𒴂������ԌÂ������폜
            if (igaguriList.Count > maxIgaguriCount)
            {
                Destroy(igaguriList[0]); // ��ԌÂ������폜
                igaguriList.RemoveAt(0); // ���X�g������폜
            }
        }
    }
}


