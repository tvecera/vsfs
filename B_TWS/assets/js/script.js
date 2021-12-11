const refreshTextareaMeta = () => {
  document.querySelectorAll('.stat')?.forEach(stat => {
    const textarea = document.getElementById(stat.dataset.textareaId);
    let data = JSON.parse(textarea.dataset.stat);
    stat.children[0].textContent = data.len;
    stat.children[1].textContent = data.lines;
    stat.children[2].textContent = `[${data.position}] ${data.selected}`;
  });
}

const computeSelected = (value, start, end) => {
  const selection = value.substring(start, end);

  return (selection && selection.length > 0) ? selection.length : 0;
}

const computePosition = (element) => {
  return element.selectionStart;
}

const computeStat = () => {
  document.querySelectorAll('textarea')?.forEach(textarea => {
    let stat = JSON.parse(textarea.dataset.stat);
    stat.len = textarea.value.length;
    stat.lines = stat.len > 0 ? textarea.value.length - textarea.value.replace(/\n/g, '').length + 1 : 0;
    // Safari fix
    stat.position = stat.len > 0 ? computePosition(textarea) : 0;

    textarea.dataset.stat = JSON.stringify(stat);
  });

  refreshTextareaMeta();
}

const copy = (id) => {
  const element = document.getElementById(id);
  let value = element.value;
  if (element.selectionStart !== element.selectionEnd) {
    value = element.value.substring(element.selectionStart, element.selectionEnd);
    element.focus();
  }
  navigator.clipboard.writeText(value).then();
}

const downloadToFile = (content, filename, contentType) => {
  const a = document.createElement('a');
  const file = new Blob([content], { type: contentType });

  a.href = URL.createObjectURL(file);
  a.download = filename;
  a.click();

  URL.revokeObjectURL(a.href);
};

const addTextareaListeners = () => {
  // Input and Selection events
  document.querySelectorAll('textarea')?.forEach(textarea => {
      textarea.dataset.stat = JSON.stringify({ len: 0, lines: 0, selected: 0, position: 0 });
      let fn = window[textarea.dataset.function];

      textarea.addEventListener('input', event => {
        if (event.target.dataset.realtime === '1') {
          fn(event.target.value);
        }
        computeStat();
      });
    }
  );

  document.addEventListener('selectionchange', () => {
    document.querySelectorAll('textarea')?.forEach(textarea => {
      let stat = JSON.parse(textarea.dataset.stat);
      stat.selected = computeSelected(textarea.value, textarea.selectionStart, textarea.selectionEnd);
      stat.position = computePosition(textarea);
      if (textarea.selectionStart === textarea.selectionEnd) {
        stat.selected = 0;
      }
      // Safari fix
      stat.position = textarea.value.length > 0 ? computePosition(textarea) : 0;

      textarea.dataset.stat = JSON.stringify(stat);
      refreshTextareaMeta();
    });
  });

  // Active icons
  document.querySelectorAll('.icon-copy')?.forEach(icon => {
      icon.addEventListener('click', event => {
        copy(event.target.parentElement.dataset.textareaId);
      });
    }
  );

  // Mobile, touch device fix
  document.querySelectorAll('button:not(.icon-bolt, .button)')?.forEach(icon => {
      icon.addEventListener('touchend', event => {
        event.target.style.color = 'inherit';
      });
    }
  );

  document.querySelector('.icon-bolt')?.addEventListener('click', event => {
    const textarea = document.querySelector('textarea');
    const value = Math.abs(textarea.dataset.realtime - 1).toString();
    if (value === '1') {
      event.target.classList.add('active');
      event.target.style.color = 'var(--color-red)';
    } else {
      event.target.classList.remove('active');
      event.target.style.color = 'inherit';
    }

    document.querySelectorAll('textarea')?.forEach(area => {
      area.dataset.realtime = value;
    });

    textarea.focus();
  });

  document.querySelectorAll('.icon-clear')?.forEach(icon => {
      icon.addEventListener('click', event => {
        const textarea = document.getElementById(event.target.parentElement.dataset.textareaId);
        textarea.value = textarea.defaultValue;
        window.getSelection().removeAllRanges();
        textarea.dispatchEvent(new Event('input'));
        document.dispatchEvent(new Event('selectionchange'));
      });
    }
  );

  document.querySelectorAll('.icon-save')?.forEach(icon => {
    icon.addEventListener('click', event => {
      const textarea = document.getElementById(event.target.parentElement.dataset.textareaId);
      downloadToFile(textarea.value, `${textarea.name}.txt`, 'text/plain');
    });
  });
}