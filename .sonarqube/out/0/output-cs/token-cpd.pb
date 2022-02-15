‰
dC:\dev-personal\double-entry-exploring\src\DoubleEntry.Common\Exceptions\DuplicatedEventException.cs
	namespace 	
DoubleEntry
 
. 
Common 
. 

Exceptions '
{ 
public 

class $
DuplicatedEventException )
:* +
	Exception, 5
{ 
} 
} Ô

]C:\dev-personal\double-entry-exploring\src\DoubleEntry.Common\Extensions\AccountExtensions.cs
	namespace 	
DoubleEntry
 
. 
Common 
. 

Extensions '
{ 
public 

static 
class 
AccountExtensions )
{ 
public 
static 
string 
ToAccountingFormat /
(/ 0
this0 4
decimal5 <
value= B
)B C
{ 	
if		 
(		 
value		 
<		 
$num		 
)		 
return

 
$"

 
{

 
Math

 
.

 
Round

 $
(

$ %
value

% *
*

+ ,
-

- .
$num

. /
,

/ 0
$num

1 2
)

2 3
}

3 4
$str

4 6
"

6 7
;

7 8
if 
( 
value 
> 
$num 
) 
return 
$" 
{ 
Math 
. 
Round $
($ %
value% *
,* +
$num, -
)- .
}. /
$str/ 1
"1 2
;2 3
return 
$str 
; 
} 	
} 
} Ä
\C:\dev-personal\double-entry-exploring\src\DoubleEntry.Common\Extensions\StringExtensions.cs
	namespace 	
DoubleEntry
 
. 
Common 
. 

Extensions '
{ 
public 

static 
class 
StringExtensions (
{ 
public 
static 
bool 
IsNullOrEmpty (
(( )
this) -
string. 4
text5 9
)9 :
{ 	
return 
string 
. 
IsNullOrEmpty '
(' (
text( ,
), -
&&. 0
string1 7
.7 8
IsNullOrWhiteSpace8 J
(J K
textK O
)O P
;P Q
}R S
}		 
}

 