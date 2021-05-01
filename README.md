# BusinessLogicEngine
POC on using Chain of Responsibilities. 
Done with TDD to prove the concept, when using DIC, the SingleBusinessOperationTests.CreateOrderEngine could be done when requesting the order engine. 

The idea is that orders will run through a pipeline of handlers, able to create other events based on information on the order. 

# Todos:
- Add in logging
- Get create a working dependency container
