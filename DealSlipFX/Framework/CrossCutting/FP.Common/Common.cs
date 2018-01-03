using System;
using System.Collections.Generic;
using System.Text;

namespace FP.Common
{
    public class Common
    {
        private static bool _IsDataEntryOpen = false;
        private static bool _IsDBConnectionError;

        public bool IsDBConnectionError
        {
            get { return _IsDBConnectionError; }
            set { _IsDBConnectionError = value; }
        }


        public bool IsDataEntryOpen
        {
            get { return _IsDataEntryOpen; }
            set { _IsDataEntryOpen = value; }
        }

        public bool checknumeric(char presskey)
        {
            if (!((presskey >= 48 && presskey <= 57) || (presskey == 8) || (presskey == 9) || (presskey == 12) || (presskey == 27) || (presskey == 37) || (presskey == 39) || (presskey == 46))) // and of course more checks 
            {
                return true;
                
            }
            return false;
        }

        public bool CheckCharacter(char presskey)
        {
            if (char.IsNumber(presskey) != true)
            {
                return true;
            }

            return false;
        }

        public string ChangeDateFormat(string datetime)
        {
            DateTime date = new DateTime();
            date = Convert.ToDateTime(datetime);

            return date.ToString("MM/dd/yyyy");
        }
    }
}
