BTSXBalance
==============

Simple utity to calculate the BTSX Balance from the genesis.json without using your wallet.

This simple tool, checks your BTSX balance without using any your wallet/s, it just extracts the addresses from the output of "listaddressgroupings" or from a comma separated file and matches them to the genesis.json.


A windows compiled version can be found here: https://www.dropbox.com/s/ahri1d61zd1fc6r/BTSXBalance.zip


Usage
============

List Address Groupings
========================

On Bitshares-PTS or Bitcoin-QT go to debug and type  "listaddressgroupings"

Copy the output on a text file named "addressGroupings.txt" 


Comma separated file
========================
If you already know your addreseses, or use another client like "Multibit" just simply create a text file named "addressesCommaSeparated.txt" and type the addresses separated by commas

ie: jlkjfalkfjalkdfjskjgja,jflkadjlfkafjlafjll


