using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PositionsController : MonoBehaviour 
{
	public GameObject _heroPosition;
	public GameObject _heroListItem;
	public GameObject _heroListItemContainer;
	public AnimationCurve _moveCurve;
	public float _moveTime;
	public float _fadeTime;

	public int _heroesCount;
	private int[] rarities = { 1,1,2,3,2,1,2,3,2,3,2,2,3,3,1,1,2,2,3,3,3,2,1,1,2,3 };


	void Start() 
	{
		foreach (int rarity in rarities)
		{
			GameObject heroListItem = Instantiate(_heroListItem, _heroListItemContainer.transform.position, Quaternion.identity) as GameObject;
			heroListItem.transform.SetParent(_heroListItemContainer.transform);
			heroListItem.GetComponentInChildren<Text>().text = rarity.ToString();

			GameObject heroPosition = Instantiate(_heroPosition, transform.position, Quaternion.identity) as GameObject;
			heroPosition.transform.SetParent(transform);
			heroPosition.GetComponent<HeroPositionController>()._rarity = rarity;
			heroPosition.GetComponent<HeroPositionController>()._heroListItem = heroListItem;
		}
	}



	public void FilterHeroes(int rarity)
	{
		foreach (Transform heroPosition in transform)
		{
			if (rarity == 0 || heroPosition.GetComponent<HeroPositionController>()._rarity == rarity)
			{
				heroPosition.gameObject.SetActive(true);
			}
			else
			{
				heroPosition.gameObject.SetActive(false);
			}
		}
			
		DisableGrids();
		StartCoroutine(FadeOutItems());
		StartCoroutine(MoveItems());
	}



	void DisableGrids()
	{
		Canvas.ForceUpdateCanvases();
		transform.GetComponent<GridLayoutGroup>().enabled = false;
		_heroListItemContainer.GetComponent<GridLayoutGroup>().enabled = false;
	}

	void EnableGrids()
	{
		transform.GetComponent<GridLayoutGroup>().enabled = true;
		_heroListItemContainer.GetComponent<GridLayoutGroup>().enabled = true;
	}



	IEnumerator FadeOutItems()
	{
		float i = 0;
		float rate = 1 / _fadeTime;

		while (i < 1)
		{
			i += Time.deltaTime * rate;

			foreach (Transform heroPosition in transform)
			{
				GameObject heroListItem = heroPosition.GetComponent<HeroPositionController>()._heroListItem;

				if (!heroPosition.gameObject.activeSelf)
				{
					heroListItem.GetComponent<CanvasGroup>().alpha = 1 - i;

					if (i >= 1)
					{
						heroListItem.SetActive(false);
					}
				}
			}
			yield return null;
		}			
	}



	IEnumerator MoveItems()
	{
		float i = 0;
		float rate = 1 / _moveTime;

		while (i < 1)
		{
			i += Time.deltaTime * rate;

			foreach (Transform heroPosition in transform)
			{
				GameObject heroListItem = heroPosition.GetComponent<HeroPositionController>()._heroListItem;

				if (heroPosition.gameObject.activeSelf)
				{
					heroListItem.SetActive(true);
					heroListItem.GetComponent<CanvasGroup>().alpha = 1;
					heroListItem.transform.position = Vector3.Lerp(heroListItem.transform.position, heroPosition.transform.position, i);
				}
			}
			yield return null;
		}

		EnableGrids();
	}

}
