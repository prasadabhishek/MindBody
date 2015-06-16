using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindBody.Models
{
    public class Appointment
    {
        private string p1;
        private string p2;
        private string p3;
        private AppointmentService.Client client;
        private AppointmentService.SessionType sessionType;

        public string Id { get; set; }
        public string AppointmentDate { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Client { get; set; }
        public string Type { get; set; }

        public Appointment(string date, string start, string end, string client, string type)
        {
            this.AppointmentDate = date;
            this.Start = start;
            this.End = end;
            this.Client = client;
            this.Type = type;
        }

        public Appointment(string p1, string p2, string p3, AppointmentService.Client client, AppointmentService.SessionType sessionType)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.client = client;
            this.sessionType = sessionType;
        }
    }
}