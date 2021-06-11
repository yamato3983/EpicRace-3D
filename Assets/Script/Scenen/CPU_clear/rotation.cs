using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform m_target;

    public float m_rotateSpeed = 10;

    private void Update()
    {
        transform.RotateAround
        (
            m_target.position,
            Vector3.up,
            m_rotateSpeed * Time.deltaTime
        );
    }
}