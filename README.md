# Sleep-Timer
A small program to allow a Windows PC to have timed shutdown functionality, similar to the "Sleep Timer" found on most TVs.

# Introduction
I use my computer as my "television" when going to sleep at night and I want a solution to allow it to automatically shutdown after a given time. There 
were very few exisiting options and none that really matched my exact use case, so I decided to produce a small program myself.

# Functionality
A timer can be set for any time between 100 hours and 1 second. Once the timer reaches 0 the computer will enter the standard shutdown cycle. The timer 
can be set in advance and adjusted whilst it is running by pressing the corresponding arrows on the UI to add tens of hours, hours, tens of minutes, minutes,
tens of seconds or seconds. The timer also has standard start, pause and stop functionality. 

# Display
There is a simple colour coding to the UI:

__Background Colour__
* __Red__ - The timer is currently paused or stopped
* __Green__ - The timer is currently running

__Timer Text Colour__
* __Red__ - There is less than 10 minutes left on the timer
* __Orange__ - There is less than 30 minutes left on the timer
* __Green__ - There is more than 30 minutes left on the timer

## License
Copyright (c) 2015-2021 Chris Haynes and others

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
