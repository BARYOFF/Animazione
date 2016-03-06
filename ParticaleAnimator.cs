using UnityEngine;
using System.Collections;

public class ParticaleAnimator : MonoBehaviour 
{
	private void Awake()
	{
		particle = GetComponent<ParticleEmitter>();
	}

	
	void Start ()
	{
		lastTime = Time.realtimeSinceStartup;
	}

	
	void Update () 
	{

		float deltaTime = Time.realtimeSinceStartup - (float)lastTime;

		particle.Simulate(deltaTime) ;

		lastTime = Time.realtimeSinceStartup;
	}

	private double lastTime;
	private ParticleEmitter particle;

}
