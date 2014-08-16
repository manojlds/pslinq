#pslinq

LINQ for Powershell

##Available cmdlets

The following cmdlets are available as of now:

[Aggregate-List](#aggregate-list)
[All-List](#all-list)
[Any-List](#any-list)
[First-List](#first-list)
[Intersect-List](#intersect-list)
[SelectMany-List](#selectmany-list)
[Single-List](#single-list)

###Aggregate-List

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

###All-List

Examples:

```powershell
1..10 | All-List { $input -le 6 }
#False
```

###Any-List

Examples:

```powershell
1..10 | Any-List { $input -eq 5 }
#True
```

###First-List

Examples:

```powershell
1..10 | First-List { $input -eq 5 }
#5
1..10 | First-List { $input -eq 11 }
#Throws exception
```

###Intersect-List

Example:

```powershell
1..10 | Intersect-List $(5..15)
#5
#6
#7
#8
#9
#10
```

###SelectMany-List

Example:

```powershell
"abc", "def" | SelectMany-List { $input.ToCharArray() }
#a
#b
#c
#d
#e
#f
```

###Single-List

Example:

```powershell
1..10 | Single-List { $input -eq 5 }
#5
1..10 | Single-List { $input -ge 5 }
#Throws exception
1..10 | Single-List { $input -eq 11 }
#Throws exception
```
