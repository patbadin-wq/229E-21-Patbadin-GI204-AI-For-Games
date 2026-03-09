using UnityEngine;

public class SimpleWander : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }

        if (isRotRight) transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        if (isRotLeft) transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);

        if (isWalking)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        // อัปเดต Animation ตามสถานะ
        anim.SetBool("isWalking", isWalking);
    }

    System.Collections.IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateLorR = Random.Range(1, 3);
        int walkWait = Random.Range(1, 5); // สุ่มเวลาเดิน
        int walkTime = Random.Range(2, 6); // สุ่มระยะเวลาที่เดิน

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateLorR == 1)
        {
            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;
        }
        else
        {
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;
        }

        isWandering = false;
    }
}