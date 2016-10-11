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

	private Dictionary<int,string> rarityNames = new Dictionary<int,string>();
	private int[] rarities = { 1,1,2,3,2,1,2,3,2,3,2,2,3,3,1,1,2,2,3,3,3,2,1,1,2,3 };


	void Start() 
	{
		rarityNames.Add(1, "Common");
		rarityNames.Add(2, "Rare");
		rarityNames.Add(3, "Epic");

		InstantiateHeroes();
	}



	void InstantiateHeroes()
	{
		foreach (int rarity in rarities)
		{
			GameObject heroPosition = Instantiate(_heroPosition, transform.position, Quaternion.identity) as GameObject;
			heroPosition.transform.SetParent(transform);

			GameObject heroListItem = Instantiate(_heroListItem, _heroListItemContainer.transform.position, Quaternion.identity) as GameObject;
			heroListItem.transform.SetParent(_heroListItemContainer.transform);
			heroListItem.GetComponentInChildren<Text>().text = rarityNames[rarity];
		}
			
		//StartCoroutine(InstantiateHeroListItems());
	}









//	IEnumerator InstantiateHeroListItems()
//	{
//		yield return new WaitForEndOfFrame();
//
//		foreach (Transform child in transform)
//		{
//
//			GameObject lolChild = Instantiate(heroListItem, heroListItemContainer.transform.position, Quaternion.identity) as GameObject;
//			lolChild.transform.SetParent(heroListItemContainer.transform);
//
//		}
//	}


}
