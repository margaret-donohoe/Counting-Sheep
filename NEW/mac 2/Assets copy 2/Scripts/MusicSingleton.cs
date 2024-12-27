using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MusicSingleton : MonoBehaviour
{

	private static MusicSingleton instance = null;

	public static MusicSingleton Instance
	{
		get { return instance; }
	}

	private AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource>();
		if (instance != null && instance != this)
		{
			audio.Stop();
			

			if (instance.audio.clip != audio.clip)
			{
				instance.audio.clip = audio.clip;
				instance.audio.volume = audio.volume;
				instance.audio.Play();
			}

			Destroy(this.gameObject);
			return;
		}
		instance = this;
		audio.Play();
		DontDestroyOnLoad(this.gameObject);
	}
    private void Update()
    {
		if (SceneManager.GetActiveScene().name == "2_play")
        {
			Destroy(this.gameObject);
        }

	}
}
