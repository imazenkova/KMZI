const Alphavit = [
  "a",
  "b",
  "c",
  "d",
  "e",
  "f",
  "g",
  "h",
  "i",
  "j",
  "k",
  "l",
  "m",
  "n",
  "o",
  "p",
  "q",
  "r",
  "s",
  "t",
  "u",
  "v",
  "w",
  "x",
  "y",
  "z",
];
//[13] 1. На основе аффинной системы подстановок Цезаря; a=6, b=7
// 2. Таблица Трисемуса, ключевое слово – security

console.log(`Aphabet: ${Alphavit}`);

let Fname = "Gleb";
let Sname = "Hlystov";

function YCesar(a, b, indx) {
  return (a * indx + b) % Alphavit.length;
}

function CesarSH(a, b, key) {
  console.log("CesarHS");
  let timer = Date.now();

  key = key.toLowerCase();
  let keySH = [];

  for (let i = 0; i < key.length; i++) {
    keySH[i] = Alphavit[YCesar(a, b, Alphavit.indexOf(key[i]))];
  }

  console.log("Key: " + key);
  console.log("KeySH: " + keySH.join(""));
  console.log(`Time: ${Date.now() - timer}`);
  let ghystogram = {};

  for (let i = 0; i < keySH.length; i++) {
    if (ghystogram[keySH[i]] == undefined) {
      ghystogram[keySH[i]] = 1;
    } else {
      ghystogram[keySH[i]]++;
    }
  }

  let ghysto = document.getElementById("ghysto");
  ghysto.innerHTML = "";

  for (let letter in ghystogram) {
    let percent = ghystogram[letter] / keySH.length;
    DrowGhysto(ghysto, percent, letter);
    console.log(letter + " = " + ghystogram[letter]);
  }

  console.log("--------------------------------------------");
}

function TrisemysSH(key) {
  console.log("TrisemysSH");
  let timer = Date.now();

  key = key.toLowerCase();
  let j = 0;
  let keySH = [];

  for (let i = 0; i < key.length; i++) {
    keySH[i] =
      Alphavit.indexOf(key[i]) + j > Alphavit.length
        ? Alphavit[Alphavit.indexOf(key[i]) + j - Alphavit.length]
        : Alphavit[Alphavit.indexOf(key[i]) + j];
    j++;
  }

  console.log("Key: " + key);
  console.log("KeySH: " + keySH.join(""));
  console.log(`Time: ${Date.now() - timer}`);

  let ghystogram = {};

  for (let i = 0; i < keySH.length; i++) {
    if (ghystogram[keySH[i]] == undefined) {
      ghystogram[keySH[i]] = 1;
    } else {
      ghystogram[keySH[i]]++;
    }
  }

  let ghysto = document.getElementById("ghysto");
  ghysto.innerHTML = "";

  for (let letter in ghystogram) {
    let percent = ghystogram[letter] / keySH.length;
    DrowGhysto(ghysto, percent, letter);
    console.log(letter + " = " + ghystogram[letter]);
  }

  console.log("--------------------------------------------");
}

function DrowGhysto(ghysto, percent, letter) {
  let h = 200 * percent;
  let line = document.createElement("div");
  line.innerHTML = `
    <div style="width: 50px; height: ${h}px; background-color: coral;">
        ${Math.floor(percent * 100)}%
    </div>
    <p>${letter}</p>`;
  ghysto.append(line);
}
