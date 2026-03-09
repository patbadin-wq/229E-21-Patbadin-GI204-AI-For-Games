using UnityEngine;

public class FootstepVolumeControl : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;

    [Header("Settings")]
    public string parameterName = "isWalking"; // ชื่อตัวแปรใน Animator
    public float maxVolume = 0.5f;             // ความดังสูงสุดที่ต้องการ
    public float fadeSpeed = 3f;               // ความเร็วในการเพิ่ม/ลดเสียง

    void Start()
    {
        // ดึง Component จากตัวละคร
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // ตั้งค่าเริ่มต้นของเสียง
        if (audioSource != null)
        {
            audioSource.volume = 0;
            audioSource.Play(); // ให้เล่นวนลูปทิ้งไว้แต่เริ่มที่ระดับเสียง 0
        }
    }

    void Update()
    {
        if (anim == null || audioSource == null) return;

        // เช็กค่าจาก Animator ว่าตอนนี้ 'isWalking' เป็น true หรือ false
        bool isWalking = anim.GetBool(parameterName);

        if (isWalking)
        {
            // ถ้าเดินอยู่ ค่อยๆ เพิ่ม Volume ไปหาค่า Max
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // ถ้าหยุดเดิน ค่อยๆ ลด Volume ลงจนเหลือ 0
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, 0, fadeSpeed * Time.deltaTime);
        }
    }
}