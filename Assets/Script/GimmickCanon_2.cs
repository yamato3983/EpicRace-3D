using UnityEngine;

public class GimmickCanon_2 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 80f;

    [SerializeField]
    [Tooltip("発射間隔")]
    private float timer;

    private float timeCount;

    public AudioClip sound;
    AudioSource audioSource;

    private void Start()
    {
        timeCount = 0f;
        audioSource = GetComponent<AudioSource>();
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

        if (timeCount % timer == 0)
        {

            // 弾を発射する場所
            Vector3 bulletPosition = firingPoint.transform.position;

            //発射音
            audioSource.PlayOneShot(sound);

            // Prefabを出現させる
            GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
            // 球のforward
            Vector3 direction = newBall.transform.forward;
            // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);

            // 出現させたボールの名前を"bullet"に変更
            newBall.name = bullet.name;

            // 出現させたボールを0.8秒後に消す
            Destroy(newBall, 2.5f);


        }
    }
}