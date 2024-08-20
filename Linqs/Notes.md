- [Join](#join-sec)
- [Quantifier Operator](#quantifier-operators-sec)
- [Aggregation operators](#aggregation-operators-sec)

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
<a name="quantifier-operators-sec"></a>
### <ins>Quantifier operators:</ins>

These operators are not supported in **Query Syntax**

**All** : It checks whether all the elements inside the collection satisfies the given condition. If any element does not satisfy the condition then it returns ```false```.

**Any** : It checks if any of the element inside the collection satisfies the given condition. If a single element satisfies the condition then it returns ```true```.

**Contains** : It checks if a specific elements exists inside the collection or not.

If we use it with primitive types e.g. int, string etc it will work fine. But if we use it with objects, even though the value is there it will return false. As it only compares reference of an object but not the actual values of an object.

To compare the objects we need to create a class which will implement IEqualityComparer<[CustomClassType]> and also implement the two methods of it. i.e. ```public bool Equals(ClassA obj1, ClassA obj2)``` and ```public int GetHasCode(ClassA obj)```


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


