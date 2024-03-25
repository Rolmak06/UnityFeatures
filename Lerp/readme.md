# Purpose
Here are gathered some "lerp scripts" that empower the user to modify parameters in time such as scale, position, rotation, material color etc.. This is mainly used for animations. Those scripts offers event to listen to when to lerp starts and when it ends. I use them for a lot of different things such as UI, feedbacks etc..

# Based around the abstract class : LerpBase

All the lerp scripts are base on an abstract class "BaseLerp" that gives 2 abstracts methods : Lerp & LerpReverse. 
The base class also offers a coroutine to actually do the lerp. It is implemented by the other classes with an action parameter to avoid rewritting the same code again and again.
