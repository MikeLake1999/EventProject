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
        
        [Theory]
        [InlineData("VTC", "Ha Noi")]
        [InlineData("VTCA", "HCM")]
        public void AddEventTest(string name, string address)
        {
            Event c = new Event{Name_Event=name, Address_Event=address};
            int? result = eventDal.AddEvent(c);
            Assert.NotNull(result);
            Assert.True((result??0) > 0);
        }

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