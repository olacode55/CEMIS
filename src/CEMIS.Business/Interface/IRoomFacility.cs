using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business
{
    public interface IRoomFacility
    {
        List<RoomSettings> GetRoomSettings();
        void UpdateRoomFacility(IFormCollection formCollection);
        //void UpdateRoomFacility(List<RoomSettings> roomSettings);
        //void UpdateClassRoomDetails(List<ClassRoomFacility> classRoomFacility);
        int GetClassRoomCount();
        T ConvertValues<T>(string datatype, string value);
    }
}
