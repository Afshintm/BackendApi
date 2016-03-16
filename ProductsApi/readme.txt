This is a simple webapi2 project in which 

1-	Cross origin resource sharing is enabled for the Api to be able to serve any request from other domains and work with any front end project with no same origin policy issue.
 
2-	oData support is enabled for sending get request like  api/products?$top=2 to get top 2 result over the wire instead of entire data and filtering on front end


3-	Dependency Injection used in this project is the most addictive dependency 
injection, Autofac.
4- Ioc.Core is a wrapper library to cover Autofac Dependency for both MVC and WebApi projects



Authentication

We are using a MessageHandler called BasicAuthentictionHandler for authentication as well as an implementation of AuthorizationFilterAttribute for Authorization filter.
Using a MessageHandler which has to implement DelegatingHandler helps us check the request at the early stages of asp.net web api pipeline and validate if request has Authorization header 
from which we can get a BasicAuthenticationIdentity and set the Thread.GenericPrincipal with that Identity.
We could have inherited our Authorization filter from AuthorizeAttribute. However, we do not need Role in this application so implementing AuthorizationFilterAttribute
sound plausible. 

MyAuthorization class has implemented AuthorizeAttribute which we do not need 

In order to authenticate add a Header with the value of "Basic YWZzaGluOlBhc3N3b3JkIQ==" then you are good to go



