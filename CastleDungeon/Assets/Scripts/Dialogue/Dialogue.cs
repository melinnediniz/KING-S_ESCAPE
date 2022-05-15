using System;
using UnityEngine;

namespace Dialogue
{
    [Serializable]
    public class Dialogue
    {
        public string title;
    
        [TextArea(3, 12)]
        public string[] phrases;
    
    
    }
}
