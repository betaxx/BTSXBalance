BTSXBalance
==============

Simple utity to calculate the BTSX Balance from the genesis.json without using your wallet.

This simple tool, checks your BTSX balance without using any your wallet/s, it just extracts the addresses from the output of "listaddressgroupings" or from a comma separated file and matches them to the genesis.json.


A .net compiled version can be found here: https://www.dropbox.com/s/ahri1d61zd1fc6r/BTSXBalance.zip, this should run in windows and linux / mac osx using mono


Usage
============

List Address Groupings
========================

On Bitshares-PTS or Bitcoin-QT go to debug and type  "listaddressgroupings"

Copy the output for BTC on "addressGroupingsBTC.txt" and for PTS on "addressGroupingsPTS.txt"

It should look like this:

[
[
[
"12CLxa1B5V3ywxFaP7Qb5GUPF9kB7q48n4",
0.18279316,
"mul2"
],
[
"18wh9z4o2NWSVJijiX6CcBLXYhPdahmbKk",
0.00000000,
"mul1"
]
]
]


Comma separated file
========================
If you already know your addreseses, or use another client like "Multibit" just simply create a text file named "addressesCommaSeparated.txt" and type the addresses separated by commas

ie: jlkjfalkfjalkdfjskjgja,jflkadjlfkafjlafjll


Donate 
PTS: Pf2hppxYg7XUvgKnMyMDm6dGL6wsia9vU5
BTC: 1CY35fWBSMTe14dfkymt9Xf2dHRJa1CfSg



