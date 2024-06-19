# DI-in-CSharp

## What is Dependency Injection (DI)?

DI is a design pattern that is used to achieve inversion or control. Instead of the class creating its own dependency they are created from the outside.

It helps to follow SOLID's dependency inversion and single responsibility principles. It also encourages loose coupling of classes with enables maintainability and scalability.

There are 3 types of dependency injection:

1 - constructor Injection -> Dependencies are provided through a class constructor
2 - setter injection -> the dependencies are provided through a property or a method
3 - interface injection -> provided through an interface that the class implements
