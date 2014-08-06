pslinq
======

LINQ for Powershell

#Available cmdlets:

##Aggregate-List:

Example:

```powershell
1..10 | Aggregate-List { $input + $acc} -seed 10
#65
```
