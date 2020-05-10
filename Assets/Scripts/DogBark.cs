using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBark : MonoBehaviour
{
    [SerializeField] SheepManager sheep_manager;
    private Animator animator;

    [SerializeField] List<AudioClip> barking_sounds;
    private AudioSource audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = this.GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("bark");
            sheep_manager.DisperseSheepFromPosition(this.transform.position);
            Bark();
        }
    }

    private void Bark()
    {
        int random_bark = Random.Range(0, barking_sounds.Count);
        audio_source.clip = barking_sounds[random_bark];
        audio_source.Play();
    }
}
