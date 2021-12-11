const initBattery = () => {
  const form = document.querySelector('form');
  const resultElm = document.querySelector('.battery-result');
  const hours = document.querySelector('#hours');
  const days = document.querySelector('#days');
  const months = document.querySelector('#months');
  const years = document.querySelector('#years');

  form.addEventListener('submit', event => {
    let data = validate(form);
    resultElm.style.display = 'none';

    if (data.valid) {
      let result = getBatteryLife(data);
      hours.textContent = result.hodin;
      days.textContent = result.dnu;
      months.textContent = result.mesicu;
      years.textContent = result.rok;
      resultElm.style.display = 'block';
    } else {
      hours.textContent = '0.0';
      days.textContent = '0.0';
      months.textContent = '0.0';
      years.textContent = '0.0';
    }

    event.preventDefault();
  });
}

const getBatteryLife = (data) => {
  let hodina = 60 * 60 * 1000;
  let realnaKapacita = data.capacity * data.real;

  let zapnuto = data.duration * data.hour;
  let vypnuto = hodina - zapnuto;
  let spotrebaZapnuto = zapnuto * data.wake;
  let spotrebaVypnuto = vypnuto * (data.sleep / 1000);
  let spotreba = (spotrebaZapnuto + spotrebaVypnuto) / hodina

  let hodin = realnaKapacita / spotreba;
  let dnu = hodin / 24;
  let mesicu = dnu / 30;
  let rok = dnu / 365;

  return {
    hodin: round(hodin),
    dnu: round(dnu),
    mesicu: round(mesicu),
    rok: round(rok),
  }
}

const round = (value) => Math.round(value * 100) / 100;

const validate = (form) => {
  const error = document.querySelector('.error');
  const errorContent = document.querySelector('.error p');
  error.style.display = 'none';

  const capacity = parseInt(form['battery-capacity'].value);
  const real = parseInt(form['real-battery-capacity'].value);
  const sleep = parseFloat(form['consumption-in-sleep'].value);
  const wake = parseFloat(form['consumption-in-wake'].value);
  const duration = parseInt(form['duration'].value);
  const hour = parseInt(form['wake-ups'].value);

  let valid = true;
  let msg = [];

  if (!valid) {
    error.style.display = 'flex';
    errorContent.innerHTML = '';
    msg.forEach(error => {
      errorContent.innerHTML += `${error} <br />`;
    })
  }

  return {
    valid: valid,
    capacity: capacity,
    real: real / 100,
    sleep: sleep,
    wake: wake,
    duration: duration,
    hour: hour,
  }
}

initBattery();