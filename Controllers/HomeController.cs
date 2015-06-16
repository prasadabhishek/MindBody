using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MindBody.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            // Set credential values
            string sourcename = "MBO.Abhishek.Prasad";
            string password = "UL3VWtGuCnihT6gNig9e88sK+w4=";
            MindBody.StaffService.ArrayOfInt siteIDs = new MindBody.StaffService.ArrayOfInt();
            siteIDs.Add(-31100);

            // Create Client
            StaffService.StaffServiceSoapClient client = new StaffService.StaffServiceSoapClient();
            // Create request
            StaffService.GetStaffRequest staffRequest = new StaffService.GetStaffRequest();
            // Create and fill credentials
            staffRequest.SourceCredentials = new StaffService.SourceCredentials();
            staffRequest.SourceCredentials.SourceName = sourcename;
            staffRequest.SourceCredentials.Password = password;
            staffRequest.SourceCredentials.SiteIDs = siteIDs;
            // Run call with request and fill result  
            StaffService.GetStaffResult staffResult = client.GetStaff(staffRequest);

            // List to populate the dropdown
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (StaffService.Staff st in staffResult.StaffMembers)
            {
                if (st.ID > 0)
                {
                    System.Diagnostics.Debug.WriteLine(st.Name + " " + st.ID);
                    listItems.Add(new SelectListItem
                    {
                        Text = st.Name,
                        Value = st.ID.ToString(),
                    });
                }
            }
            // populate the dropdown
            ViewBag.staffList = new SelectList(listItems, "value", "text");

            return View();
        }

        public ActionResult GridData(string sidx, string sord, int page, int rows, string value, string text)
        {
            // Set credential values
            string sourcename = "MBO.Abhishek.Prasad";
            string password = "UL3VWtGuCnihT6gNig9e88sK+w4=";
            MindBody.AppointmentService.ArrayOfInt siteIDs = new MindBody.AppointmentService.ArrayOfInt();
            siteIDs.Add(-31100);
            string[] textSplit = text.Split(' ');
            string StaffCredentialsUserName = textSplit[0] + "." + textSplit[1];
            string StaffCredentialsPassword = textSplit[0][0].ToString().ToLower() + textSplit[1][0].ToString().ToLower() + value;
            // Create Client
            AppointmentService.AppointmentServiceSoapClient client = new AppointmentService.AppointmentServiceSoapClient();
            // Create request
            AppointmentService.GetStaffAppointmentsRequest staffRequest = new AppointmentService.GetStaffAppointmentsRequest();
            // Create and fill credentials
            staffRequest.SourceCredentials = new AppointmentService.SourceCredentials();
            staffRequest.SourceCredentials.SourceName = sourcename;
            staffRequest.SourceCredentials.Password = password;
            staffRequest.SourceCredentials.SiteIDs = siteIDs;
            staffRequest.StaffCredentials = new AppointmentService.StaffCredentials();
            staffRequest.StaffCredentials.Username = StaffCredentialsUserName;
            staffRequest.StaffCredentials.Password = StaffCredentialsPassword;
            staffRequest.StaffCredentials.SiteIDs = siteIDs;
            DateTime datetime = new DateTime(2014, 1, 03);
            staffRequest.StartDate = datetime;
            staffRequest.EndDate = datetime;

            // Run call with request and fill result  
            AppointmentService.GetStaffAppointmentsResult appointmentResult = client.GetStaffAppointments(staffRequest);

            //Convert to required json data
            if (appointmentResult.Appointments != null)
            {
                var jsonData = new
                {
                    rows = (
                           from ap in appointmentResult.Appointments
                           select new
                           {
                               id = ap.ID,
                               cell = new string[] { 
                                                ap.StartDateTime.ToString().Split(' ')[0], ap.StartDateTime.ToString().Split(' ')[1] + " " + ap.StartDateTime.ToString().Split(' ')[2]  , ap.EndDateTime.ToString().Split(' ')[1] + " " + ap.EndDateTime.ToString().Split(' ')[2],ap.Client.LastName + ", " + ap.Client.FirstName,ap.SessionType.Name
                                               }
                           }).ToArray()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonData = new
                {
                    rows = new[]{
                                  new {id = 1, cell = new[] {""}}
                                }
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}