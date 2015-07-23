using UnityEngine;
using System.Collections;

public class DeathCubeTrigger : MonoBehaviour {

	public ParticleSystem fireParticles;

	// Use this for initialization
	void OnTriggerEnter(Collider activator){
		Destroy(activator.gameObject);
		fireParticles.Play();
	}
}
