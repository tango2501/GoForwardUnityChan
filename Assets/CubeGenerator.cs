using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //キューブのPrefab
    public GameObject cubePrefab;
    //時間計測用の変数
    private float delta = 0;
    //キューブの生成間隔
    private float span = 1.0f;
    //キューブの生成位置：座標
    private float genPosX = 12;
    //キューブの生成位置オフセット
    private float offsetY = 0.3f;
    //キューブの縦方向の間隔
    private float spaceY = 6.9f;

    //キューブの生成位置オフセット
    private float offsetX = 0.5f;
    //キューブの横方向の間隔
    private float spaceX = 0.5f;

    //キューブの生成個数の上限
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //複数のキューブが一度ではなく段階的にトン・トン・トンと落ちてくるように、キューブを生成する位置は縦方向にspaceY変数のぶんだけスペースを空けて生成しています。
    //キューブの個数をRandom.Range関数で決めて高さがランダムになるように生成しています。
    //また、生成するキューブの数が少ない場合は次のキューブ生成までの間隔を短くし、キューブの数が多い場合は次のキューブ生成までの間隔を長くしています。(memo)
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if(this.delta > this.span)
        {
            //タイマーをリセット
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum+1);

            //指定した数だけキューブを生成する
            for (int i = 0; i < n; i++)
            {
                //キューブの生成
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offsetX + this.spaceX * n;
        }

    }
}
