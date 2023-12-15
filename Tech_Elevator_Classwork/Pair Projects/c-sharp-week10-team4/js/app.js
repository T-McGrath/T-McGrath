let num1;
let num2;
let curScore = 0;
let curProblemNum = 1;
//const numProblems = 10;
let operationArray = [];
const wrongAnswerMax = 100;
let actualProblem;
let answerChoices = [];
let globalAnswer;

function getRandomNumber(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

function shuffleArray(arr) {
    return arr.sort((a, b) => {return Math.random() - 0.5});
}

// function createProblem(operation) {
//     num1 = getRandomNumber(10);
//     num2 = getRandomNumber(10);
//     const randIndex = getRandomNumber(0, operation.length);
//     return `${num1} ${operation[randIndex]} ${num2}`
// }

function createProblem() {
    num1 = getRandomNumber(10);
    num2 = getRandomNumber(10);
    actualProblem = `${num1} * ${num2}`;
    return actualProblem;
}

function createAnswers() {
    answerChoices = [];
    if (actualProblem.indexOf("*") >= 0) {
        globalAnswer = num1 * num2;
        answerChoices.push(globalAnswer);
    }
    else if (actualProblem.indexOf("/") >= 0) {
        globalAnswer = num1 / num2;
        answerChoices.push(globalAnswer);
    }
    else if (actualProblem.indexOf("+") >= 0) {
        globalAnswer = num1 + num2;
        answerChoices.push(globalAnswer);
    }
    else {
        globalAnswer = num1 - num2;
        answerChoices.push(globalAnswer);
    }
    for(let i = 0; i < 3; i++) {
        let wrongAnswer = getRandomNumber(100);
        while(answerChoices.indexOf(wrongAnswer) >= 0) {
            wrongAnswer = getRandomNumber(100);
        }
        answerChoices.push(wrongAnswer);
    }
    shuffleArray(answerChoices);
    return answerChoices;
}

function displayProblem() {
    const problemBox = document.querySelector("div.expression.show-hide");
    problemBox.innerText = createProblem();
}

function displayAnswers() {
    createAnswers();
    let index = 0;
    const answerList = document.querySelectorAll("li");
    answerList.forEach((item) => {
        item.innerText = answerChoices[index];
        index++;
    });
}

document.addEventListener("DOMContentLoaded", () => {
    displayProblem();
    displayAnswers();

    const stuffToShowHide = document.querySelectorAll(".show-hide");
    const allListItems = document.querySelectorAll("li");
    const curScoreSpan = document.querySelector("span.currentScore");
    const curProblemSpan = document.querySelector("span.currentProblem");

    allListItems.forEach(li => {
        
        li.addEventListener("click", event => {
            if (event.target.innerText == globalAnswer) {
                curScore++;
                curScoreSpan.innerText = curScore;
            }
            displayProblem();
            displayAnswers();
            if (curProblemNum < 10) {
                curProblemNum++;
                curProblemSpan.innerText = curProblemNum;
            }
            else {
                stuffToShowHide.forEach((element) => {
                    element.style.display = "none";
                });
            }
        });
    });

    const startOverButt = document.getElementById("btnStartOver");
    startOverButt.addEventListener("click", (event) => {
        stuffToShowHide.forEach(element => {
            element.style.display = "block";
        });
        curScore = 0;
        curScoreSpan.innerText = curScore;
        curProblemNum = 1;
        curProblemSpan.innerText = curProblemNum;
        displayProblem();
        displayAnswers();
    });
});








