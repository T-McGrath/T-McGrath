/*
1. **iqTest** Bob is preparing to pass an IQ test. The most frequent task in this test 
    is to find out which one of the given numbers differs from the others. Bob observed
    that one number usually differs from the others in evenness. Help Bob — to check his 
    answers, he needs a program that among the given numbers finds one that is different in 
    evenness, and return the position of this number. _Keep in mind that your task is to help 
    Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)_

		iqTest("2 4 7 8 10") → 3 //third number is odd, while the rest are even
		iqTest("1 2 1 1") → 2 // second number is even, while the rest are odd
		iqTest("") → 0 // there are no numbers in the given set
        iqTest("2 2 4 6") → 0 // all numbers are even, therefore there is no position of an odd number
*/
function iqTest(numString) {
    evenCount = 0;
    oddCount = 0;
    evenIndex = 0;
    oddIndex = 0;
    for(let i = 0; i < numString.length; i+=2) {
        // Have to account for double-digit numbers.
        if (numString.substring(i+1, i+2) === " " || i === numString.length - 1) {
            curNum = Number.parseInt(numString.substring(i, i+1));
        }
        else {
            curNum = Number.parseInt(numString.substring(i, i+2));
            i++;
        }
        
        if(curNum % 2 === 0) {
            evenCount++;
            evenIndex = evenCount + oddCount;
        }
        else {
            oddCount++;
            oddIndex = evenCount + oddCount;
        }
    }
    if (evenCount === 0 || oddCount === 0) {
        return 0;
    }
    else if (evenCount === 1) {
        return evenIndex;
    }
    else {
        return oddIndex;
    }
}

/*
2. **titleCase** Write a function that will convert a string into title case, given an optional 
    list of exceptions (minor words). The list of minor words will be given as a string with each 
    word separated by a space. Your function should ignore the case of the minor words string -- 
    it should behave in the same way even if the case of the minor word string is changed.


* First argument (required): the original string to be converted.
* Second argument (optional): space-delimited list of minor words that must always be lowercase
except for the first word in the string. The JavaScript tests will pass undefined when this 
argument is unused.

		titleCase('a clash of KINGS', 'a an the of') // should return: 'A Clash of Kings'
		titleCase('THE WIND IN THE WILLOWS', 'The In') // should return: 'The Wind in the Willows'
        titleCase('the quick brown fox') // should return: 'The Quick Brown Fox'
*/
function titleCase(stringToConvert, minorWords = "") {
    minorWordsLower = minorWords.toLowerCase();
    stringToConvertLower = stringToConvert.toLowerCase();
    result = "";
    indexCount = 0;
    indexOfSpace = -1;
    
    while(indexCount < stringToConvert.length) {
        indexOfSpace = stringToConvertLower.substring(indexCount).indexOf(" ") + indexCount;
        // if indexOf(" ") is -1, then I add indexCount to that...
        if (indexOfSpace === (indexCount - 1)) {
            word = stringToConvertLower.substring(indexCount);
        } 
        else {
            // If it's not the last word, include a space at the end.
            word = stringToConvertLower.substring(indexCount, indexOfSpace + 1);
        }
        // If word has a space at the end, don't include that when checking
        // if the word is in the minorWordsLower string.
        if (word.substring(word.length - 1, word.length) === " ") {
            if (minorWordsLower.indexOf(word.substring(0, word.length - 1)) === -1 || indexCount === 0) {
                result += word.substring(0, 1).toUpperCase() + word.substring(1);
            }
            else {
                result += word;
            }
        }
        else {
            if (minorWordsLower.indexOf(word) === -1 || indexCount === 0) {
                result += word.substring(0, 1).toUpperCase() + word.substring(1);
            }
            else {
                result += word;
            }
        }
        indexCount += word.length;
    }
    return result;
}
