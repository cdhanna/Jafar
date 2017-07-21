//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class JsonTest : MonoBehaviour
    {
        public void Start()
        {
            var json = File.ReadAllText("Assets/poop.json");
            var data = JsonConvert.DeserializeObject<string[]>(json);
            //var data = new string[] { "asdfasdf" };
            foreach(var elem in data)
            {
                Debug.Log("DATA FROM FILE " + elem);
            }
        }
    }
}
