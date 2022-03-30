using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMouse : MonoBehaviour
{
    public Rigidbody rb;
    public float AttackSpeed = 1f;
    Object BulletRef;

    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        BulletRef = Resources.Load("PlayerAttack");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseWorldPosition.z = 0f;
        transform.position = MouseWorldPosition;
        StartCoroutine(Shooting());
    }

    public void PlayerAttack()
    {
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(AttackSpeed);
            PlayerAttack();
        }
    }
}
