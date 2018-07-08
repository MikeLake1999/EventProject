using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;
using Persistence;

namespace DAL.Test
{
    public class EventDalUnitTest
    {
        private EventDAL eventDal = new EventDAL();
        
        // [Theory]
        // [InlineData("VTCA 1", "Ha Noi", "Nothing", "1h")]
        // [InlineData("VTCA 2", "Hai Phong","Nothing", "1h")]
        // public void AddEventTest(string name, string address, string description, string time)
        // {
        //     Event c = new Event{Name_Event=name, Address_Event=address, Description=description, Time=time};
        //     int? result = eventDal.AddEvent(c);
        //     Assert.NotNull(result);
        //     Assert.True((result??0) > 0);
        // }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetEventIdTest(int id)
        {
            Event result = eventDal.GetById(id);
            Assert.NotNull(result);
        }
    }
}