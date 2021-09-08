using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CEMIS.Utility
{

    public class ResponseBaseModel
    {
        public string RespCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccessful { get; set; }

    }

    public class Data
    {
        public ResponseBaseModel responseBaseModel { get; set; }
    }


    public class ResponseData<T> : ResponseBaseModel
    {
        public T Data { get; set; }

    }

}

