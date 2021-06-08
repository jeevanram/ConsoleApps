Template Method Pattern
It defines the steps in a process where some of the steps are deferred to the concrete class implementing the abstract class.

The problem that we are trying to solve ? - Two similar processes follow an identical process other than some intermediate steps. If we carve out the common steps, then the process can reuse them and implement only the steps that differ.

![image](https://user-images.githubusercontent.com/5312171/121104110-f1da4e00-c7c6-11eb-9b40-819dabde8b7e.png)

The Abstract class defines the steps that are invariant across the implementations, and the variant steps are either implemented with default implementation or declared as abstract for the inheriting class to override it.

For example, An interview process will have invariant steps like Resume Screening, Initial HR process, and Offer Negotiation and variant steps namely Technical Discussion, Bar Raiser, and Manager Discussion.

![image](https://user-images.githubusercontent.com/5312171/121113297-6ae1a180-c7d7-11eb-9444-e708e59d7ec2.png)


