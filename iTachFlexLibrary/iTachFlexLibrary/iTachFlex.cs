using System;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes

namespace iTachFlexLibrary
{
    public class iTachFlexClass
    {        
        public delegate void UpdateNetworkSettings(SimplSharpString configlock, SimplSharpString ipsetting, SimplSharpString ipaddress, SimplSharpString subnet, SimplSharpString gateway);
        public UpdateNetworkSettings UpdateNetworkSettingsEvent { set; get; }

        public void dataReceive(string data)
        {            
            if (data.Contains(","))
            {
                var dataArray = data.Split(',');
                switch (dataArray[0])
                {
                    case "NET":
                        if (dataArray.Length >= 7)
                        {
                            UpdateNetworkSettingsEvent(dataArray[2], dataArray[3], dataArray[4], dataArray[5], dataArray[6]);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
