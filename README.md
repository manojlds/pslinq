#pslinq

LINQ for Powershell

###Available cmdlets

The following cmdlets are available as of now:

**Aggregate-List**

Examples:

Sum:

```powershell
1..10 | Aggregate-List { $input + $acc} -seed 10
#65
```

Product:

```powershell
1..10 | Aggregate-List { $acc * $input } -seed 1
```

String reverse:

```powershell
"abcdefg" -split '' | Aggregate-List { $input + $acc }
#gfedcba
```

**All-List**

Examples:

```powershell
1..10 | All-List { $input -le 6 }
#False
```

**Any-List**

Examples:

```powershell
1..10 | Any-List { $input -eq 5 }
#True
```
