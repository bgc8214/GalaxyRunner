using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {
    public Material red;
    public Material cyan;
    private bool isPlaying { get; set; }


    private Player player;
    private float hp;
    private AudioSource audio;
    private Renderer renderer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        renderer = gameObject.GetComponent<Renderer>();
        audio = gameObject.GetComponent<AudioSource>();
        renderer.material = red;
        isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
        hp = player.power / 100;
        if (hp < 0.3 && !isPlaying)
        {
            renderer.material = cyan;
            audio.Play();
            isPlaying = true;
        }
        else if(hp > 0.3 && audio.isPlaying)
        {
            renderer.material = red;
            audio.Stop();
            isPlaying = false;
        }
        gameObject.transform.localScale = new Vector3(1, hp, 1);
        gameObject.transform.localPosition = new Vector3(-1 + hp, 0, 0);
	}

}
