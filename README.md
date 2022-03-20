<h1 align="center">Sitecore.Headless.SEOExtention</h1>
This is smaller SEO utility project and its used to support SEO features like Sitemap.xml,Robot.txt.

## Sitemap
Generate a sitemap.xml using this platform project.  We can consume sitemap xml by passing start path of an Root item.

#### Setup template and content items

#### Setup artifact
This project should be deployed in HEAD(Sitecore XP). This project refernced sitecore.kernel 10.1.0. Please change the repective Sitecore kernel version according your requirement.
* Deploy the DLL(Sitecore.Headless.SEO.Extention)
* Deploy the app_config(\App_Config\Modules\Sitecore.Headless.SEOExtension\Sitecore.Headless.SEOExtension.config)

#### Usage
Post deployment you can generate sitemap xml like below
![image](https://user-images.githubusercontent.com/11770345/159166962-726fb009-1d55-48fa-af45-169e9fc4e81b.png)


## Supported Headless clients
JSS , ASP.NET SDK
