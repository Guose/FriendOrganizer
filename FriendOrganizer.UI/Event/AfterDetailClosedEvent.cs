using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Event
{
    public class AfterDetailClosedEvent : PubSubEvent<AfterDetailClosedEventArgs>
    {
    }

    public class AfterDetailClosedEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
