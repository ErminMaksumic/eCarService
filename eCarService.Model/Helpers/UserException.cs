using System;
using System.Collections.Generic;
using System.Text;

namespace eCarService.Model.Helpers
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) 
        {}
       
    }
}
