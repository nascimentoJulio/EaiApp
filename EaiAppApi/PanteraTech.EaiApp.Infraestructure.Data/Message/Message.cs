using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanteraTech.EaiApp.Infraestructure.Data.Message
{
    public class Message
    {

        public int Id { get; set; }

        public string MessageContent { get; set; }

        public DateTime DataSend { get; set; }

        public string UserSend { get; set; }

        public string UserReceive { get; set; }

	}
}
