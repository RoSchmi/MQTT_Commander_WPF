using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_Client.Models
{
    public class AccountMembers

    {
        public object AccessInstance { get; set; }

        public string Name { get; set; }
        public bool Security { get; set; }
        public string CaCertPath { get; set; }
        public string ClientCertPath { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }

        public AccountMembers() { }
        public AccountMembers(object pAccessInstance, string pName, bool pSecurity, string pCaCertPath, string pClientCertPat, string pUser, string pPassword, string pPort)
        {
            Name = pName;
            AccessInstance = pAccessInstance;          
            Security = pSecurity;
            CaCertPath = pCaCertPath;
            ClientCertPath = pClientCertPat;
            User = pUser;
            Password = pPassword;
            Port = pPort;
        }
    }
}
