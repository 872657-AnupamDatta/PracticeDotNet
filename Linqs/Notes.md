<a name="content-list-sec"></a>
## <ins>Table of content</ins>
- [Join](#join-sec)
- [Quantifier Operator](#quantifier-operators-sec)
- [Aggregation operators](#aggregation-operators-sec)
- [Element Operators](#element-operators-sec)
- [Generation Operators](#generation-operator-sec)

<a name="join-sec"></a>
### <ins>Join:</ins>

Join basically works like inner join of Sql.

It requires two collections.

#### Query Syntax

It requires 

> **outer sequence** , **inner sequence**, **key selector** and **result selector**.


> **'on'** keyword is used for key selector, where left side of ```'equals'``` operator is outerKeySelector and right side of ```'equals'``` is innerKeySelector.

Syntax

> 
```
from ... in [outerSequence]

    join ... in [innerSequence  ]

    on [outerKey] equals [innerKey]

    select ...
```
[Back to Table Of Content](#content-list-sec)

<a name="quantifier-operators-sec"></a>
### <ins>Quantifier operators:</ins>

These operators are not supported in **Query Syntax**

**All** : It checks whether all the elements inside the collection satisfies the given condition. If any element does not satisfy the condition then it returns ```false```.

**Any** : It checks if any of the element inside the collection satisfies the given condition. If a single element satisfies the condition then it returns ```true```.

**Contains** : It checks if a specific elements exists inside the collection or not.

If we use it with primitive types e.g. int, string etc it will work fine. But if we use it with objects, even though the value is there it will return false. As it only compares reference of an object but not the actual values of an object.

To compare the objects we need to create a class which will implement IEqualityComparer<[CustomClassType]> and also implement the two methods of it. i.e. ```public bool Equals(ClassA obj1, ClassA obj2)``` and ```public int GetHasCode(ClassA obj)```

[Back to Table Of Content](#content-list-sec)

<a name="aggregation-operators-sec"></a>
### <ins>Aggregation operators</ins>
It does not support query syntax.

These operators perform mathematical operations on the numeric properties of the elements inside the collection.

**Aggregate** : This returns the accumulated result of the elements' passed property. For example if we have a collection of ```Student``` object, and if it contains ```Age``` property then we can get total age of all the Students.

Its ```Func``` delegate always takes two arguments. And as it is a ```Func``` delegate it returns a value, which is the final one.

> When we use Aggregate with seed value, we pass an additional or starting value that will be used by the Aggregate extension method.

> When we use Aggregate with seed value and result selector, we filter the result of the aggregation process and then return the final result.

**Average** : It calculates the average of the numeric items in the collection and returns nullable or non-nullable decimal, double  or float value.

**Count** : It counts the number of elements present in the collection or the number of elements in collection which satisfy given condition.

**Max** : It returns the largest numeric value of elemenet in the collection.

**Min** : It returns the smallest numeeric value in a collection.

**Sum** : It calculates the sum of numeric items in the collection.

[Back to Table Of Content](#content-list-sec)

<a name = "element-operators-sec"></a>

### <ins>Element Operators</ins>
Element operators return a particular element from a sequence (collection). 

**ElementAt** : Returns the element at a specified index in a collection.

It returns ```OutOfRange``` argument run-time exception, if the index is greater than or equal to the number of elements in the collection. It throws same exception if the list is empty.

**ElementAtOrDefault** : Returns the element at a specified index in a collection or a default value if the index is out of range.

We won't get any run-time exception if the collection is empty in this case.

[It is advisable to use ElementAtOrDefault() to safaguard from Run Time exception]


**First** : Returns the first element of a collection, or the first element that satisfies a condition. It throws exception if the collection is empty. Therefore when ever we are using ```First```, the collection must contain at least one value.

**FirstOrDefault** : Returns the first element of a collection, or the first element that satisfies a condition. If no element is found then it returns default value of that type. e.g. if the collection contains ```inteter``` type value then it will return 0, for string ```null``` etc.

<ins>Note:</ins> **Last** and **LastOrDefault** works in the same way, just in opposite direction.

**Single** : Returns the only element from a collection, or the only element that satisfies a condition. If Single() <em>found no elements or more than one elements</em> in the collection then throws <strong>InvalidOperationException</strong>.

**SingleOrDefault** : 	The same as Single, except that it returns a default value of a specified generic type, instead of throwing an exception if no element found for the specified condition. However, it will thrown <strong>InvalidOperationException</strong> if it finds <em>more than one element</em> for the specified condition in the collection.

[Back to Table Of Content](#content-list-sec)

<a name="generation-operator-sec"></a>

### <ins>Generation Operators</ins>

**Empty** : It returns an empty collection of specified type. It is a static method of Enumerable class.

**Range** : It returns a collection with specified number of elements, containing values starting from specified value, incremented by 1.

**Repeat** : It returns a collection with specified number of elements, containing same value at each position, starting from specified value.

[Back to Table Of Content](#content-list-sec)
