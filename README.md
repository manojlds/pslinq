#pslinq

LINQ for Powershell.

##Available cmdlets

The following cmdlets are available as of now:

[Aggregate-List](#aggregate-list)

[All-List](#all-list)

[Any-List](#any-list)

[Except-List](#except-list)

[First-List](#first-list)

[Intersect-List](#intersect-list)

[Repeat-List](#repeat-list)

[SelectMany-List](#selectmany-list)

[Single-List](#single-list)

[Skip-List](#skip-list)

[SkipWhile-List](#skipwhile-list)

[Take-List](#take-list)

[TakeWhile-List](#takewhile-list)

[Union-List](#union-list)

[Zip-List](#zip-list)


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

###Except-List

Examples:

```powershell
1..10 | Except-List 1,3,5,7
#2
#4
#6
#8
#9
#10
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

###Repeat-List

Example:

```powershell
1..3 | Repeat-List 2
#1
#1
#2
#2
#3
#3
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

###Skip-List

Example:

```powershell
1..10 | Skip-List 6
#7
#8
#9
#10
```

###SkipWhile-List

Example:

```powershell
1..10 | SkipWhile-List { $input -le 8 }
#9
#10
```

###Take-List

Example:

```powershell
1..10 | Take-List 3
#1
#2
#3

1..10 | Skip-List 3 | Take-List 3
#4
#5
#6
```

###TakeWhile-List

Example:

```powershell
1..10 | TakeWhile-List { $input -lt 4 }
#1
#2
#3
```

###Union-List

Example:

```powershell
"a", "b", "c" | Union-List "c", "d"
#a
#b
#c
#d
```

###Zip-List

Example:

```powershell
"a", "b", "c" | Zip-List $(1..4) { $first + $second }
#a1
#b2
#c3
```
