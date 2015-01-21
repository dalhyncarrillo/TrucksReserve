# Trucks Reserve

### About

An web site for trucks parts dealer. This was my first MVC web site, couple months after it I was recruited for development of such sites. This site didn't manage to get published, but still it was good practice. 

For browsers supporting HTML 5 History it simulates single page application > the pages are loaded via AJAX and changed via animation (no page refresh)(no library is used for this).

[http://tr.wiadvice.com/](http://tr.wiadvice.com/)

### Technologies

.NET 4.0, C#, MVC, LINQ, Entity Framework, AJAX, jQuery, HTML 5 History Api  
JS plugins: [Pixastic](https://github.com/jseidelin/pixastic), [imgPreview](http://james.padolsey.com/demos/imgPreview/full/), [Basic jQuery Slider](http://www.basic-slider.com/), [TinyMCE](http://www.tinymce.com/), [Highslide](http://www.highslide.com/)

### Poke/Edit

In order to modify the code and build the application you will need Visual Studio 2010 or greater.  

To run the project:  
- Make sure you have Microsoft SQL Server 2008 or greater  
- Create the database via script ([DB\TrucksReserve.sql](https://github.com/raste/TrucksReserve/blob/master/DB/TrucksReserve.sql)) or restore it via the backup file ([DB\TrucksReserve.bak](https://github.com/raste/TrucksReserve/blob/master/DB/TrucksReserve.bak)).  
- Update the database connection string in [web.config](https://github.com/raste/TrucksReserve/blob/master/Source/TrucksReserve/Web.config).  
  Locate this line  

  ```  
<connectionStrings>
    <add name="TrucksReserveEntities" connectionString="metadata=res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SOPRANO\SQLEXPRESS;initial catalog=TrucksReserve;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
  ```  
  Replace `NAME` in `data source=NAME;` with the name of the SQL server. Substitude `TrucksReserve` in `initial catalog=TrucksReserve;` with the name of the created database.  
- To receive emails from the contacts form:  
  Browse the [solution](https://github.com/raste/TrucksReserve/blob/master/Source/TrucksReserve.sln) with Visual Studio and open [the settings](https://github.com/raste/TrucksReserve/blob/master/Source/TrucksReserve/Properties/Settings.settings) file in TrucksReserve project. Replace `SiteContactMail` value with the email address, which should receive the emails sent from the contact form.  
  In web.config locate this line:  

  ```
  <mailSettings>
      <smtp deliveryMethod="Network" from="trucks@fake.bg">
        <network host="mail.trucksfake.bg" defaultCredentials="false" userName="trucks@fake.bg" password="trucksPass" />
      </smtp>
  </mailSettings>
  ```  
  Replace `trucks@fake.bg` in both places with the email address, from which the emails will be sent. Substitute `trucksPass` in `password="trucksPass"` with the password of the chosen email address.  
  
  *NOTE: SMTP must be enabled for the email address, in order to send emails from it.*  
- Build the solution. Some of the needed packages should be automatically downloaded from NUGET. If that doesn't happen, go to TOOLS > NuGet package Manager > Package Manager Settings > check Allow NuGet to download missing packages. If that doesn't help or some of the packages cannot be downloaded, get [packages.zip](https://github.com/raste/TrucksReserve/blob/master/Packages/packages.zip) and extract it in the directory of the solution (this archive of the used packages).
- You should be able to run the project now..

### Images

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/home.png "Home")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/categories.png "Categories")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/category.png "Category")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/contacts.png "Contacts")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/transition.png "Page change slide in shot")
