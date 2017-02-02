using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackRTMBot
{
    [AttributeUsage( AttributeTargets.Method)]
    public class EventMappingAttribute : Attribute
    {
        
        public EventMappingAttribute(object rtmAction)
        {
        }
    }
}
