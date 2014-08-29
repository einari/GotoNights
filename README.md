This includes the sample used @ the GOTONights in Copenhagen and Aarhus, Denmark on the 27th and 28th of August 2014.
https://secure.trifork.com/cph-2014/freeevent/index.jsp?eventOID=6452
https://secure.trifork.com/aarhus-2014/freeevent/index.jsp?eventOID=6453

The sample is preconfigured to use MongoDB - see in the Configurato.cs file and you'll see. 
All you need is just to download MongoDB and run it with default configuration.

MongoDB can be downloaded here: http://www.mongodb.org/downloads

The configuration used in the demo had MongoDB installed in c:\mongodb,
inside this folder create a MongoDB.cfg file and add the following to it:

   dbpath=c:\mongodb\data

Create the data folder inside the mongodb folder and then start mongo from the CommandLine like so:

   mongod --config c:\mongodb\mongod.cfg


Happy CQRSing and MVVMing with Bifrost :)
