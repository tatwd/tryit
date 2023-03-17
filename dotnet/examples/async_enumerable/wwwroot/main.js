document.querySelector("#btn").addEventListener("click", fetchData);

const textDecoder = new TextDecoder();
const outputEl = document.querySelector("#output");

async function fetchData() {
  const res = await fetch("/stream");
  console.log(res.body);
  // const json = await res.json();
  // console.log(json);

  const reader = res.body.getReader();

  while (true) {
    const { done, value } = await reader.read();
    if (done) {
      break;
    }
    const str = textDecoder.decode(value.slice(1));
    if (str) {
      const item = JSON.parse(str);
      console.log(item);
      rednerItem(item);
    }
  }
}

function rednerItem(item) {
  const keys = Object.keys(item);
  let innerHTML = outputEl.innerHTML;

  if (!innerHTML) {
    innerHTML += keys.join(",") + "\n";
  }

  innerHTML += keys.map((key) => `${item[key]}`).join(",") + "\n";
  outputEl.innerHTML = innerHTML;
}
