## BeerTap  
BeerTap Porject to familiarize with Hypermedia framework  

## To Run:  
-Set startup project to webapi  
-Just run! no need to update database on npm console (may take some time for the first request excluding the root)  

## To Test:  
-Import BeerTap.postman_collection.json to postman  
-Create environment variable named:(This is so that new created resource's id is put to env variable(done inside test tab))  
&nbsp;&nbsp;&nbsp;-officeid  
&nbsp;&nbsp;&nbsp;-tapid  
-To initialize officeid and tapid, you could:  
&nbsp;&nbsp;&nbsp;-Put 1 value in each  
&nbsp;&nbsp;&nbsp;-OR use office create and tap create first.  

## NOTES  
-Change Keg(Change Flavor) is for changing flavor of the keg even if it the current keg is full.  
-For refilling keg use Change Keg(Refill) which works only when the keg is almost dry or dry.
