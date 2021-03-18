using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12f;

    //消滅位置
    private float deadLine = -10;

    //キューブの音
    public AudioSource cube;

    // Start is called before the first frame update
    void Start()
    {
        //キューブの効果音を取得
        cube = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

    }
    //衝突したときに音を鳴らす関数
    private void OnCollisionEnter2D(Collision2D other)
    {
        //衝突したもののタグがGroundかBlockだったとき
        if(other.gameObject.tag == "Ground" | other.gameObject.tag == "Block")
        //効果音を鳴らす
        cube.Play();
    }
}
