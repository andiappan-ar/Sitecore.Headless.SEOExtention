<h1 align="center">Sitecore.Headless.SEOExtention</h1>
This is smaller SEO utility project and its used to support SEO features like Sitemap.xml,Robot.txt.

## Sitemap
Generate a sitemap.xml using this platform project.  We can consume sitemap xml by passing start path of an Root item.

#### Setup template and content items
Serialization project is made up of TDS project. Inherit below template in the your page templates.
![image](https://user-images.githubusercontent.com/11770345/159174232-a92df354-5112-4236-95e0-722505453cdc.png)

Below SEO fields. Please customize as your wish. Similar chnages needs to update in respective models mentioned in extention project.
![image](https://user-images.githubusercontent.com/11770345/159174359-8b1de1ee-65f3-4bf4-8d06-921cd4afce6e.png)

* General fields are used to display in sitemap xml(image_loc,image_title,changefreq,priority)
* Settings field "HideFromSitemap" used to control to enable/disable

#### Setup artifact
This project should be deployed in HEAD(Sitecore XP). This project refernced sitecore.kernel 10.1.0. Please change the repective Sitecore kernel version according your requirement.
* Deploy the DLL(Sitecore.Headless.SEO.Extention)
* Deploy the app_config(\App_Config\Modules\Sitecore.Headless.SEOExtension\Sitecore.Headless.SEOExtension.config)

#### Usage
Post deployment you can generate sitemap xml like below
![image](https://user-images.githubusercontent.com/11770345/159166962-726fb009-1d55-48fa-af45-169e9fc4e81b.png)

Sample code for consuming this in ASP.NET SDK : https://github.com/andiappan-ar/Sitecore.DemoBank/tree/master/Src/ASPNET.SDK/Feature/Sitemap

## Supported Headless clients
JSS , ASP.NET SDK
