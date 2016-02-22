This is a simple webapi2 project in which 

1-	Cross origin resource sharing is enabled for the Api to be able to serve any request from other domains and work with any front end project with no same origin policy issue.
 
2-	oData support is enabled for sending get request like  api/products?$top=2 to get top 2 result over the wire instead of entire data and filtering on front end


3-	Dependency Injection used in this project is the most addictive dependency 
injection, Autofac.
4- Ioc.Core is a wrapper library to cover Autofac Dependency for both MVC and WebApi projects

5- to authenticate add a Header with the value of "Basic YWZzaGluOlBhc3N3b3JkIQ=="
then you are good to go