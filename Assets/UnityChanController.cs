using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //ジャンプ速度の減衰
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20f;

    //地面の位置
    private float groundLevel = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //アニメーターのコンポーネントを入れる
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを入れる
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);//常に右方向へ走るアニメーションをさせるため、Horizontalを1に設定
        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);//地面に接地しているかどうかをy座標で調べ、その結果をboolにして、アニメータに渡す
        
        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, jumpVelocity);
        }
        //クリックをやめたら上方向への速度を減速する
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)//かつ、yが0以上の時
            {
                this.rigid2D.velocity *= this.dump;//減速係数を掛ける
            }
        }
    }
}
