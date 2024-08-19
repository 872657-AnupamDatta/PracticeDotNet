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


