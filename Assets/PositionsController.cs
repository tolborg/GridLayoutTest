using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PositionsController : MonoBehaviour 
{
	public GameObject _heroPosition;
	public GameObject _heroListItem;
	public GameObject _heroListItemContainer;

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
			
		Canvas.ForceUpdateCanvases();
		transform.GetComponent<GridLayoutGroup>().enabled = false;
		_heroListItemContainer.GetComponent<GridLayoutGroup>().enabled = false;

		StartCoroutine(FadeOutItems(2f));
	}



	IEnumerator FadeOutItems(float time)
	{
		float i = 0;
		float rate = 1 / time;

		while (i < 1)
		{
			foreach (Transform heroPosition in transform)
			{
				GameObject heroListItem = heroPosition.GetComponent<HeroPositionController>()._heroListItem;

				if (!heroPosition.gameObject.activeSelf)
				{
					heroListItem.GetComponent<CanvasGroup>().alpha = 1 - i;
				}
			}
			i += Time.deltaTime * rate;
			yield return null;
		}

		Debug.Log("Done fading!");
		StartCoroutine(MoveItems(2f));			
	}



	IEnumerator MoveItems(float time)
	{
		float i = 0;
		float rate = 1 / time;

		while (i < 1)
		{
			foreach (Transform heroPosition in transform)
			{
				// Move items!
			}
				
			i += Time.deltaTime * rate;
			yield return null;
		}

		Debug.Log("Done moving!");
		transform.GetComponent<GridLayoutGroup>().enabled = true;
		_heroListItemContainer.GetComponent<GridLayoutGroup>().enabled = true;
	}

}
