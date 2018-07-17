using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class MakeUp : RealmObject
    {
        [JsonProperty("id")]
        // [PrimaryKey]
        public int Id { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }


}
