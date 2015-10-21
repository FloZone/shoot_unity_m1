using UnityEngine;
using System.Collections;

public class SoundState : MonoBehaviour {

	// Singleton
	public static SoundState Instance;
	
	public AudioClip playerShotSound;
	public AudioClip explosionSmallSound;
	public AudioClip explosionMediumSound;
	public AudioClip explosionLargeSound;
	public AudioClip laserFoeSound;
	public AudioClip laserPlayerSound;
	public AudioClip gameMusic;
	public AudioClip gameOver;


	// Use this for initialization
	void Awake () {
		// Singleton
		if(Instance == null) {
			Instance = this;
			DontDestroyOnLoad(Instance.gameObject);
		}
		else if(this != Instance) {
			Destroy(this.gameObject);
		}
	}

	// Shoot sound
	public void playShootSound() {
		MakeSound(playerShotSound);
	}

	// Laser sound
	public void playLaserSound() {
		MakeSound(laserPlayerSound);
	}

	// Player hit
	public void playShipHitSound() {
		MakeSound(explosionSmallSound);
	}
	
	// Player explosion
	public void playShipExplosionSound() {
		MakeSound(explosionLargeSound);
	}

	// Asteroid explosion
	public void playAsteroidExplosionSound() {
		MakeSound(explosionMediumSound);
	}

	// UFO explosion
	public void playUfoExplosionSound() {
		MakeSound(explosionMediumSound);
	}

	// UFO laser
	public void playUfoLaserSound() {
		MakeSound(laserFoeSound);
	}

	// game music
	public void playGameMusic() {
		MakeSound(gameMusic);
	}

	// game over
	public void playGameOverSound() {
		MakeSound(gameOver);
	}

	// Play the given sound
	private void MakeSound(AudioClip originalClip) {
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}

	// Stop the current sound
	public void stopSound() {
		audio.Stop();
	}

}
