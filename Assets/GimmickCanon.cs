using UnityEngine;

public class GimmickCanon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30f;

    private float timeCount;

    public AudioClip sound;

    private void Start()
    {
        timeCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //発射
        LauncherShot();
    }

    /// <summary>
	/// 弾の発射
	/// </summary>
    private void LauncherShot()
    {

        timeCount += 1;

        if (timeCount % 240  == 0)
        {
            // 弾を発射する場所
            Vector3 bulletPosition = firingPoint.transform.position;
            // Prefabを出現させる
            GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
            // 球のforward
            Vector3 direction = newBall.transform.forward;
            // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);

            AudioSource.PlayClipAtPoint(sound, transform.position);

            // 出現させたボールの名前を"bullet"に変更
            newBall.name = bullet.name;
            // 出現させたボールを0.8秒後に消す
            Destroy(newBall, 1.5f);

         
        }
    }
}