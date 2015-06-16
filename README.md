# MindBody
Homework Assignment


###Design Approach

The design involved simple use of MVC architecture using asp.Net C#. The webpage is spread out across Model , Views and their Controllers.

The drop down is populated on page load using the Staff Service which is used as a SOAP WSDL and resides in the Service reference folder.

On selecting a value from the staff member dropdown the appointment service is called and the gridview is updated with the data received and wrapped as json data for use with the javascript plugin.


The main files are :
* Index.cshtml : This is the view i.e the html page.
* HomeController.cs : This is the controller for Index.cshtml
* Appointment.js : This is the javascript file defining the jqgrid on load and on refresh.
* Appointment.cs : This is the Model file for appointments.

###Technologies Used
Apart from the basic C# , the gridview was designed using [JQgrid](http://jqgrid.com/) which is a javascript library. This involves wrapping the data from the controller
into json data in order to display in the Jqgrid.


Demo Link : http://mindbodyhomework.azurewebsites.net/

