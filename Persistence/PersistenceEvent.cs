using System;

namespace Persistence

{
    public class Event
    {
        public string ID_Event {set;get;}
        public string Name_Event {set;get;}
        public string Description {set;get;}
        public string Address_Event {set;get;}

        public DateTime Time {set;get;}

        public Event() { }

        public Event(string ID_Event, string Name_Event, string Description, string Address_Event)
        {
            this.ID_Event = ID_Event;
            this.Name_Event = Name_Event;
            this.Description = Description;
            this.Address_Event = Address_Event;
            this.Time = Time;
        }
    }
}