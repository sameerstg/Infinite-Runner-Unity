using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager _instance;

    public List<GameObject> grounds;
    public List<GameObject> groundPrefab;
    public int amountOfGround;
    Vector3 initialPosition;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        initialPosition = new Vector3(0, 0, 0);

        groundPrefab.Add(Resources.Load("prefab/Ground") as GameObject);
        groundPrefab.Add(Resources.Load("prefab/Ground 2") as GameObject);
        groundPrefab.Add(Resources.Load("prefab/Ground 3") as GameObject);
        groundPrefab.Add(Resources.Load("prefab/Ground 4") as GameObject);
        amountOfGround = 6;
    }
    private void Update()
    {


        if (grounds.Count <= amountOfGround)
        {
            SetGroundsPosition();
        }
        else
        {
            DeleteLast();
        }
        
    }
    void SetGroundsPosition()
    {
      
        for (int i = 0; i < amountOfGround-grounds.Count; i++)
        {
            var obj = Instantiate(groundPrefab[Random.Range(0,groundPrefab.Count)], initialPosition, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            grounds.Add(obj);
            initialPosition.z += 60f;
        }
    }
   void DeleteLast()
    {
        var obj = grounds[grounds.Count - 1];
        grounds.Remove(obj);
        Destroy(obj);
        initialPosition.z -= 60f;
    }
    public void DestroyFirst()
    {
        var obj = grounds[0];
        grounds.Remove(obj);
        Destroy(obj);
    }
}
