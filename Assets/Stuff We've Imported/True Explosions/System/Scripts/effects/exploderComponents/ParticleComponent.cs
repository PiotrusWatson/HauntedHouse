using UnityEngine;
using UnityEditor;
using System.Collections;

public class ParticleComponent : ExploderComponent {
	public GameObject explosionEffectsContainer;
	public float scale = 1;
	public float playbackSpeed = 1;

	public FinishSpookingEvent finishedSpooking;
	public override void onExplosionStarted(Exploder exploder)
	{
		GameObject container = (GameObject)GameObject.Instantiate(explosionEffectsContainer, transform.position, Quaternion.identity);
		ParticleSystem[] systems = container.GetComponentsInChildren<ParticleSystem>();
		var main = systems[2].GetComponent<ParticleSystem>().main;
		main.stopAction = ParticleSystemStopAction.Destroy;
		foreach (ParticleSystem system in systems) {
			system.startSpeed *= scale;
			system.startSize *= scale;
			system.transform.localScale *= scale;
			system.playbackSpeed = playbackSpeed;
		}
	}

	public void OnParticleSystemStopped(){
		Debug.Log("We stopped!!");
		finishedSpooking.Invoke(gameObject);
	}
}
