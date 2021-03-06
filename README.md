# WordBubbles
A .NET command line solver for the Word Bubbles app, a word puzzle app where you must make one or more words by connecting adjacent letter bubbles (above/below, beside, or diagonally). The game is available on [iOS](https://itunes.apple.com/us/app/wordbubbles!/id922488002?mt=8) and [Android](https://play.google.com/store/apps/details?id=com.apprope.wordbubbles).

![Demonstration GIF](https://raw.githubusercontent.com/Jamish/WordBubbles/master/WordBubbles.gif)

## Disclaimer

Another crappy solver that I wrote in less than 2 hours. A friend of mine kept asking for help in solving them, and it's honestly more fun to program a solver than it is to do the puzzles.

Again, I don't profess that I chose the most efficient way to solve these puzzles, I merely chose the fastest way for me to write it. It can also stand to get a more refined console interface, including printing out the coordinates of each letter used and avoiding duplicate answers when words have the same length, but meh.

## Usage

Run the executable. 

1. For each row of word bubbles, type in each letter and hit enter. If there is a "blank spot" in the grid of word bubbles, enter a space instead of a letter.
1. After entering every row, hit Enter to continue
1. Type in the length of each word that you are trying to find, separated by a space. Hit return.
1. It will print out all the potential solutions it can find. Annoyingly, most WordBubble puzzles have multiple solutions, and unless you spend hints, you just have to guess which solution is best. 

## Attribution

The word list belongs to http://www-01.sil.org/linguistics/wordlists/english/