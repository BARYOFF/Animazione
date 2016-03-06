using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class AnimHierarchy : MonoBehaviour 
{
	
	public float delay = 0;
	
	public bool isHorizontal = true;

	public bool isVerticalFromTop = false;
>
	public bool isVerticalBottom = false;
	
	bool isVertical
	{
		get
		{
			return isVerticalFromTop || isVerticalBottom;
		}
	}

	void OnEnable()
	{
		DoAnimIn();

	}
	
	public void DoAnimIn()
	{
		int mult = 1;

		int i = 0;

		foreach(var b in gameObject.GetComponentsInChildren<Button>(true))
		{
			b.interactable = false;
		}


		foreach(Transform t in transform)
		{
			if(isHorizontal)
				AnimHorizontalIn(t,mult);
			else if(isVertical)
				AnimVerticalIn(t,i);

			i++;
			mult *= -1;
		}
	}
	/// <summary>
	/// The animation IN of the UI elements, horizontaly.
	/// </summary>
	void AnimHorizontalIn(Transform t, int mult)
	{
		var pos = t.GetComponent<RectTransform>().anchoredPosition;

		float xOrigin =0;

		pos.x = mult *  2 * Screen.width;
	
		t.GetComponent<RectTransform>().anchoredPosition = pos;
		t.GetComponent<RectTransform>().DOLocalMoveX(xOrigin, 1)
			.SetDelay(delay)
			.SetEase(Ease.OutBack,0.6f,1)
			.OnComplete(()=>{
				foreach(var b in gameObject.GetComponentsInChildren<Button>(true))
				{
					b.interactable = true;
				}
			});
	}
	
	void AnimVerticalIn(Transform t, int i)
	{
		var pos = t.GetComponent<RectTransform>().anchoredPosition;

		float yOrigin = pos.y;

		int mult = -1;

		if(isVerticalBottom == false)
			mult = 1;

		pos.y = mult * Screen.height ;

		t.GetComponent<RectTransform>().anchoredPosition = pos;
		t.GetComponent<RectTransform>().DOLocalMoveY(yOrigin, 1)
			.SetDelay(i * delay)
			.SetEase(Ease.OutBack,0.6f,1)
			.OnComplete(()=>{
				foreach(var b in gameObject.GetComponentsInChildren<Button>(true))
				{
					b.interactable = true;
				}
			});
	}
	
	public float DoAnimOut()
	{
		int mult = 1;

		int i = 0;

		foreach(Transform t in transform)
		{
			if(isHorizontal)
				AnimHorizontalOut(t,mult);
			else if(isVertical)
				AnimVerticalOut(t,i);

			i++;
			mult *= -1;
		}

		return 0.6f + transform.childCount*delay;
	}
	
	void AnimHorizontalOut(Transform t, int mult)
	{

		foreach(var b in gameObject.GetComponentsInChildren<Button>(true))
		{
			b.interactable = false;
		}


		var pos = t.GetComponent<RectTransform>().anchoredPosition;

		float xOrigin = pos.x;


		t.GetComponent<RectTransform>().DOLocalMoveX(mult *  2 * Screen.width, 1)
			.SetDelay(delay)
			.SetEase(Ease.OutBack,0.6f,1)
			.OnComplete( () => {
				gameObject.SetActive(false);
				var p = t.GetComponent<RectTransform>().anchoredPosition;
				p.x = xOrigin;
				t.GetComponent<RectTransform>().anchoredPosition = pos;
			});

	}
>
	void AnimVerticalOut(Transform t, int i)
	{

		foreach(var b in gameObject.GetComponentsInChildren<Button>(true))
		{
			b.interactable = false;
		}


		var pos = t.GetComponent<RectTransform>().anchoredPosition;

		float yOrigin = pos.y;

		int mult = 1;

		if(isVerticalBottom)
			mult = -1;

		t.GetComponent<RectTransform>().DOLocalMoveY(mult * Screen.height, 1)
			.SetDelay(i * delay)
			.SetEase(Ease.OutBack,0.6f,1)
			.OnComplete( () => {
				gameObject.SetActive(false);
				var p = t.GetComponent<RectTransform>().anchoredPosition;
				p.y = yOrigin;
				t.GetComponent<RectTransform>().anchoredPosition = pos;
			});

	}
}
