using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class AnimateSpawnPoints : MonoBehaviour
{
	float time = 0.5f;

	void Awake()
	{
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector2.zero;
	}

	void OnEnable()
	{
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector2.zero;
		DOAnimation();
	}

	void OnDisable()
	{
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector2.zero;
	}
	void DOAnimation()
	{
		transform.DOScale(Vector2.one, 0.7f)
			.SetEase(Ease.OutBack);

		transform.DOLocalRotate(Vector3.forward * 360, time, RotateMode.FastBeyond360);
	}
}
