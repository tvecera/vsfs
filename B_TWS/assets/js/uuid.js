const initUUID4 = () => {
  const outputButton = document.querySelector('form');

  outputButton.addEventListener('submit', event => {
    const count = parseInt(document.querySelector('#count').value);
    const delimiter = parseInt(document.querySelector('#delimiter').value);

    if (count > 0 && count < 500 && delimiter > 0 && delimiter < 10) {
      generateUUIDResult(count, delimiter);
      computeStat();
    }
    event.preventDefault();
  });
}

function generateUUIDResult(count, delimiter) {
  const output = document.querySelector('textarea');
  let txt = '';
  let prefix = '';
  let delimiterTxt;
  let addMarks = false;
  let json = false;

  switch (delimiter) {
    case 1:
      delimiterTxt = '\n';
      break;
    case 2:
      delimiterTxt = ' ';
      break;
    case 3:
      delimiterTxt = ', ';
      break;
    case 4:
      delimiterTxt = '; ';
      break;
    case 5:
      addMarks = true;
      delimiterTxt = ', ';
      break;
    case 6:
      addMarks = true;
      delimiterTxt = '; ';
      break;
    case 7:
      addMarks = true;
      delimiterTxt = '\n';
      break;
    case 8:
      addMarks = true;
      delimiterTxt = '';
      break;
    case 9:
      txt += '[\n';
      addMarks = true;
      delimiterTxt = ',\n';
      prefix = '  ';
      json = true;
      break;
    default:
      delimiterTxt = '\n';
      break;
  }

  for (let i = 0; i < count; i++) {
    if (addMarks) {
      txt += prefix + `"${uuidv4()}"`;
    } else {
      txt += prefix + uuidv4();
    }
    txt += i < count - 1 ? delimiterTxt : '';
  }

  if (json) {
    txt += '\n]';
  }

  output.value = txt;
}

// https://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid?page=2&tab=votes#tab-top
function uuidv4() {
  return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, (c) => {
    const r = (window.crypto.getRandomValues(new Uint32Array(1))[0] * Math.pow(2, -32) * 16) | 0;
    const v = c === "x" ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
}

addTextareaListeners();
initUUID4();