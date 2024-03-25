# Intro
Here are gathered some "lerp scripts" that empower the user to modify parameters in time. This is mainly used for animations.

# Abstract Class usage
All the lerp scripts are base on an abstract class "BaseLerp" that gives 2 abstracts methods : Lerp & LerpReverse. 
The base class also offers a coroutine to actually do the lerp. It is implemented by the other classes with an action parameter to avoid rewritting the same code again and again 
