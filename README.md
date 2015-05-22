# README #


### What is this repository for? ###

This is a simple webapi2 project in which there is a products controller to do simple crud operation on products

1-	Cross origin resource sharing is enabled for the Api to be able to serve any request from other domains and work with any front end project with no same origin policy issue.
 
2-	oData support is enabled for sending get request like  api/products?$top=2 to get top 2 result over the wire instead of entire data and filtering on front end


3-	Dependency Injection used in this project is the most addictive dependency 
injection, Autofac.

4- Ioc.Core is a wrapper library to cover Autofac Dependency for both MVC and WebApi projects


* Quick summary

* Version


### How do I get set up? ###

To get application up and running just clone it and open Backend.sln using visual studio 2013 and above and build it.

localhost://ProductApi/api/Products will list all the products and 
localhost://ProductApi/api/Products?$top=2 will show the top 2 records.


* Summary of set up
* Configuration
* Dependencies
* Database configuration
* How to run tests
* Deployment instructions

### Contribution guidelines ###

* Writing tests
* Code review
* Other guidelines

### Who do I talk to? ###

* Afshin Teymoori afshin_tm@yahoo.com