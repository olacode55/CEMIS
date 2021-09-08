using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CEMIS.Business
{
    public class RoomFacilityRepository : IRoomFacility
    {

        private IRepository<RoomSettings> _roomSettingsRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<ClassRoomFacility> _classRoomRepo;
        private IConfiguration _configration;

        public RoomFacilityRepository(IRepository<RoomSettings> roomSettingsRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration, IRepository<ClassRoomFacility> classRoomRepo)
        {
            _roomSettingsRepo = roomSettingsRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            _classRoomRepo = classRoomRepo;
        }

        public List<RoomSettings> GetRoomSettings()
        {
            return _roomSettingsRepo.All().ToList();
        }

        //public void UpdateRoomFacility(List<RoomSettings> roomSettings)
        //{
        //    _roomSettingsRepo.Update(roomSettings);
        ///}

        public void UpdateRoomFacility(IFormCollection formCollection)
        {
            bool isclassRoomFacilityExist = false;
            var classRoomFacilityList = new List<ClassRoomFacility>();


            var classRoomFacilityVM = new Utility.ViewModel.ClassRoomFacilityViewModel();
            var settings = GetRoomSettings();

            foreach (var item in settings)
            {
                string key = item.Name.Replace(" ", "");
                string value = formCollection[key];
                if (formCollection[key].Any())
                {
                    switch (item.Type)
                    {
                        case "Number":
                            if (Convert.ToInt16(value) >= 0)
                            {
                                item.Value = formCollection[key];
                            }
                            else
                            {
                                //return error;
                            }
                            break;

                        default:
                            item.Value = formCollection[key];
                            break;
                    }
                    continue;
                }
                else if (item.Type == "Checkbox")
                {
                    item.Value = "off";
                }
            }

            PropertyInfo[] properties = typeof(ClassRoomFacility).GetProperties();
            foreach (PropertyInfo property in properties)
            {

                var values = formCollection[property.Name];

                var propertType = property.PropertyType;
                if (!isclassRoomFacilityExist)
                {
                    foreach (var value in values)
                    {
                        var classRoomFacility = new ClassRoomFacility();

                        if (propertType == typeof(int))
                        {
                            var _value = Convert.ToInt32(value);
                            classRoomFacility.GetType().GetProperty(property.Name).SetValue(classRoomFacility, _value, null);
                        }
                        else if (propertType == typeof(decimal))
                        {
                            var _value = Convert.ToDecimal(value);
                            classRoomFacility.GetType().GetProperty(property.Name).SetValue(classRoomFacility, _value, null);
                        }
                        else
                        {
                            classRoomFacility.GetType().GetProperty(property.Name).SetValue(classRoomFacility, value, null);
                        }

                        classRoomFacilityList.Add(classRoomFacility);
                        isclassRoomFacilityExist = true;
                    }

                }
                else
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        var classRoomFacility = new ClassRoomFacility();
                        var listIndex = classRoomFacilityList[i];
                        if (propertType == typeof(int))
                        {
                            var _value = Convert.ToInt32(values[i]);
                            listIndex.GetType().GetProperty(property.Name).SetValue(listIndex, _value, null);
                        }
                        else if (propertType == typeof(decimal))
                        {
                            var _value = Convert.ToDecimal(values[i]);
                            listIndex.GetType().GetProperty(property.Name).SetValue(listIndex, _value, null);
                        }
                        else
                        {

                            listIndex.GetType().GetProperty(property.Name).SetValue(listIndex, values[i], null);
                        }


                    }
                }
                // property.SetValue(classRoomFacilityVM, values);
            }

            _classRoomRepo.Update(classRoomFacilityList);
            _roomSettingsRepo.Update(settings);
         
        }

        public void UpdateClassRoomDetails(List<ClassRoomFacility> classRoomFacility)
        {
            _classRoomRepo.Update(classRoomFacility);
        }

        public int GetClassRoomCount()
        {
           var count = _roomSettingsRepo.All().FirstOrDefault(m => m.Id == 1).Value;
            return count != string.Empty ? Convert.ToInt32(count) : 0;
        }


        public T ConvertValues<T>(string datatype , string value)
        {
            
            switch (datatype)
            {
                case "string":
                   return (T)(object)value;

                case "int":
                    return (T)(object)(Convert.ToInt32(value));

                case "decimal":
                    return (T)(object)(Convert.ToDecimal(value));
                    
            }
            return (T)(object)null;
        }
    }
}
