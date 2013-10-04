# Shoelace
##_Jump start your project with your shoes already on!_


This project is aimed at bootstrapping and jump starting your next desktop or mobile portal project by bringing 
the best tools in their specific areas and mending them together.  This implements a 
responsive design with all of the must have controls to quickly build out forms, dashboards 
reports and basic portal functionality.  


###Brought to you by:

* **ASP.NET MVC 4 using Razor (CSHTML)**
* **jQuery** 
* **Knockout.js** _(using client bindings/templates instead of Razor bindings)_
* **Knockout.Validation.js**
* **Knockout.mapping.js**
* **[Twitter Bootstrap](http://getbootstrap.com/) Responsive Design**
* **[Bootstrap-Admin-Theme by Vincent Gabriel](https://github.com/VinceG/Bootstrap-Admin-Theme)**
* **The WebMatrix SimpleMembership Implementation**
* **Entity Framework 5 with Code First Data Modeling**


###What you get before writing a sign line of code

* **User Login**
* **Admin User Profile Management**
* **Create a Profile**
* **User List Management**
* **Role Base security**
* **Themed Modals, forms, tables, site layout and other layouts examples found in the Samples pages**

###MVC and MVVM Together with a ~twist~
The Web is a difficult place to effectively use MVC and MVVM patterns.  This project
attempts to keep the cshtml files void of ASP.NET MVC Methods and bindings in favor of the knockout implementation.  Since we are using knockout, 
it is necessary to pass that responsibility to the client. You will see the following patterns throughout the 
project:

- The client javascript application registers the _app.js_ file as the **Global** application object (called **APP**).  This can maintain shared resources, global configurations, helpers, etc. All view models create their respective 
knockout observables models within the **APP** object.  They are hydrated via cshtml rendering (see next step).

```javascript


	APP.userListViewModel = function (model) {
		var self = model;
		$.extend(APP.userListViewModel, model);
	};

```

- The Model's properties originate from the MVC modeling, JSON serialized and passed to 
the client. Each view gets a _.js_ file that is registered. View Models can be extended for validation and 
computed properties in their _.js_ view model function. 

```javascript


     $(function () {
         var viewModelObj = APP.userListViewModel(ko.mapping.fromJS(@Html.Raw(Model.ToJson())));
            ko.applyBindings(viewModelObj, document.getElementById("cntnrUserList"));
        });
```


 
## Contributors

* Justin Hyland (author) Email: justin.hyland@live.com

## MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/hylander0/shoelace/trend.png)](https://bitdeli.com/free "Bitdeli Badge")
