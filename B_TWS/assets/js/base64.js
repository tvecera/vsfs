const initBase64 = () => {
  const inputButton = document.getElementById('button-input');
  const outputButton = document.getElementById('button-output');

  outputButton.addEventListener('click', decodeBase64);
  inputButton.addEventListener('click', encodeBase64);
}

function encodeBase64(value) {
  const input = document.querySelector('textarea[name="input"]');
  const output = document.querySelector('textarea[name="output"]');
  const error = document.querySelector('.error');
  error.style.display = 'none';

  let toDecode = !value ? value : input.value;
  output.value = btoa(unescape(encodeURIComponent(toDecode)));
  computeStat();
}

function decodeBase64(value) {
  const input = document.querySelector('textarea[name="input"]');
  const output = document.querySelector('textarea[name="output"]');
  const error = document.querySelector('.error');
  const errorContent = document.querySelector('.error p');
  error.style.display = 'none';

  try {
    let toDecode = !value ? value : output.value;
    input.value = decodeURIComponent(escape(atob(toDecode)));
    computeStat();
  } catch (e) {
    input.value = '';
    error.style.display = 'flex';
    errorContent.textContent = 'Nevalidní Base64 řetězec';
  }
}

addTextareaListeners();
initBase64();