using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMaker : MonoBehaviour
{
    public Transform fishHolder;
    public Transform[] genPositions;
    public GameObject[] fishPrefabs;

    public float waveWaitTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("MakeFishes", 0, waveWaitTime);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFishes()
    {
	    var posIndex = Random.Range(0, genPositions.Length);
	    var preIndex = Random.Range(0, fishPrefabs.Length);
	    var maxNum = fishPrefabs[preIndex].GetComponent<FishAttr>().maxNum;
	    var maxSpeed = fishPrefabs[preIndex].GetComponent<FishAttr>().maxSpeed;
	    var num = Random.Range(maxNum/2 + 1, maxNum);
	    var speed = Random.Range(maxSpeed / 2,maxSpeed);

	    int moveType = Random.Range(0, 2);//0ֱ�ߣ�1ת��
	    int angOffset;//ֱ�߽Ƕ�
	    int angSpeed;//ת����ٶ�

	    if (moveType == 0)
	    {
		    angOffset = Random.Range(-22,22);
		    GenStraightFish(posIndex, preIndex, num, speed, angOffset);
	    }
	    else
	    {

	    }


    }

    void GenStraightFish(int posIndex,int preIndex,int num,int speed,int angOffset)
    {
	    for (int i = 0; i < num; i++)
	    {
			GameObject fish = Instantiate(fishPrefabs[preIndex]);
			fish.transform.SetParent(fishHolder,false);
			fish.transform.localPosition = genPositions[posIndex].localPosition;
			fish.transform.localRotation = genPositions[posIndex].localRotation;
			fish.transform.Rotate(0,0,angOffset);


	    }
    }
}
