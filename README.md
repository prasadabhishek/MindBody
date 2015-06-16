# MindBody
Homework Assignment


###Design Approach

The design involved simple use of MVC architecture using asp.Net C#. The webpage is spread out across Model , Views and their Controllers.

The drop down is populated on page load using the Staff Service which is used as a SOAP WSDL and resides in the Service reference folder.

On selecting a value from the staff member dropdown the appointment service is called and the gridview is updated with the data received and wrapped as json data for use with the javascript plugin.


###Technologies Used
Apart from the basic C# , the gridview was designed using [JQgrid](http://jqgrid.com/) which is a javascript library. This involves wrapping the data from the controller
into json data in order to display in the Jqgrid.


Demo Link : http://mindbodyhomework.azurewebsites.net/

