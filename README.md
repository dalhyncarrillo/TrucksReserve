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

### Images

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/home.png "Home")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/categories.png "Categories")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/category.png "Category")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/contacts.png "Contacts")

![alt text](https://github.com/raste/TrucksReserve/blob/master/screenshots/transition.png "Page change slide in shot")
