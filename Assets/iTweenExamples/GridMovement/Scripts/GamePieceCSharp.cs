using UnityEngine;
using System.Collections;

public class GamePieceCSharp : MonoBehaviour
{
	private Color currentColor;
	private Vector3 currentPosition;
	GameBoardCSharp gameBoard;
	bool isActive;
	
	void Start(){
		currentColor=renderer.material.color;
		currentPosition=transform.position;
	}
	
	void SetGameboard(GameBoardCSharp gameBoard){
		this.gameBoard=gameBoard;
	}
	
	void Deactivate(){
		isActive=false;
		iTween.ColorTo(gameObject,currentColor,.4f);
	}
	
	void Activate(){
		isActive=true;
		renderer.material.color=Color.red;
		SendMessageUpwards("SetTarget",gameObject);	
		iTween.MoveTo(gameObject,currentPosition,.4f);
	}
	
	void OnMouseEnter(){
		if(!isActive){
			if(!gameBoard.ballSet){
				renderer.material.color=Color.yellow;
			}else{
				renderer.material.color=Color.green;
			}
			transform.position=new Vector3(currentPosition.x,.5f,currentPosition.z);
		}
	}
	
	void OnMouseExit(){
		if(!isActive){
			iTween.ColorTo(gameObject,currentColor,.4f);
			iTween.MoveTo(gameObject,currentPosition,.4f);
		}
	}
	
	void OnMouseDown(){
		if(gameBoard.ballSet){
			Activate();
		}
	}
}

