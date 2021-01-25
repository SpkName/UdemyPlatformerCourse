using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
	public GameObject _shopPanel;
	private Player playerScrip;
	public int _currentPrice; 
	// Start is called before the first frame update
	void Start()
    {
		playerScrip = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    // Update is called once per frame
    void Update()
    {
		if (IsPlayerGoAway())
		{
			UIManager.Instance.OpenShop(playerScrip._diamond);
			_shopPanel.SetActive(true);

		}
		else
		{
			_shopPanel.SetActive(false);
		}
	}
	protected bool IsPlayerGoAway()
	{
		float distance = Vector3.Distance(transform.localPosition, playerScrip.transform.localPosition);
		return distance < 2f;
	}

	public void SelectItem(int itemPrice) {
		//0-sword 73
		//1-boots -27
		//2-key -127
		
		switch (itemPrice)
		{
			case 200:
				UIManager.Instance.UpdateSelection(73);
				_currentPrice = itemPrice;
				break;
			case 500:
				UIManager.Instance.UpdateSelection(-27);
				_currentPrice = itemPrice;
				break;
			case 100:
				UIManager.Instance.UpdateSelection(-127);
				_currentPrice = itemPrice;
				break;
		}

		
	}

	public void BuyItem() {
		if (playerScrip._diamond >= _currentPrice)
		{
			if (_currentPrice == 100)
			{ GameManager._instance.HasKeyToCasttle = true; }
			playerScrip._diamond -= _currentPrice;
			Debug.Log("you buy it");

		}
		else
		{
			Debug.Log("There is no money");
		}

	}


	//	private void OnTriggerEnter2D(Collider2D other)
	//	{
	//		if (other.CompareTag("Player"))
	//		{
	//			_shopPanel.SetActive(true);
	//		}
	//	}

	//	private void OnTriggerExit2D(Collider2D other)
	//	{
	//		if (other.CompareTag("Player"))
	//		{
	//			_shopPanel.SetActive(true);
	//		}
	//	}
}
