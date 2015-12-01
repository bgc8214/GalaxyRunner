using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBar : MonoBehaviour
{

    private bool isPlaying { get; set; }
    private Player player;
    private float hp;
    private Image circularSlider;
    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        audio = gameObject.GetComponent<AudioSource>();
        circularSlider = gameObject.GetComponent<Image>();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            hp = player.power / 100;
            if (hp < 0.3 && !isPlaying)
            {
                audio.Play();
                circularSlider.material.color = new Color(0f, 0f, 1f, 0.5f);
                isPlaying = true;
            }
            else if (hp > 0.3 && audio.isPlaying)
            {
                circularSlider.material.color = new Color(1f, 1f, 1f, 1f);
                audio.Stop();
                isPlaying = false;
            }
            circularSlider.fillAmount = hp / 2;
        }
    }
}
