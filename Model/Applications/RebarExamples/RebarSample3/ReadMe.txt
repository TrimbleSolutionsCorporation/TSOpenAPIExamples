Tekla Open API Example

This is sample #3 of reinforcement creation with Tekla Open API.
In this sample, we are implementing a Tekla Structures plug-in. A plug-in has
its own behaivior and the main difference compared to an extended application
is the fact that a plug-in has its own UI in Tekla Structures and it can be
defined to be dependent on its input. Whenever the input is modified Tekla
Structures will call the plug-in Run() method and this way the output objects
of the plug-in will be modifed and updated to match with the modified input.

In this example, the actual code inside Run() method is like in Sample #2 with
few additions, which are typical to plug-ins, like default value handling.
Also, the management of number of bars at bottom/top has been added.

API:s used: Tekla.Structures.Model, Tekla.Structures.Plugins.