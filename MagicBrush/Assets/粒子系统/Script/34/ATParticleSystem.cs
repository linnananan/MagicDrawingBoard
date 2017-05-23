using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATParticleSystem : MonoBehaviour {

	public float _Chance = 0.01f;
	public GameObject _Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Random.value < _Chance) {
			GameObject newParticle = Instantiate (_Prefab) as GameObject;
			//实例化一份新的GameObject 在根目录下，此时 坐标、旋转、缩放系数取的是_Prefab的相对坐标。
			//Unity的Transform组件中看到的位置、旋转、缩放，都是相对父节点的，它并不是相对世界的。
			//所以此时需要把 “被拷贝者” 的世界坐标系数拷贝给 “拷贝者”
			newParticle.transform.SetParent (transform);
			newParticle.transform.position = transform.position;
			//public void SetParent(Transform parent, bool worldPositionStays); 

			// Vector3 pLoss = copy.transform.lossyScale;
			//Vector3 panelLoss = parent.lossyScale;
			//go.transform.localScale = new Vector3((pLoss.x/panelLoss.x),(pLoss.y/panelLoss.y),
			//因为Unity不能直接设置世界缩放系数，只能设置相对缩放系数。
			//所以这里我利用lossyScale来换算了一下相对坐标，lossyScale是一个只读的属性，就是只读某个对象的世界缩放系数。
		}
		
	}
}
