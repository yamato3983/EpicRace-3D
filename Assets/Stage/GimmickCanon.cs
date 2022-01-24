using UnityEngine;

public class GimmickCanon : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
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
        //����
        LauncherShot();
    }

    /// <summary>
	/// �e�̔���
	/// </summary>
    private void LauncherShot()
    {

        timeCount += 1;

        if (timeCount % 240  == 0)
        {
            // �e�𔭎˂���ꏊ
            Vector3 bulletPosition = firingPoint.transform.position;
            // Prefab���o��������
            GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
            // ����forward
            Vector3 direction = newBall.transform.forward;
            // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);

            AudioSource.PlayClipAtPoint(sound, transform.position);

            // �o���������{�[���̖��O��"bullet"�ɕύX
            newBall.name = bullet.name;
            // �o���������{�[����0.8�b��ɏ���
            Destroy(newBall, 1.5f);

         
        }
    }
}