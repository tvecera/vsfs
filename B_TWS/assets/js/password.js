const lowercase = 'abcdefghijklmnopqrstuvwxyz';
const uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
const numbers = '0123456789';
const symbols = '!@#$%&*+?.';

const initPassword = () => {
  const form = document.querySelector('form');
  const output = document.querySelector('textarea');
  const uppercaseCheckbox = form['uppercase'];
  const numbersCheckbox = form['numbers'];
  const specialCheckbox = form['special'];
  const excludeCheckbox = form['exclude'];
  const upperCount = form['uppercase-count'];
  const numbersCount = form['numbers-count'];
  const symbolsCount = form['special-count'];
  const exclude = form['exclude-chars']

  uppercaseCheckbox.addEventListener('click', event => {
    upperCount.disabled = !event.target.checked;
  });

  numbersCheckbox.addEventListener('click', event => {
    numbersCount.disabled = !event.target.checked;
  });

  specialCheckbox.addEventListener('click', event => {
    symbolsCount.disabled = !event.target.checked;
  });

  excludeCheckbox.addEventListener('click', event => {
    exclude.disabled = !event.target.checked;
  });

  form.addEventListener('submit', event => {
    let data = validate(form, uppercaseCheckbox, numbersCheckbox, specialCheckbox, excludeCheckbox, upperCount, numbersCount, symbolsCount, exclude);
    let result = '';

    if (data.valid) {
      for (let i = 0; i < data.count; i++) {
        result += generatePassword(data.len, data.uppers, data.numbers, data.symbols, data.exclude) + '\n';
      }
      output.value = result;
      computeStat();
    }

    event.preventDefault();
  });
}

const validate = (form, uppercaseCheckbox, numbersCheckbox, specialCheckbox, excludeCheckbox, upperCount, numbersCount, symbolsCount, exclude) => {
  const error = document.querySelector('.error');
  const errorContent = document.querySelector('.error p');
  error.style.display = 'none';
  let valid = true;
  let msg = [];

  const passwordLCount = form['password-count'];
  const passwordLength = form['password-length'];

  let excludeValue = excludeCheckbox.checked ? exclude.value : '';
  let countValue = parseInt(passwordLCount.value);
  let lengthValue = parseInt(passwordLength.value);
  let uppersValue = uppercaseCheckbox.checked ? parseInt(upperCount.value) : 0;
  let numbersValue = numbersCheckbox.checked ? parseInt(numbersCount.value) : 0;
  let symbolsValue = specialCheckbox.checked ? parseInt(symbolsCount.value) : 0;

  if (countValue <= 0 || countValue > 500) {
    valid = false;
    msg.push('Počet generovaných hesel musí být mezi 1 a 500.');
  }

  if (lengthValue <= 0 && lengthValue > 50) {
    valid = false;
    msg.push('Délka hesla musí být mezi 1 a 50 znaky.');
  } else {
    if (uppersValue <= 0 && uppersValue > 50) {
      valid = false;
      msg.push('Počet velkých písmen v heslu musí být mezi 1 a 50 znaky.');
    } else if (uppersValue > lengthValue) {
      valid = false;
      msg.push('Počet velkých písmen v heslu nesmí být větší než délka hesla.');
    }

    if (numbersValue <= 0 && numbersValue > 50) {
      valid = false;
      msg.push('Počet čísel v heslu musí být mezi 1 a 50 znaky.');
    } else if (numbersValue > lengthValue) {
      valid = false;
      msg.push('Počet čísel v heslu nesmí být větší než délka hesla.');
    }

    if (symbolsValue <= 0 && symbolsValue > 50) {
      valid = false;
      msg.push('Počet speciálních znaků v heslu musí být mezi 1 a 50 znaky.');
    } else if (symbolsValue > lengthValue) {
      valid = false;
      msg.push('Počet speciálních znaků v heslu nesmí být větší než délka hesla.');
    }

    if (exclude && excludeValue.length > 9) {
      valid = false;
      msg.push('Maximální povolený počet vyloučených znaků je 9.');
    }

    if (valid && lengthValue < (uppersValue + numbersValue + symbolsValue)) {
      valid = false;
      msg.push('Součet počtů pro velké písmena, čísla a speciální znaky je větší než délka hesla.');
    }
  }

  if (!valid) {
    error.style.display = 'flex';
    errorContent.innerHTML = '';
    msg.forEach(error => {
      errorContent.innerHTML += `${error} <br />`;
    })
  }

  return {
    valid: valid,
    count: countValue,
    len: lengthValue,
    uppers: uppersValue,
    numbers: numbersValue,
    symbols: symbolsValue,
    exclude: excludeValue,
  }
}

const generatePassword = (passwordLength, upperCount, numbersCount, symbolsCount, exclude) => {
  let pass = generateRandom(upperCount, removeExcluded(uppercase, exclude));
  pass += generateRandom(numbersCount, removeExcluded(numbers, exclude));
  pass += generateRandom(symbolsCount, removeExcluded(symbols, exclude));

  let lowerCount = passwordLength - pass.length;
  pass += generateRandom(lowerCount, removeExcluded(lowercase, exclude));

  return shuffle([...pass]).join('');
}

const removeExcluded = (chars, exclude) => {
  const escapeRegExp = exclude.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');

  if (exclude.length > 0) {
    const regex = new RegExp(`[${escapeRegExp}]`, 'g');
    return chars.replaceAll(regex, '');
  }

  return chars;
}

const generateRandom = (length, chars) => {
  return [...window.crypto.getRandomValues(new Uint32Array(length))]
    .map(ch => chars[ch % chars.length])
    .join('');
};

function shuffle(a) {
  let n = a.length;
  let k, t;
  [...window.crypto.getRandomValues(new Uint8Array(n))].map((x, i) => {
    k = x % (i + 1);
    t = a[i];
    a[i] = a[k];
    a[k] = t;
  })

  return a;
}

addTextareaListeners();
initPassword();