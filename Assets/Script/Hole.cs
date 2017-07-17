 using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	bool fallIn;

	//どのボールを吸い寄せるかをタグで判定
	public string activeTag;

	//ボールが入っているかを返す
	public bool IsFallIn()
	{
		return fallIn;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == activeTag) {
			fallIn = true;
		}
	}

	void OntriggerExit (Collider other)
	{
		if (other.gameObject.tag == activeTag)
		{
			fallIn = false;
	}
}
	void OnTriggerStay(Collider other)
	{
	//コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

	//ボールがどの方向にあるのかを計算
		Vector3 direction = other.gameObject.transform.position;
		direction.Normalize ();
	
	//タグに応じてボールに力を与える
		if(other.gameObject.tag == activeTag)
		{
			//中心部ぶんでボールを止めるため速度を減速させる
			r.velocity *= 0.9f;

			r.AddForce (direction * r.mass * 20.0f);
		}else{
			r.AddForce (-direction * r.mass * 80.0f);
		}
	}
}