using System.Collections.Generic; // Listを使うための名前空間
using UnityEngine;

public class IgaguriGenerator : MonoBehaviour
{
    public GameObject igaguriPrefab;
    private List<GameObject> igaguriList = new List<GameObject>(); // 球を保持するリスト
    private int maxIgaguriCount = 3; // 最大で保持する球の数
    private int throwCount = 0; // 投げた回数をカウント

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 投げた回数をカウント
            throwCount++;

            // 100回に1回、特別なイガグリにする
            bool isSpecial = throwCount % 100 == 0;

            // デバッグログで確認
            Debug.Log("Throw Count: " + throwCount);
            Debug.Log(isSpecial ? "Special Igaguri will be generated!" : "Normal Igaguri will be generated.");

            // 新しい球を生成
            GameObject newIgaguri = Instantiate(igaguriPrefab);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;

            // 特別なイガグリの処理
            if (isSpecial)
            {
                newIgaguri.GetComponent<IgaguriController>().SetSpecial(); // 特別なイガグリに設定
            }
            else
            {
                newIgaguri.GetComponent<IgaguriController>().ResetSpecial(); // 通常のイガグリにリセット
            }

            // イガグリを発射
            newIgaguri.GetComponent<IgaguriController>().Shoot(worldDir.normalized * 2000);

            // 球をリストに追加
            igaguriList.Add(newIgaguri);

            // リストがmaxIgaguriCountを超えたら一番古い球を削除
            if (igaguriList.Count > maxIgaguriCount)
            {
                Destroy(igaguriList[0]); // 一番古い球を削除
                igaguriList.RemoveAt(0); // リストからも削除
            }
        }
    }
}


