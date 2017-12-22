using GoDictionary.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDictionary.API.Service
{
    public sealed class DataService
    {
        private static readonly EntityService service = new EntityService();

        public static EntityService Service
        {
            get
            {
                return service;
            }
        }
    }
}