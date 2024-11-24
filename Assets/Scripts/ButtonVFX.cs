using UnityEngine;

public class ButtonVFX : MonoBehaviour
{
    private AudioManager _audioManager;
    public void PlayClickSound()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        if(_audioManager != null)
            _audioManager.Play("Click");
    }
}
