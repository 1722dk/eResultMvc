using System;

namespace IIT.EResult.Models
{
    public class DdlModel
    {
        public virtual int Key { get; set; }
        public virtual string Value { get; set; } 

        public DdlModel() { }
        public DdlModel(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
