# car-rental

## Backend With C# 

### Layers 

#### It is a Car Rental Backend project written in .Net, developed within the framework of Enterprise Layered Architecture and SOLID principles.

* **Core:** The core layer of the project is used for universal operations.
* **DataAccess:** It is the layer that connects the project to the Database.
* **Entities:** It was created to use our tables in the database as objects in our project. It also includes DTO objects.
* **Business:** It is the business layer of our project. Various business rules; Data controls, validations, IoC Containers and authorization checks
* **WebAPI:** It is the Restful API Layer of the project. Methods used: Get, Post, Put, Delete

### Used Technologies


* .Net Core 3.1
* Restful API
* Result Types
* Interceptor
* Autofac
  * IoC Containers
  * AOP (Aspect Oriented Programming)
    * Caching
    * Performance
    * Transaction
    * Validation
* Fluent Validation
* Cache Management
* JWT Authentication
* Repository Design Pattern
* Cross Cutting Concerns
  * Caching
  * Validation
* Extensions
  * Claim
    * Claim Principal
  * Exception Middleware
  * Service Collection
  * Error Handling
    * Error Details
    * Validation Error Details
