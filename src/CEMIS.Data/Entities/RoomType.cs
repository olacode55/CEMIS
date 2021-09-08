using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RoomSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public string Options { get; set; }
        public bool EnableFunctionCaller { get; set; }
        public string Function { get; set; }
    }
}
