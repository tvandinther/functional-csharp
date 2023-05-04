# Functional C#

This repository contains some example code for ways to spice up your C# code with functional programming techniques.

## PartialApplication

This example shows how to use partial application to create a function that can be used to create other functions. This is a useful refactoring technique to reduce duplication in your code. In the example code I show how partial application is similar to the factory pattern but with less code and more flexibility.

## FunctionComposition

By using extension methods, you can define helper methods to compose functions together. This is useful for creating a pipeline of operations to be performed on a value. This concept can be extended to crazy lengths. Enjoy this example and see how far you can take it.

## HierarchicalTypes

This example utilises inheritance to create a hierarchical type of payment methods. It then shows how you can use this to pattern match on the type to perform different operations based on the type of payment method.

This example is a counterpoint to the traditional OOP approach of using abstract methods or interfaces to achieve polymorphism. We use inheritance strictly on data types, and use pattern matching to achieve polymorphism.

In the traditional OOP approach, we have ease of extension but difficulty of modification. Adding a new payment method is as simple as creating a new class that implements the `IPaymentMethod` interface (or inherits from the abstract base class). However, if we want to add a new operation, we have to modify the interface and all the classes that implement it.

In the approach exemplified in this project, we have ease of modification but difficulty of extension. Adding a new operation is as simple as creating a new switch expression. However, creating a new payment method requires a modification to every switch expression switching on the base type.

These tradeoffs cancel each other out. The right approach depends on whether you are more likely to extend or modify. However, there is a large benefit to using the approach shown in this project. By keeping your logic in one place, you reduce the indirection of the code making it easier to understand and maintain. Now, payment processing code is all in one place, rather than spread out across multiple classes. Common payment processing logic can easily be extracted locally rather than requiring a new class to be depended on by all the payment methods sharing the logic. This dependency would likely be injected, further increasing complexity and indirection.

> Inheritance is dangerous when used with logic but can be a powerful tool when used strictly for data to model the domain.

### A note on sum types
A sum type is a type that is constructed by the disjunction of other types. For example, we can express a type `IntOrString` as the sum of `Int` and `String`: `IntOrString = Int | String`. However, C# does not support sum types natively, so we have to get creative. We can use inheritance to create a sum type, where each child type represents one of the possible values of the sum type. `Int : IntOrString` and `String : IntOrString`. Unfortunately, this is not perfect, as it doesn't allow us to create another sum type for `IntOrBoolean` because we cannot have multiple inheritance.

Sum types are best described as constructive disjunctions, where a type can be constructed by using one of the constructors (i.e. `Int` or `String`. While inheritance permits only a destructive exclusive disjunction, where we deconstruct a higher-type into one of its sub-types. This means that we can only use one of the constructors at a time, and we cannot use the constructors to create a new type. For this reason, it is easier to think of sum types as a hierarchy of types, where each type is a sub-type of the higher type. Using this approach now allows us to use C# pattern matching to determine which constructor we are dealing with, and perform operations using this information.

## StateMachine

In this example, hierarchical sum types are used to build an expressive state machine to model an arbitrary game with two players and several rounds, with each turn containing different phases.

`GameState.cs` contains various data types to represent the different states of the game using hierarchy. State transitions are handled by a "plinko" of switch expressions using pattern matching to determine the next state based on the current state and the action taken by the player.

## Combinators

This example shows how to create and use combinators to build up complex validations from simple building blocks. It utilises boolean algebra and predicates to map a custom domain to boolean values for algebraic reduction. Combining booleans with only the boolean operations of `AND`, `OR`, and `NOT`, we can create complex validations that are easy to read and maintain. A predicate is a mapping from any type `T` to a boolean. This type of function is extremely powerful because it allows us to enter the world of boolean algebra from any type `T`.

There is an implementation using the C# `Func` delegate to create a functional approach and an example using classes and interfaces for contrast. The functional approach is more concise and expressive.

## OptionType

This example shows how to use the `Option` type to represent a value that may or may not exist. This is useful for when you want to represent a value that may be null, but you don't want to use null. This is because null is not type safe and can lead to runtime errors. The `Option` type is a sum type that can be either `Some` or `None`. `Some` contains a value, and `None` does not. This allows us to safely represent a value that may or may not exist. The `Option` type is a functor, which means that it has a `Select` method that allows us to map a function over the value inside the `Option` type. This is useful for when you want to perform an operation on the value, but only if it exists. If the value does not exist, the operation is not performed and the `None` value is returned.

The examples show how to create this type using inheritance as well as a single class with access protection to achieve a similar result. There is also examples of an extension of the Option type called Either. Either is like Option, except that None is replaced by another value. Typically, this is used to contain an error type value in the left, or a correct value in the right.