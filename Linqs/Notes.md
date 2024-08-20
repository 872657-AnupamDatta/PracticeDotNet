[Dummy](#dummy-sec)

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

### <ins>Quantifier operators:</ins>
These operators are not supported in **Query Syntax**

**All** : It checks whether all the elements inside the collection satisfies the given condition. If any element does not satisfy the condition then it returns ```false```.

**Any** : It checks if any of the element inside the collection satisfies the given condition. If a single element satisfies the condition then it returns ```true```.

**Contains** : It checks if a specific elements exists inside the collection or not.

If we use it with primitive types e.g. int, string etc it will work fine. But if we use it with objects, even though the value is there it will return false. As it only compares reference of an object but not the actual values of an object.

To compare the objects we need to create a class which will implement IEqualityComparer<[CustomClassType]> and also implement the two methods of it. i.e. ```public bool Equals(ClassA obj1, ClassA obj2)``` and ```public int GetHasCode(ClassA obj)```


#<a name="dummy-sec"></a> Dummy
### <ins>Aggregation operators</ins>
These operators perform mathematical operations on the numeric properties of the elements inside the collection.


