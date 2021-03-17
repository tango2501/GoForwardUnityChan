using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI操作のため
using UnityEngine.SceneManagement;//シーン操作のため


public class UIController : MonoBehaviour
{

    //ゲームオーバーテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 00;

    //走る速度
    private float speed = 5f;

    //ゲームオーバーの判定
    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        //シーンからオブジェクトを探す
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");

    }

    // Update is called once per frame
    void Update()
    {
        //IsGameOverがfalseのあいだ
        if(this.isGameOver == false)
        {
            //走った距離を更新する
            this.len += this.speed * Time.deltaTime;//フレーム準拠

            //走った距離を表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";//引数を"F2"とすることで、小数部を2桁まで表示するように書式指定
        }

        //ゲームオーバーになった場合
        if(this.isGameOver == true)
        {
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
    public void GameOver()
    {
        //ゲームオーバーになった時に画面上にゲームオーバーを表示する
        this.isGameOver = true;
        this.gameOverText.GetComponent<Text>().text = "Game Over";
    }
}
