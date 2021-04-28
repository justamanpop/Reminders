using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminders.Models
{
    public class SubscriptionModel
    {

        public SubscriptionModel()
        {

        }

        public SubscriptionModel(string endpoint, string p256DH, string auth, string client)
        {
            Endpoint = endpoint;
            P256DH = p256DH;
            Auth = auth;
            Client = client;
        }

        public string Endpoint { get; set; }
        public string P256DH { get; set; }
        public string Auth { get; set; }
        
        [Key]
        public string Client { get; set; }
    }
}
