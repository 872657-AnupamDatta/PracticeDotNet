### Join

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

### Quantifier operators
These operators are not supported in **Query Syntax**

**All** : It checks whether all the elements inside the collection satisfies the given condition. If any element does not satisfy the condition then it returns ```false```.

**Any** : It checks if any of the element inside the collection satisfies the given condition. If a single element satisfies the condition then it returns ```true```.
