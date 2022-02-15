í
JC:\dev-personal\double-entry-exploring\src\DoubleEntry.Broker\BaseEvent.cs
	namespace 	
DoubleEntry
 
. 
Broker 
{ 
public 

abstract 
class 
	BaseEvent #
{ 
public 
Type 
	EventType 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
DateTime		 
GeneratedAt		 #
{		$ %
get		& )
;		) *
}		+ ,
public

 
Guid

 
EventId

 
{

 
get

 !
;

! "
}

# $
public 
string 
Payload 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
	protected 
	BaseEvent 
( 
string "
payload# *
)* +
{ 	
GeneratedAt 
= 
DateTime "
." #
Now# &
;& '
EventId 
= 
Guid 
. 
NewGuid "
(" #
)# $
;$ %
Payload 
= 
payload 
; 
} 	
public 
abstract 
bool 
IsEventValid )
() *
	BaseEvent* 3
@event4 :
): ;
;; <
public 
abstract 
	BaseEvent !

BuildEvent" ,
(, -
	BaseEvent- 6
@event7 =
)= >
;> ?
public 
abstract 
bool 
Exists #
(# $
	BaseEvent$ -
comparedEvent. ;
); <
;< =
public 
virtual 
string 
SerializePayload .
(. /
object/ 5
payload6 =
)= >
=>? A
JsonConvertB M
.M N
SerializeObjectN ]
(] ^
payload^ e
)e f
;f g
public 
virtual 
T 
DeserializePayload +
<+ ,
T, -
>- .
(. /
)/ 0
=>1 3
JsonConvert4 ?
.? @
DeserializeObject@ Q
<Q R
TR S
>S T
(T U
PayloadU \
)\ ]
;] ^
} 
} ø
LC:\dev-personal\double-entry-exploring\src\DoubleEntry.Broker\EventBroker.cs
	namespace 	
DoubleEntry
 
. 
Broker 
{ 
public 

class 
EventBroker 
: 
IEventBroker +
{		 
private

 
readonly

 "
IEventBrokerRepository

 /
_repository

0 ;
;

; <
public 
EventBroker 
( "
IEventBrokerRepository 1

repository2 <
)< =
{ 	
_repository 
= 

repository $
;$ %
} 	
public 
IList 
< 
	BaseEvent 
> 
EventsCommitted  /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
=> ?
new@ C
ListD H
<H I
	BaseEventI R
>R S
(S T
)T U
;U V
public 
IList 
< 
	BaseEvent 
> 
EventsToCommit  .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
new? B
ListC G
<G H
	BaseEventH Q
>Q R
(R S
)S T
;T U
public 
void 
CommitEvents  
(  !
IList! &
<& '
	BaseEvent' 0
>0 1
events2 8
)8 9
{ 	
foreach 
( 
var 
@event 
in  "
EventsToCommit# 1
)1 2
{ '
CheckDuplicatedBeforeCommit +
(+ ,
), -
;- .
} 
_repository 
. 
InsertEvents $
($ %
events% +
)+ ,
;, -
} 	
public 
void '
CheckDuplicatedBeforeCommit /
(/ 0
)0 1
{ 	
foreach   
(   
var   
@event   
in    "
EventsToCommit  # 1
)  1 2
{!! 
if"" 
("" 
EventsCommitted"" #
.""# $
Any""$ '
(""' (
x""( )
=>""* ,
x""- .
."". /
Exists""/ 5
(""5 6
@event""6 <
)""< =
)""= >
)""> ?
throw## 
new## $
DuplicatedEventException## 6
(##6 7
)##7 8
;##8 9
}$$ 
}%% 	
public'' 
IEnumerable'' 
<'' 
	BaseEvent'' $
>''$ %
GetAllEvents''& 2
(''2 3
)''3 4
{(( 	
return)) 
_repository)) 
.)) 

ReadEvents)) )
())) *
DateTime))* 2
.))2 3
MinValue))3 ;
))); <
;))< =
}** 	
public,, 
IEnumerable,, 
<,, 
	BaseEvent,, $
>,,$ % 
GetEventsBasedOnType,,& :
(,,: ;
Type,,; ?
	eventType,,@ I
),,I J
{-- 	
return.. 
_repository.. 
... 

ReadEvents.. )
(..) *
	eventType..* 3
)..3 4
;..4 5
}// 	
}00 
}11 –
MC:\dev-personal\double-entry-exploring\src\DoubleEntry.Broker\IEventBroker.cs
	namespace 	
DoubleEntry
 
. 
Broker 
{ 
public 

	interface 
IEventBroker !
{ 
void 
CommitEvents 
( 
IList 
<  
	BaseEvent  )
>) *
@events+ 2
)2 3
;3 4
void		 '
CheckDuplicatedBeforeCommit		 (
(		( )
)		) *
;		* +
IEnumerable

 
<

 
	BaseEvent

 
>

 
GetAllEvents

 +
(

+ ,
)

, -
;

- .
IEnumerable 
< 
	BaseEvent 
>  
GetEventsBasedOnType 3
(3 4
Type4 8
	eventType9 B
)B C
;C D
} 
} Ò
WC:\dev-personal\double-entry-exploring\src\DoubleEntry.Broker\IEventBrokerRepository.cs
	namespace 	
DoubleEntry
 
. 
Broker 
{ 
public 

	interface "
IEventBrokerRepository +
{ 
void 
InsertEvents 
( 
IList 
<  
	BaseEvent  )
>) *
events+ 1
)1 2
;2 3
IList		 
<		 
	BaseEvent		 
>		 

ReadEvents		 #
(		# $
DateTime		$ ,
since		- 2
)		2 3
;		3 4
IList

 
<

 
	BaseEvent

 
>

 

ReadEvents

 #
(

# $
Type

$ (
	eventType

) 2
)

2 3
;

3 4
} 
} 