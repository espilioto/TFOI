![awwyiss](https://i.imgur.com/10uOBiI.png)
# The Finding Of Items
A run tracker and logger for The Binding of Isaac: Rebirth

### Download [Here]

### Features
* Seed, character, item, floor + curse, boss and time identification for current run.
* Run log analyzing every recent run (char, items, bosses, time etc).
* Item collection displaying the icon, name, flavor text, detailed stats and run statistics for each one.
* Character and boss collections displaying run statistics for each one.

#### Usage
Windows: Just decompress and run. You may need to update the Microsoft .net Framework.  
Linux: Unfortunately, WPF didn't work with Wine last time I checked.

#### Backstory
It all started when I realized that I had played hundreds of hours of Isaac, but had no way to compare or analyze my runs, except for my achievements and the Stats screen of course.
But that wasn't even remotely enough.  
I then remembered a similar app existing for Hearthstone.
Off I went to Google, and there it was, the [RebirthItemTracker].  
Having that as a base, I started developing TFOI (and using it as a reason to play more Isaac).

#### Credits and thanks

* [NICALiS] and [Edmund McMillen] for making this awesome game.
* [This] project that really helped and inspired me.
* My friend, Eddy Pasterino, for beta testing (usually against his will).

### Development

This basically is a text parser that reads the game's log.
It identifies certain events (like picking up an item) and presents them to the user, so that anyone can catch up with just a glance.

> When the run finishes, it inserts the run's data into a database.
> That data will be available to the user through various screens like: 
> * Run log
> * Item-related data 
> * Boss-related data
> * Character-related data
^  

Soon™

#### *Todos*
* New run 
  * Floor tracking
  * Curse tracking
  * Died to boss 
  * Defeated boss marker
  * ! Database stuff !
  * Confirm effects of D4 / D100 / dice rooms (must play more :D)
* Items
  * Past run stats
* Chars 
  * Past run stats
* Bosses
  * Past run stats
* Options
  * TBD


#### *Probably adding these*
* New Run mini mode (overlay for streams etc)

#### *Maybe / Luxury*
* New Run 
  * Rebirth style pixelate menu transitions
* Items
  * MouseOver/click effect
  * tooltip formatting


#### Known bugs
*Pretty sure this will fill up eventually*
 
### License
[MIT]

[Here]: <https://github.com/espilioto/TFOI/releases>
[NICALiS]: <http://nicalis.com>
[Edmund McMillen]: <https://twitter.com/edmundmcmillen>
[This]: <https://github.com/Hyphen-ated/RebirthItemTracker>
[RebirthItemTracker]: <https://github.com/Hyphen-ated/RebirthItemTracker>
[MIT]:<http://choosealicense.com/licenses/mit/>
