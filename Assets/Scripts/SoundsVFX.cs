using UnityEngine;

public class SoundsVFX : MonoBehaviour
{
    public static SoundsVFX Instance;

    [SerializeField]
    private Transform particleSpawner;

    [Header("Sounds and Particles Objects")]
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _winAudioClip;
    [SerializeField]
    private GameObject _winParticle;
    [SerializeField]
    private AudioClip _crashAudioClip;
    [SerializeField]
    private GameObject _crashParticle;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(this);

    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    //Call when MainObjectCollition detect collission
    public void playCrash()
    {
        _audioSource.clip = _crashAudioClip;
        _audioSource.Play();
        Instantiate(_crashParticle, particleSpawner.position,Quaternion.identity);
    }
    //Call when MainObjectMovement finish the points
    public void playWin()
    {
        _audioSource.clip = _winAudioClip;
        _audioSource.Play();
        Instantiate(_winParticle, particleSpawner.position, Quaternion.identity);
    }
}
