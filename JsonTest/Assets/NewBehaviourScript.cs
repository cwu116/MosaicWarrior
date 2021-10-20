using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class NewBehaviourScript : MonoBehaviour
{
    Dictionary<int, itemJson> dict;
    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<int, itemJson>();
        TextAsset jsonText = Resources.Load<TextAsset>("ItemData");
        JsonData json = JsonMapper.ToObject(jsonText.text);
        for (int i = 0; i < json.Count; i++)
        {
            int id = int.Parse(json[i]["ID"].ToString());
            string name = (json[i]["Name"].ToString());
            dict.Add(i,new itemJson(id, name));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dict[0].name);
    }
}

public class itemJson {

    public int id;
    public string name;
    public itemJson(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

