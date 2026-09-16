using System.Collections.Generic;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    protected Dictionary<string, object> data = new Dictionary<string, object>();

    public void SetData(string key, object value)
    {
        data[key] = value;
    }

    public T GetData<T>(string key)
    {
      if(data.TryGetValue(key, out object value))
        return (T)value; //ep kieu du lieu ve T yeu dau
      return default;
    }
    public bool ClearData(string key)
    {
        if (data.ContainsKey(key))
        {
            data.Remove(key);
            return true;
        }
        return false;
    }
}
