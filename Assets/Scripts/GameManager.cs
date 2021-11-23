using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    [Header("Ползунки")]
    List<GameObject> objects;

    List<GameObject> obj = new List<GameObject>();
    public int speed = 5;
    public int deadLine = -16;
    public int spawnTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<obj.Count;i++)
        {
            obj[i].transform.Translate(Vector3.back * Time.deltaTime*speed);
            if (obj[i].transform.position.z < deadLine)
            {
                Destroy(obj[i]);
                obj.RemoveAt(i);
            }
        }
    }
    void CreateRandomObject()
    {
        SpawnObject(Random.Range(0, 8));
    }
    void SpawnObject(int index)
    {
        obj.Add(Instantiate(objects[index]));
    }
    public void StartGame()
    {
        InvokeRepeating("CreateRandomObject", 0, spawnTime);
        canvas.gameObject.transform.Find("Text").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Button").gameObject.SetActive(false);
    }
}
