using UnityEngine;

public class GimmickCanon_2 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 80f;

    [SerializeField]
    [Tooltip("���ˊԊu")]
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
        //����
        LauncherShot();
    }

    /// <summary>
	/// �e�̔���
	/// </summary>
    private void LauncherShot()
    {

        timeCount += 1;

        if (timeCount % timer == 0)
        {

            // �e�𔭎˂���ꏊ
            Vector3 bulletPosition = firingPoint.transform.position;

            //���ˉ�
            audioSource.PlayOneShot(sound);

            // Prefab���o��������
            GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
            // ����forward
            Vector3 direction = newBall.transform.forward;
            // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);

            // �o���������{�[���̖��O��"bullet"�ɕύX
            newBall.name = bullet.name;

            // �o���������{�[����0.8�b��ɏ���
            Destroy(newBall, 2.5f);


        }
    }
}